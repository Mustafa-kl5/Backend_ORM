using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditRiskRating
{
    public int Id { get; set; }

    public string RiskRating { get; set; } = null!;

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcEntityAssessmentDetail> GrcEntityAssessmentDetails { get; set; } = new List<GrcEntityAssessmentDetail>();
}
