using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRiskClassification
{
    public int RiskClassificationId { get; set; }

    public string RiskName { get; set; } = null!;

    public string RiskDescription { get; set; } = null!;

    public int RiskUpperValue { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ExamPeriod { get; set; }

    public int? FreqLessThan { get; set; }

    public int? FreqGreaterThan { get; set; }

    public string? ClassColor { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRisks { get; set; } = new List<GrcRegulationRisk>();

    public virtual ICollection<GrcRiskFinAppetite> GrcRiskFinAppetites { get; set; } = new List<GrcRiskFinAppetite>();

    public virtual ICollection<GrcRiskSubjective> GrcRiskSubjectives { get; set; } = new List<GrcRiskSubjective>();
}
