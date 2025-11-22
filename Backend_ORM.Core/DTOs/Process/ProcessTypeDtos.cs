namespace Backend_ORM.Core.DTOs.Process;

/// <summary>
/// DTO for ProcessType List Item
/// </summary>
public class ProcessTypeListDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public int ProcessCount { get; set; }
}

/// <summary>
/// DTO for ProcessType Detail (Single Record)
/// </summary>
public class ProcessTypeDetailDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public int? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedDate { get; set; }
    public int ProcessCount { get; set; }
}

/// <summary>
/// Request DTO for Creating ProcessType
/// </summary>
public class CreateProcessTypeDto
{
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Request DTO for Updating ProcessType
/// </summary>
public class UpdateProcessTypeDto
{
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Response DTO for ProcessType List with Pagination
/// </summary>
public class ProcessTypeListResponseDto
{
    public List<ProcessTypeListDto> ProcessTypes { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

/// <summary>
/// Response DTO for Create/Update/Delete operations
/// </summary>
public class ProcessTypeOperationResponseDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
}
