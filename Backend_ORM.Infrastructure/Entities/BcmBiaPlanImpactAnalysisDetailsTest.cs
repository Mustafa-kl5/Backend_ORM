using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaPlanImpactAnalysisDetailsTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanImpactTestId { get; set; }

    public int BiaImpactAnalysisId { get; set; }

    public string? ImpactAnalysisAnswer { get; set; }

    public int CriticalityIdAnswer { get; set; }

    public string? ImpactAnalysisTestResult { get; set; }

    public int CriticalityIdTestResult { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaImpactAnalysis BiaImpactAnalysis { get; set; } = null!;

    public virtual BcmBiaPlanImpactAnalysisTest BiaPlanImpactTest { get; set; } = null!;

    public virtual BcmBiaCriticality CriticalityIdAnswerNavigation { get; set; } = null!;

    public virtual BcmBiaCriticality CriticalityIdTestResultNavigation { get; set; } = null!;
}
