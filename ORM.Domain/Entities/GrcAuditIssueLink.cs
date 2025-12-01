using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcAuditIssueLink
{
    public int IssueLinkId { get; set; }

    public int ParentAfiIssueId { get; set; }

    public int RelatedAfiIssueId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditFinding ParentAfiIssue { get; set; } = null!;

    public virtual GrcAuditFinding RelatedAfiIssue { get; set; } = null!;
}
