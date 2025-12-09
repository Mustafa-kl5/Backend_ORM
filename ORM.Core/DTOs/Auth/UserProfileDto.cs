namespace ORM.Core.DTOs.Auth;

/// <summary>
/// DTO for user profile response
/// </summary>
public class UserProfileDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserLogin { get; set; } = string.Empty;
    public string? EmailAddress { get; set; }
    public string? Phone { get; set; }
    public string? Mobile { get; set; }
}
