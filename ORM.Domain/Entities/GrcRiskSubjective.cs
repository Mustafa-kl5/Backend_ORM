using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRiskSubjective
{
    public int Id { get; set; }

    public int RiskClassificationId { get; set; }

    public int RiskId { get; set; }

    public string? TrustImpactDesc { get; set; }

    public string? RiskImpactDesc { get; set; }

    public string? StakeHolderImpactDesc { get; set; }

    public int CreatedBy { get; set; }

    public DateTime Creationdate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRisks { get; set; } = new List<GrcRegulationRisk>();

    public virtual GrcRisk Risk { get; set; } = null!;

    public virtual GrcRiskClassification RiskClassification { get; set; } = null!;
}
