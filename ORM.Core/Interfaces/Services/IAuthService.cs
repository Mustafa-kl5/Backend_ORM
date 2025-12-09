using ORM.Core.DTOs.Auth;

namespace ORM.Core.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
    Task<UserProfileDto?> GetCurrentUserAsync(int userId);
}
