using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.Auth;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for authentication operations
/// </summary>
public interface IAuthService
{
    /// <summary>
    /// Authenticates a user with username and password
    /// </summary>
    Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginRequestDto request);

    /// <summary>
    /// Validates a JWT token and returns user information
    /// </summary>
    Task<ApiResponse<CurrentUserDto>> ValidateTokenAsync(string token);
}
