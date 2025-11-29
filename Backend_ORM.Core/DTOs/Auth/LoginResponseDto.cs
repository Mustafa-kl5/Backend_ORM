namespace Backend_ORM.Core.DTOs.Auth;

/// <summary>
/// DTO for login response containing JWT token and user information
/// </summary>
public class LoginResponseDto
{
    /// <summary>
    /// JWT access token
    /// </summary>
    public string AccessToken { get; set; } = null!;

    /// <summary>
    /// Token expiration time in seconds
    /// </summary>
    public int ExpiresIn { get; set; }

    /// <summary>
    /// Token type (always "Bearer")
    /// </summary>
    public string TokenType { get; set; } = "Bearer";

    /// <summary>
    /// Current user information
    /// </summary>
    public CurrentUserDto User { get; set; } = null!;
}
