using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRbaRisk
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int RiskCategoryId { get; set; }

    public int RiskElementId { get; set; }

    public int RiskImpactId { get; set; }

    public int RiskOccurenceId { get; set; }

    public int InherentRiskScore { get; set; }

    public string? Comments { get; set; }

    public int InherentRiskValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmInherentRiskScore InherentRiskScoreNavigation { get; set; } = null!;

    public virtual ICollection<OrmrbaRiskWork> OrmrbaRiskWorks { get; set; } = new List<OrmrbaRiskWork>();

    public virtual OrmRiskCategory RiskCategory { get; set; } = null!;

    public virtual OrmRiskElement RiskElement { get; set; } = null!;

    public virtual OrmRiskImpact RiskImpact { get; set; } = null!;

    public virtual OrmRiskOccurence RiskOccurence { get; set; } = null!;
}
