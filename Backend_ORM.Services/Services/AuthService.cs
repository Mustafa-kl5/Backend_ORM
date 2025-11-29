using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.Auth;
using Backend_ORM.Core.Helpers;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Core.Settings;
using Backend_ORM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service for handling authentication operations
/// </summary>
public class AuthService : IAuthService
{
    private readonly ORMContext _context;
    private readonly JwtSettings _jwtSettings;
    private readonly EncryptionHelper _encryptionHelper;
    private readonly ILogger<AuthService> _logger;

    public AuthService(
        ORMContext context,
        IOptions<JwtSettings> jwtSettings,
        EncryptionHelper encryptionHelper,
        ILogger<AuthService> logger)
    {
        _context = context;
        _jwtSettings = jwtSettings.Value;
        _encryptionHelper = encryptionHelper;
        _logger = logger;
    }

    /// <summary>
    /// Authenticates a user with username and password
    /// </summary>
    public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request)
    {
        try
        {
            // Encrypt the username to search in database (stored encrypted)
            var encryptedUsername = _encryptionHelper.Encrypt(request.Username);

            // Find user by username (try both encrypted and plain for backward compatibility)
            var user = await _context.GrcUsers
                .Include(u => u.Account)
                .FirstOrDefaultAsync(u =>
                    u.UserLogin == encryptedUsername ||
                    u.UserLogin == request.Username);

            if (user == null)
            {
                _logger.LogWarning("Login attempt failed: User not found for username {Username}", request.Username);
                return ApiResponse<LoginResponseDto>.ErrorResponse("Invalid username or password");
            }

            // Check if user is deactivated or locked
            if (user.Deactivate == true || user.OrmDeactivate == true)
            {
                _logger.LogWarning("Login attempt failed: User {UserId} is deactivated", user.UserId);
                return ApiResponse<LoginResponseDto>.ErrorResponse("User account is deactivated");
            }

            if (user.Lock == true || user.OrmLock == true)
            {
                _logger.LogWarning("Login attempt failed: User {UserId} is locked", user.UserId);
                return ApiResponse<LoginResponseDto>.ErrorResponse("User account is locked");
            }

            // Verify password
            if (!PasswordHelper.VerifyPassword(request.Password, user.UserPassword))
            {
                _logger.LogWarning("Login attempt failed: Invalid password for user {UserId}", user.UserId);
                return ApiResponse<LoginResponseDto>.ErrorResponse("Invalid username or password");
            }

            // Generate JWT token
            var token = GenerateJwtToken(user);
            var expiresIn = _jwtSettings.ExpirationInMinutes * 60;

            // Create response with decrypted user information
            var currentUser = MapToCurrentUserDto(user);

            var response = new LoginResponseDto
            {
                AccessToken = token,
                ExpiresIn = expiresIn,
                TokenType = "Bearer",
                User = currentUser
            };

            _logger.LogInformation("User {UserId} logged in successfully", user.UserId);

            return ApiResponse<LoginResponseDto>.SuccessResponse(response, "Login successful");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during login for username {Username}", request.Username);
            return ApiResponse<LoginResponseDto>.ErrorResponse("An error occurred during login");
        }
    }

    /// <summary>
    /// Validates a JWT token and returns user information
    /// </summary>
    public async Task<ApiResponse<CurrentUserDto>> ValidateTokenAsync(string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidateAudience = true,
                ValidAudience = _jwtSettings.Audience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
            var userIdClaim = principal.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return ApiResponse<CurrentUserDto>.ErrorResponse("Invalid token");
            }

            var user = await _context.GrcUsers
                .Include(u => u.Account)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user == null)
            {
                return ApiResponse<CurrentUserDto>.ErrorResponse("User not found");
            }

            var currentUser = MapToCurrentUserDto(user);
            return ApiResponse<CurrentUserDto>.SuccessResponse(currentUser);
        }
        catch (SecurityTokenExpiredException)
        {
            return ApiResponse<CurrentUserDto>.ErrorResponse("Token has expired");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error validating token");
            return ApiResponse<CurrentUserDto>.ErrorResponse("Invalid token");
        }
    }

    private string GenerateJwtToken(Infrastructure.Entities.GrcUser user)
    {
        var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
        var securityKey = new SymmetricSecurityKey(key);
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Decrypt user information for claims
        var decryptedName = _encryptionHelper.Decrypt(user.Name);
        var decryptedEmail = user.EmailAddress != null ? _encryptionHelper.Decrypt(user.EmailAddress) : null;
        var decryptedUsername = _encryptionHelper.Decrypt(user.UserLogin);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Name, decryptedName),
            new Claim("username", decryptedUsername),
            new Claim("accountId", user.AccountId.ToString())
        };

        if (!string.IsNullOrEmpty(decryptedEmail))
        {
            claims.Add(new Claim(ClaimTypes.Email, decryptedEmail));
        }

        if (user.DepDepartmentId.HasValue)
        {
            claims.Add(new Claim("departmentId", user.DepDepartmentId.Value.ToString()));
        }

        if (user.AdminAccess == true)
        {
            claims.Add(new Claim("isAdmin", "true"));
        }

        var token = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationInMinutes),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private CurrentUserDto MapToCurrentUserDto(Infrastructure.Entities.GrcUser user)
    {
        return new CurrentUserDto
        {
            UserId = user.UserId,
            Name = _encryptionHelper.Decrypt(user.Name),
            UserLogin = _encryptionHelper.Decrypt(user.UserLogin),
            EmailAddress = user.EmailAddress != null ? _encryptionHelper.Decrypt(user.EmailAddress) : null,
            AccountId = user.AccountId,
            DepartmentId = user.DepDepartmentId,
            BranchId = user.BranchId,
            DivisionId = user.DivisionId,
            HasAdminAccess = user.AdminAccess == true,
            IsPasswordChangeRequired = user.IsPassMustChange == true,
            IsDefaultActionUser = user.DefaultActionUser == true,
            CanApproveEscalations = user.EscalationActionApproval == true,
            HasRegulatoryAccess = user.AddRegFlag == true,
            HasBreachManagementAccess = user.BreachManagementFlag == true,
            HasWhistleblowerAccess = user.WhistleManagementFlag == true,
            CanApproveStagingRegulations = user.ApproveStagingReg == true,
            HasRcmaAccess = user.RcmaFlag == true,
            HasRccmAccess = user.RccmFlag == true,
            HasAdvisoryAccess = user.AdvisoryFlag == true,
            JobTitleId = user.JobTitleId,
            LanguageCode = user.LanguageCode
        };
    }
}
