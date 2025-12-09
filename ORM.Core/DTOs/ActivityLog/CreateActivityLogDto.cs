namespace ORM.Core.DTOs.ActivityLog;

public class CreateActivityLogDto
{
    public string? TenantId { get; set; }
    public string? Environment { get; set; }
    public int? SourceSystemId { get; set; }
    public int? SourceModuleId { get; set; }
    public EventType EventType { get; set; }
    public ActionType ActionType { get; set; }
    public string? UserId { get; set; }
    public string? UserName { get; set; }
    public string? TargetObject { get; set; }
    public string? TargetObjectId { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? AdditionalData { get; set; }
    public bool? IsSuccess { get; set; }
    public string? FailureReason { get; set; }
    public Guid? CorrelationId { get; set; }
}
