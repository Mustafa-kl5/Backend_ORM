using Microsoft.Extensions.Options;
using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Helpers;
using ORM.Application.Common.Localization;
using ORM.Application.Common.Settings;
using ORM.Core.DTOs.Auth;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    private readonly JwtSettings _jwtSettings;
    private readonly ILocalizationService _localization;
    private readonly IActivityLogService _activityLogService;

    public AuthService(
        IUserRepository userRepository,
        IJwtService jwtService,
        IOptions<JwtSettings> jwtSettings,
        ILocalizationService localization,
        IActivityLogService activityLogService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _jwtSettings = jwtSettings.Value;
        _localization = localization;
        _activityLogService = activityLogService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
    {
        // Encrypt the input userLogin to match stored encrypted value
        var encryptedUserLogin = EncryptionHelper.Encrypt(request.UserLogin);
        var user = await _userRepository.GetByLoginAsync(encryptedUserLogin);

        if (user == null)
        {
            // Log failed login attempt - user not found
            await _activityLogService.LogAuthenticationAsync(EventType.LoginFailed, false, "User not found");
            throw new UnauthorizedException(_localization.Get(MessageKeys.InvalidCredentials));
        }

        // Check if user is deactivated
        if ( user.OrmDeactivate == true)
        {
            await _activityLogService.LogAuthenticationAsync(EventType.LoginFailed, false, "Account deactivated");
            throw new UnauthorizedException(_localization.Get(MessageKeys.AccountDeactivated));
        }

        // Check if user is locked
        if (user.OrmLock == true)
        {
            await _activityLogService.LogAuthenticationAsync(EventType.LoginFailed, false, "Account locked");
            throw new UnauthorizedException(_localization.Get(MessageKeys.AccountLocked));
        }

        // Validate password using BCrypt
        if (!PasswordHelper.VerifyPassword(request.UserPassword, user.UserPassword))
        {
            // Log failed login attempt (await to ensure it completes before throwing)
            await _activityLogService.LogAuthenticationAsync(EventType.LoginFailed, false, "Invalid password");
            throw new UnauthorizedException(_localization.Get(MessageKeys.InvalidCredentials));
        }

        // Generate tokens
        var token = _jwtService.GenerateToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);

        // Save refresh token to database
        await _userRepository.UpdateRefreshTokenAsync(user.UserId, refreshToken, refreshTokenExpiration);

        // Log successful login
        await _activityLogService.LogAuthenticationAsync(EventType.LoginSuccess, true);

        // Decrypt user data for response
        var decryptedName = DecryptIfEncrypted(user.Name);
        var decryptedUserLogin = DecryptIfEncrypted(user.UserLogin);
        var decryptedEmail = DecryptIfEncrypted(user.EmailAddress);

        return new LoginResponseDto
        {
            UserId = user.UserId,
            Name = decryptedName ?? string.Empty,
            UserLogin = decryptedUserLogin ?? string.Empty,
            EmailAddress = decryptedEmail,
            Token = token,
            TokenExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            RefreshToken = refreshToken,
            RefreshTokenExpiration = refreshTokenExpiration
        };
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
    {
        var userId = _jwtService.GetUserIdFromExpiredToken(request.Token);

        if (userId == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.InvalidToken));

        var user = await _userRepository.GetByIdAsync(userId.Value);

        if (user == null)
            throw new UnauthorizedException(_localization.Get(MessageKeys.UserNotFound));

        // Validate refresh token
        if (user.ResetPasswordToken != request.RefreshToken)
            throw new UnauthorizedException(_localization.Get(MessageKeys.InvalidRefreshToken));

        // Check if user is still active
        if (user.Deactivate == true || user.Lock == true)
            throw new UnauthorizedException(_localization.Get(MessageKeys.AccountDeactivated));

        // Generate new tokens
        var newToken = _jwtService.GenerateToken(user);
        var newRefreshToken = _jwtService.GenerateRefreshToken();
        var refreshTokenExpiration = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpirationInDays);

        // Update refresh token in database
        await _userRepository.UpdateRefreshTokenAsync(user.UserId, newRefreshToken, refreshTokenExpiration);

        // Log successful token refresh
        await _activityLogService.LogAuthenticationAsync(EventType.TokenRefresh, true);

        // Decrypt user data for response
        var decryptedName = DecryptIfEncrypted(user.Name);
        var decryptedUserLogin = DecryptIfEncrypted(user.UserLogin);
        var decryptedEmail = DecryptIfEncrypted(user.EmailAddress);

        return new LoginResponseDto
        {
            UserId = user.UserId,
            Name = decryptedName ?? string.Empty,
            UserLogin = decryptedUserLogin ?? string.Empty,
            EmailAddress = decryptedEmail,
            Token = newToken,
            TokenExpiration = DateTime.UtcNow.AddMinutes(_jwtSettings.TokenExpirationInMinutes),
            RefreshToken = newRefreshToken,
            RefreshTokenExpiration = refreshTokenExpiration
        };
    }

    public async Task<UserProfileDto?> GetCurrentUserAsync(int userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
            return null;

        return new UserProfileDto
        {
            UserId = user.UserId,
            Name = DecryptIfEncrypted(user.Name) ?? string.Empty,
            UserLogin = DecryptIfEncrypted(user.UserLogin) ?? string.Empty,
            EmailAddress = DecryptIfEncrypted(user.EmailAddress),
            Phone = user.Phone,
            Mobile = user.Mobile
        };
    }

    /// <summary>
    /// Decrypts a value if it appears to be encrypted, otherwise returns as-is
    /// </summary>
    private string? DecryptIfEncrypted(string? value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        try
        {
            if (EncryptionHelper.IsEncrypted(value))
                return EncryptionHelper.Decrypt(value);
            return value;
        }
        catch
        {
            // If decryption fails, return original value
            return value;
        }
    }
}
