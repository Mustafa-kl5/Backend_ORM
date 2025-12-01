using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanProcessRiskControlTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanProcessTestId { get; set; }

    public int ProcessId { get; set; }

    public int RiskId { get; set; }

    public int ControlId { get; set; }

    public int? TestResultId { get; set; }

    public string? TestComment { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlanProcessTest BiaPlanProcessTest { get; set; } = null!;

    public virtual OrmControlCategoryElement Control { get; set; } = null!;

    public virtual OrmProcessDetail Process { get; set; } = null!;

    public virtual OrmRiskElement Risk { get; set; } = null!;

    public virtual BcmTestResultStatus? TestResult { get; set; }
}
