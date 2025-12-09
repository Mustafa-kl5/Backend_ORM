using System.ComponentModel.DataAnnotations;

namespace ORM.Core.DTOs.Auth;

public class LoginRequestDto
{
    [Required(ErrorMessage = "User login is required")]
    public string UserLogin { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string UserPassword { get; set; } = string.Empty;
}
