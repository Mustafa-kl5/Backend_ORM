using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRbaProcessRiskAsesmnt
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int? ProcessDetailId { get; set; }

    public int? RiskProcessLinkId { get; set; }

    public int? RiskElementId { get; set; }

    public int RiskImpactId { get; set; }

    public int RiskOccurenceId { get; set; }

    public int InherentRiskScore { get; set; }

    public int RiskCategoryId { get; set; }

    public int? FinancialImpact { get; set; }

    public int? GrossLossExpectation { get; set; }

    public string? Comments { get; set; }

    public int InherentRiskValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmInherentRiskScore InherentRiskScoreNavigation { get; set; } = null!;

    public virtual ICollection<OrmRbaProcessRiskAsesmntWork> OrmRbaProcessRiskAsesmntWorks { get; set; } = new List<OrmRbaProcessRiskAsesmntWork>();

    public virtual OrmProcessDetail? ProcessDetail { get; set; }

    public virtual OrmRiskCategory RiskCategory { get; set; } = null!;

    public virtual OrmRiskElement? RiskElement { get; set; }

    public virtual OrmRiskImpact RiskImpact { get; set; } = null!;

    public virtual OrmRiskOccurence RiskOccurence { get; set; } = null!;

    public virtual OrmProcessRiskLink? RiskProcessLink { get; set; }
}
