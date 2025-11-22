namespace Backend_ORM.Core.DTOs.Process;

/// <summary>
/// DTO for Process Detail List Item
/// </summary>
public class ProcessDetailListDto
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public string SubjectDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
}

/// <summary>
/// DTO for Process Detail (Single Record)
/// </summary>
public class ProcessDetailItemDto
{
    public int Id { get; set; }
    public int AccountId { get; set; }
    public int SubjectId { get; set; }
    public string SubjectDescription { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreatedBy { get; set; }
    public DateTime CreationDate { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedDate { get; set; }
}

/// <summary>
/// Request DTO for Creating Process Detail
/// </summary>
public class CreateProcessDetailDto
{
    public int SubjectId { get; set; }
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Request DTO for Updating Process Detail
/// </summary>
public class UpdateProcessDetailDto
{
    public int SubjectId { get; set; }
    public string Description { get; set; } = string.Empty;
}

/// <summary>
/// Response DTO for Process Detail List with Pagination
/// </summary>
public class ProcessDetailListResponseDto
{
    public List<ProcessDetailListDto> ProcessDetails { get; set; } = new();
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}

/// <summary>
/// Response DTO for Create/Update/Delete operations
/// </summary>
public class ProcessDetailOperationResponseDto
{
    public int Id { get; set; }
    public string Message { get; set; } = string.Empty;
}
