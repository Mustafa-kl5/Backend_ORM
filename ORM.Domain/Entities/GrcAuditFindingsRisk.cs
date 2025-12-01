using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcAuditFindingsRisk
{
    public int FinRiskId { get; set; }

    public int AfiIssueId { get; set; }

    public int RkRiskId { get; set; }

    public virtual GrcAuditFinding AfiIssue { get; set; } = null!;

    public virtual GrcRisk RkRisk { get; set; } = null!;
}
