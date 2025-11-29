using System.ComponentModel.DataAnnotations;

namespace Backend_ORM.Core.DTOs.Auth;

/// <summary>
/// DTO for login request
/// </summary>
public class LoginRequestDto
{
    /// <summary>
    /// User's login username
    /// </summary>
    [Required(ErrorMessage = "Username is required")]
    public string Username { get; set; } = null!;

    /// <summary>
    /// User's password
    /// </summary>
    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = null!;
}
