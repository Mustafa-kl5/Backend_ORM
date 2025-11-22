using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaPlanProcessTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanScheduleId { get; set; }

    public int? TestResultId { get; set; }

    public string? TestComment { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual BcmBiaPlanSchedule BiaPlanSchedule { get; set; } = null!;

    public virtual BcmTestResultStatus? TestResult { get; set; }
}
