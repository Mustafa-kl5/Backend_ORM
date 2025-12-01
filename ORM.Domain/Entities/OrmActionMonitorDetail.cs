using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmActionMonitorDetail
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ActionMonitorId { get; set; }

    public int ActionUserId { get; set; }

    public int ActionStatusId { get; set; }

    public string ActionComments { get; set; } = null!;

    public DateTime ExpectedResolvedDate { get; set; }

    public string? AttachedFile { get; set; }

    public string? RiskEvaluationClosure { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? AprovedBy { get; set; }

    public bool? DepartmentCheckerStatus { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmActionMonitor ActionMonitor { get; set; } = null!;

    public virtual OrmActionStatus ActionStatus { get; set; } = null!;

    public virtual GrcUser ActionUser { get; set; } = null!;

    public virtual GrcUser? AprovedByNavigation { get; set; }
}
