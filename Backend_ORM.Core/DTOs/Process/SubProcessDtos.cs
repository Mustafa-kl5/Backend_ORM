namespace Backend_ORM.Core.DTOs.Process;

/// <summary>
/// DTO for SubProcess List Item
/// </summary>
public class SubProcessLevelTwoListDto
{
    public int Id { get; set; }
    public int ProcessId { get; set; }
    public string ProcessDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public int DetailsCount { get; set; }
}

/// <summary>
/// DTO for SubProcess Detail (Single Record)
/// </summary>
public class SubProcessLevelTwoDetailDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int ProcessId { get; set; }
    public string ProcessDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public int DetailsCount { get; set; }
}

/// <summary>
/// Request DTO for Creating SubProcess
/// </summary>
public class CreateSubProcessDto
{
    public int ProcessId { get; set; }
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Request DTO for Updating SubProcess
/// </summary>
public class UpdateSubProcessDto
{
    public int ProcessId { get; set; }
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Response DTO for SubProcess List with Pagination
/// </summary>
public class SubProcessLevelTwoListResponseDto
{
    public List<SubProcessLevelTwoListDto> SubProcesses { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

/// <summary>
/// Response DTO for Create/Update/Delete operations
/// </summary>
public class SubProcessLevelTwoOperationResponseDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
}
