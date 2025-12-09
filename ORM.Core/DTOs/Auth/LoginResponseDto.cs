namespace ORM.Core.DTOs.Auth;

public class LoginResponseDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserLogin { get; set; } = string.Empty;
    public string? EmailAddress { get; set; }
    public string Token { get; set; } = string.Empty;
    public DateTime TokenExpiration { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime RefreshTokenExpiration { get; set; }
}
