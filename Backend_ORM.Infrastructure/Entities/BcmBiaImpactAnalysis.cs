using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaImpactAnalysis
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaFunctionId { get; set; }

    public int ImpactAnalysisId { get; set; }

    public int CrticalityId { get; set; }

    public string ImpactAnswer { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanImpactAnalysisDetailsTest> BcmBiaPlanImpactAnalysisDetailsTests { get; set; } = new List<BcmBiaPlanImpactAnalysisDetailsTest>();

    public virtual BcmBiaFuntion BiaFunction { get; set; } = null!;

    public virtual BcmBiaCriticality Crticality { get; set; } = null!;

    public virtual BcmImpactAnalysis ImpactAnalysis { get; set; } = null!;
}
