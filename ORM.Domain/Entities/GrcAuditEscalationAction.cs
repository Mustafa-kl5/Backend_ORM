using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcAuditEscalationAction
{
    public int ActionId { get; set; }

    public int FinIssueId { get; set; }

    public int UseActionUserId { get; set; }

    public int? UseApprovedBy { get; set; }

    public bool? IsApproved { get; set; }

    public int LineNumber { get; set; }

    public string ActionTaken { get; set; } = null!;

    public DateTime ExpectedResolvedDate { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? StatusId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditFinding FinIssue { get; set; } = null!;

    public virtual GrcEscalationStatus? Status { get; set; }

    public virtual GrcUser UseActionUser { get; set; } = null!;

    public virtual GrcUser? UseApprovedByNavigation { get; set; }
}
