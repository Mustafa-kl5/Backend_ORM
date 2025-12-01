using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaFuntion
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TypeId { get; set; }

    public int OwnerId { get; set; }

    public int CrticalityId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntionProcess> BcmBiaFuntionProcesses { get; set; } = new List<BcmBiaFuntionProcess>();

    public virtual ICollection<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; } = new List<BcmBiaFuntionsBusinessUnit>();

    public virtual ICollection<BcmBiaImpactAnalysis> BcmBiaImpactAnalyses { get; set; } = new List<BcmBiaImpactAnalysis>();

    public virtual ICollection<BcmBiaPlan> BcmBiaPlans { get; set; } = new List<BcmBiaPlan>();

    public virtual ICollection<BcmBiaRecovery> BcmBiaRecoveries { get; set; } = new List<BcmBiaRecovery>();

    public virtual ICollection<BcmBiaResource> BcmBiaResources { get; set; } = new List<BcmBiaResource>();

    public virtual BcmBiaCriticality Crticality { get; set; } = null!;

    public virtual GrcUser Owner { get; set; } = null!;

    public virtual BcmBiaType Type { get; set; } = null!;
}
