using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcEscalationAction
{
    public int ActionId { get; set; }

    public int? EmoEscalationId { get; set; }

    public int? UseActionUserId { get; set; }

    public int? UseApprovedBy { get; set; }

    public bool? IsApproved { get; set; }

    public int? LineNumber { get; set; }

    public string? ActionTaken { get; set; }

    public DateTime? ExpectedResolvedDate { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public string? AttachedFile { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? EstStatusId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcEscalationMonitor? EmoEscalation { get; set; }

    public virtual GrcEscalationStatus? EstStatus { get; set; }

    public virtual GrcUser? UseActionUser { get; set; }

    public virtual GrcUser? UseApprovedByNavigation { get; set; }
}
