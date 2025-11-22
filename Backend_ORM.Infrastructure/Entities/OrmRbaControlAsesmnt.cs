using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRbaControlAsesmnt
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ControlProccessRiskId { get; set; }

    public int ControlDesignEffectId { get; set; }

    public int ResidualRiskExposure { get; set; }

    public int ResidualRiskQuadrantId { get; set; }

    public int? RiskElementId { get; set; }

    public int? RiskImpactId { get; set; }

    public int? RiskOccurenceId { get; set; }

    public int? InherentRiskScore { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmControlDesignEffective ControlDesignEffect { get; set; } = null!;

    public virtual OrmProcessControlLink ControlProccessRisk { get; set; } = null!;

    public virtual OrmInherentRiskScore? InherentRiskScoreNavigation { get; set; }

    public virtual OrmResidualRiskExposure ResidualRiskExposureNavigation { get; set; } = null!;

    public virtual OrmResidualRiskQuadrant ResidualRiskQuadrant { get; set; } = null!;

    public virtual OrmRiskElement? RiskElement { get; set; }

    public virtual OrmRiskImpact? RiskImpact { get; set; }

    public virtual OrmRiskOccurence? RiskOccurence { get; set; }
}
