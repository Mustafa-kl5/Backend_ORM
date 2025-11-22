using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditFindingAttachment
{
    public int Id { get; set; }

    public int IssueId { get; set; }

    public string AttachedFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAuditFinding Issue { get; set; } = null!;
}
