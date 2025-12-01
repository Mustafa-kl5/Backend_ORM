using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmProcessRiskLink
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProcessDetailId { get; set; }

    public int RiskCategoryId { get; set; }

    public int? RiskImpactId { get; set; }

    public int? RiskOccurenceId { get; set; }

    public int? InherentRiskScore { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmInherentRiskScore? InherentRiskScoreNavigation { get; set; }

    public virtual ICollection<OrmProcessControlLink> OrmProcessControlLinks { get; set; } = new List<OrmProcessControlLink>();

    public virtual ICollection<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; } = new List<OrmRbaProcessRiskAsesmnt>();

    public virtual OrmProcessDetail ProcessDetail { get; set; } = null!;

    public virtual OrmRiskElement RiskCategory { get; set; } = null!;

    public virtual OrmRiskImpact? RiskImpact { get; set; }

    public virtual OrmRiskOccurence? RiskOccurence { get; set; }
}
