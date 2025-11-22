namespace Backend_ORM.Core.DTOs.LinkProcess;

/// <summary>
/// Response DTO for single delete operations
/// </summary>
public class DeleteResponseDto
{
    public bool Deleted { get; set; }
    public int RemainingLinks { get; set; }
    public int TotalDeleted { get; set; } // For cascade deletes (e.g., risk with controls)
}
