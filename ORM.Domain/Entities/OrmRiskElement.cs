using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRiskElement
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int RiskCategoryId { get; set; }

    public string? Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public string? RiskDetails { get; set; }

    public string? RiskReasons { get; set; }

    public string? RiskConsequences { get; set; }

    public int? OperationalGoalsId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual ICollection<BcmResourceDetailsRisk> BcmResourceDetailsRisks { get; set; } = new List<BcmResourceDetailsRisk>();

    public virtual StrategicProgram? OperationalGoals { get; set; }

    public virtual ICollection<OrmLossEventRisk> OrmLossEventRisks { get; set; } = new List<OrmLossEventRisk>();

    public virtual ICollection<OrmProcessDetailBlwork> OrmProcessDetailBlworks { get; set; } = new List<OrmProcessDetailBlwork>();

    public virtual ICollection<OrmProcessRiskLink> OrmProcessRiskLinks { get; set; } = new List<OrmProcessRiskLink>();

    public virtual ICollection<OrmRbaControlAsesmnt> OrmRbaControlAsesmnts { get; set; } = new List<OrmRbaControlAsesmnt>();

    public virtual ICollection<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; } = new List<OrmRbaProcessRiskAsesmnt>();

    public virtual ICollection<OrmRbaRisk> OrmRbaRisks { get; set; } = new List<OrmRbaRisk>();

    public virtual ICollection<OrmRcsaDueAsesmntRisk> OrmRcsaDueAsesmntRisks { get; set; } = new List<OrmRcsaDueAsesmntRisk>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual OrmRiskCategory RiskCategory { get; set; } = null!;
}
