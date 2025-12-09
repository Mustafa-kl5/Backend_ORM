namespace ORM.Core.DTOs.Migration;

/// <summary>
/// Response DTO for migration operation
/// </summary>
public class MigrationResponseDto
{
    public int TotalUsers { get; set; }
    public int SuccessfullyMigrated { get; set; }
    public int Failed { get; set; }
    public List<MigrationErrorDto> Errors { get; set; } = new();
}

/// <summary>
/// Error details for failed migration
/// </summary>
public class MigrationErrorDto
{
    public int UserId { get; set; }
    public string? UserLogin { get; set; }
    public string ErrorMessage { get; set; } = string.Empty;
}
