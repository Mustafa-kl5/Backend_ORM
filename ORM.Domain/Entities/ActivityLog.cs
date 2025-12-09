using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ActivityLog
{
    public long ActivityLogId { get; set; }

    public string? TenantId { get; set; }

    public string? Environment { get; set; }

    public int? SourceSystemId { get; set; }

    public int? SourceModuleId { get; set; }

    public string EventType { get; set; } = null!;

    public string ActionType { get; set; } = null!;

    public string? UserId { get; set; }

    public string? UserName { get; set; }

    public bool? IsSuccess { get; set; }

    public string? FailureReason { get; set; }

    public string? TargetObject { get; set; }

    public string? TargetObjectId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public DateTime TimestampUtc { get; set; }

    public string? ServerName { get; set; }

    public string? SourceIp { get; set; }

    public string? DeviceInfo { get; set; }

    public Guid CorrelationId { get; set; }

    public string? RequestId { get; set; }

    public string? AdditionalData { get; set; }

    public virtual SourceModule? SourceModule { get; set; }

    public virtual SourceSystem? SourceSystem { get; set; }
}
