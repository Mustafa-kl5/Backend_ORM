using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRisk
{
    public int RiskId { get; set; }

    public string RiskName { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? RiskWeight { get; set; }

    public int RiskNatureRuleId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcAuditFindingsRisk> GrcAuditFindingsRisks { get; set; } = new List<GrcAuditFindingsRisk>();

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRisks { get; set; } = new List<GrcRegulationRisk>();

    public virtual ICollection<GrcRiskFinAppetite> GrcRiskFinAppetites { get; set; } = new List<GrcRiskFinAppetite>();

    public virtual ICollection<GrcRiskSubjective> GrcRiskSubjectives { get; set; } = new List<GrcRiskSubjective>();

    public virtual GrcRiskNatureRule RiskNatureRule { get; set; } = null!;
}
