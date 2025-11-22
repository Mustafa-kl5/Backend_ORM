using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcessControlLink
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProcessRiskLinkId { get; set; }

    public int ControlElementId { get; set; }

    public int? ControlDesignEffectId { get; set; }

    public int? ResidualRiskExposure { get; set; }

    public int? ResidualRiskQuadrantId { get; set; }

    public int? RbaRiskId { get; set; }

    public int? RbaProcessRiskAsesmntId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmControlDesignEffective? ControlDesignEffect { get; set; }

    public virtual OrmControlCategoryElement ControlElement { get; set; } = null!;

    public virtual ICollection<OrmRbaControlAsesmnt> OrmRbaControlAsesmnts { get; set; } = new List<OrmRbaControlAsesmnt>();

    public virtual ICollection<OrmRbaControlProcessControl> OrmRbaControlProcessControls { get; set; } = new List<OrmRbaControlProcessControl>();

    public virtual ICollection<OrmRbacontrolQuestAnswer> OrmRbacontrolQuestAnswers { get; set; } = new List<OrmRbacontrolQuestAnswer>();

    public virtual OrmProcessRiskLink ProcessRiskLink { get; set; } = null!;

    public virtual OrmResidualRiskExposure? ResidualRiskExposureNavigation { get; set; }

    public virtual OrmResidualRiskQuadrant? ResidualRiskQuadrant { get; set; }
}
