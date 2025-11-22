namespace Backend_ORM.Core.DTOs.LinkProcess;

/// <summary>
/// Request DTO for batch delete operations
/// </summary>
public class BatchDeleteRequestDto
{
    public int ProcessDetailsId { get; set; }
    public List<int> BusinessLineIds { get; set; } = new();
    public List<int> RiskIds { get; set; } = new();
    public List<int> ControlIds { get; set; } = new();
}

/// <summary>
/// Response DTO for batch delete operations
/// </summary>
public class BatchDeleteResponseDto
{
    public int TotalDeleted { get; set; }
    public int BusinessLinesDeleted { get; set; }
    public int RisksDeleted { get; set; }
    public int ControlsDeleted { get; set; }
    public List<DeleteFailureDto> Failures { get; set; } = new();
}

/// <summary>
/// DTO for individual delete failure
/// </summary>
public class DeleteFailureDto
{
    public string Type { get; set; } = string.Empty; // "BusinessLine", "Risk", "Control"
    public int Id { get; set; }
    public string Reason { get; set; } = string.Empty;
}
