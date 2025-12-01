using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRiskFinAppetite
{
    public int Id { get; set; }

    public int RiskClassificationId { get; set; }

    public int RiskId { get; set; }

    public int GreaterthanValue { get; set; }

    public int LessThanValue { get; set; }

    public int? AnnualEstimatedBreach { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRiskRiskFinancialStep1s { get; set; } = new List<GrcRegulationRisk>();

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRiskRiskFinancials { get; set; } = new List<GrcRegulationRisk>();

    public virtual GrcRisk Risk { get; set; } = null!;

    public virtual GrcRiskClassification RiskClassification { get; set; } = null!;
}
