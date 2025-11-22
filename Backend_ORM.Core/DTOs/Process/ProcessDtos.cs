namespace Backend_ORM.Core.DTOs.Process;

/// <summary>
/// DTO for Process List Item (Level 2)
/// </summary>
public class ProcessLevelTwoListDto
{
    public int Id { get; set; }
    public int ProcessTypeId { get; set; }
    public string ProcessTypeDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? AttachedFile { get; set; }
    public DateTime CreationDate { get; set; }
    public int SubProcessCount { get; set; }
}

/// <summary>
/// DTO for Process Detail (Single Record - Level 2)
/// </summary>
public class ProcessLevelTwoDetailDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ProcessTypeId { get; set; }
    public string ProcessTypeDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? AttachedFile { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public int? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public int SubProcessCount { get; set; }
}

/// <summary>
/// Request DTO for Creating Process (Level 2)
/// </summary>
public class CreateProcessLevelTwoDto
{
    public int ProcessTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? AttachedFile { get; set; }
}

/// <summary>
/// Request DTO for Updating Process (Level 2)
/// </summary>
public class UpdateProcessLevelTwoDto
{
    public int ProcessTypeId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string? AttachedFile { get; set; }
}

/// <summary>
/// Response DTO for Process List with Pagination (Level 2)
/// </summary>
public class ProcessLevelTwoListResponseDto
{
    public List<ProcessLevelTwoListDto> Processes { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

/// <summary>
/// Response DTO for Create/Update/Delete operations (Level 2)
/// </summary>
public class ProcessLevelTwoOperationResponseDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
}
