using System.ComponentModel.DataAnnotations;

namespace ORM.Core.DTOs.Auth;

public class RefreshTokenRequestDto
{
    [Required(ErrorMessage = "Token is required")]
    public string Token { get; set; } = string.Empty;

    [Required(ErrorMessage = "Refresh token is required")]
    public string RefreshToken { get; set; } = string.Empty;
}
