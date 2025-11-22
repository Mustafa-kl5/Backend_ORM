using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmResourceDetail
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Reference { get; set; } = null!;

    public int ResourceTypeId { get; set; }

    public int FunctionId { get; set; }

    public int FunctionDetailId { get; set; }

    public int LocationId { get; set; }

    public int BussinessImpactId { get; set; }

    public string Threat { get; set; } = null!;

    public int RiskOccurenceId { get; set; }

    public int RiskImpactId { get; set; }

    public int InherentRiskId { get; set; }

    public int RtoPeriodId { get; set; }

    public int RpoPeriodId { get; set; }

    public int? RtoDucration { get; set; }

    public string? RtoBackupStrategy { get; set; }

    public int? RpoDuration { get; set; }

    public string? RpoRecoveryStrategy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaResource> BcmBiaResources { get; set; } = new List<BcmBiaResource>();

    public virtual ICollection<BcmResourceDetailsControl> BcmResourceDetailsControls { get; set; } = new List<BcmResourceDetailsControl>();

    public virtual ICollection<BcmResourceDetailsRisk> BcmResourceDetailsRisks { get; set; } = new List<BcmResourceDetailsRisk>();

    public virtual BcmBusinessImpact BussinessImpact { get; set; } = null!;

    public virtual BcmFunction Function { get; set; } = null!;

    public virtual BcmFunctionDetail FunctionDetail { get; set; } = null!;

    public virtual OrmInherentRiskScore InherentRisk { get; set; } = null!;

    public virtual BcmLocation Location { get; set; } = null!;

    public virtual BcmResourceType ResourceType { get; set; } = null!;

    public virtual OrmRiskImpact RiskImpact { get; set; } = null!;

    public virtual OrmRiskOccurence RiskOccurence { get; set; } = null!;

    public virtual BcmPeriod RpoPeriod { get; set; } = null!;

    public virtual BcmPeriod RtoPeriod { get; set; } = null!;
}
