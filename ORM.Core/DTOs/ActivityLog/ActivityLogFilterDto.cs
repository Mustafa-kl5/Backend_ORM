namespace ORM.Core.DTOs.ActivityLog;

public class ActivityLogFilterDto
{
    public string? TenantId { get; set; }
    public int? SourceSystemId { get; set; }
    public int? SourceModuleId { get; set; }
    public EventType? EventType { get; set; }
    public ActionType? ActionType { get; set; }
    public string? UserId { get; set; }
    public bool? IsSuccess { get; set; }
    public string? TargetObject { get; set; }
    public string? TargetObjectId { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public Guid? CorrelationId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}
