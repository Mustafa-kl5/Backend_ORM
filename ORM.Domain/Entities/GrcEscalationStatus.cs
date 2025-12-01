using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcEscalationStatus
{
    public int StatusId { get; set; }

    public string StatusCode { get; set; } = null!;

    public int? StatusLevel { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcAuditEscalationAction> GrcAuditEscalationActions { get; set; } = new List<GrcAuditEscalationAction>();

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcEscalationAction> GrcEscalationActions { get; set; } = new List<GrcEscalationAction>();

    public virtual ICollection<GrcEscalationMonitor> GrcEscalationMonitors { get; set; } = new List<GrcEscalationMonitor>();
}
