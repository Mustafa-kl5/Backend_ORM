namespace Backend_ORM.Core.DTOs.LinkProcess;

/// <summary>
/// DTO for process list with hierarchy and link counts
/// </summary>
public class ProcessListDto
{
    public int ProcessDetailsId { get; set; }
    public string Category { get; set; } = string.Empty;
    public string Process { get; set; } = string.Empty;
    public string SubProcess { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public int BusinessLineCount { get; set; }
    public int RiskCount { get; set; }
    public int ControlCount { get; set; }
}

/// <summary>
/// DTO for paginated process list response
/// </summary>
public class ProcessListResponseDto
{
    public List<ProcessListDto> Processes { get; set; } = new();
    public int TotalRecords { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
