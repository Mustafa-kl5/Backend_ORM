using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationRisk
{
    public int RegulationRiskId { get; set; }

    public int? RiskId { get; set; }

    public int? SubRegulationId { get; set; }

    public int? RiskValue { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? RiskFinancialId { get; set; }

    public int? RiskSubjectiveId { get; set; }

    public int? PenaltyValue { get; set; }

    public int? RiskFinancialStep1Id { get; set; }

    public int? RiskClassId { get; set; }

    public int? RiskImpactId { get; set; }

    public int? RiskOccurrenceId { get; set; }

    public virtual GrcRisk? Risk { get; set; }

    public virtual GrcRiskClassification? RiskClass { get; set; }

    public virtual GrcRiskFinAppetite? RiskFinancial { get; set; }

    public virtual GrcRiskFinAppetite? RiskFinancialStep1 { get; set; }

    public virtual RcmriskImpact? RiskImpact { get; set; }

    public virtual RcmriskOccurence? RiskOccurrence { get; set; }

    public virtual GrcRiskSubjective? RiskSubjective { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }
}
