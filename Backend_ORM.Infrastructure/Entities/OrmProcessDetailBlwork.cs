using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcessDetailBlwork
{
    public int Id { get; set; }

    public int ProcessDetailId { get; set; }

    public int? ProcessDetailBlid { get; set; }

    public int? RiskElementId { get; set; }

    public int? RiskImpactId { get; set; }

    public int? RiskOccurenceId { get; set; }

    public int? InherentRiskScore { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual OrmInherentRiskScore? InherentRiskScoreNavigation { get; set; }

    public virtual ICollection<OrmProcessDetailBlworkDetail> OrmProcessDetailBlworkDetails { get; set; } = new List<OrmProcessDetailBlworkDetail>();

    public virtual OrmProcessDetail ProcessDetail { get; set; } = null!;

    public virtual OrmProcessBlLink? ProcessDetailBl { get; set; }

    public virtual OrmRiskElement? RiskElement { get; set; }

    public virtual OrmRiskImpact? RiskImpact { get; set; }

    public virtual OrmRiskOccurence? RiskOccurence { get; set; }
}
