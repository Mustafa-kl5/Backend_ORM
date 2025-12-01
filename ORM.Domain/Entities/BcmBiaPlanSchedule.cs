using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanSchedule
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanId { get; set; }

    public int StatusId { get; set; }

    public int? PeriodId { get; set; }

    public int? TestResultId { get; set; }

    public int? OvarlapApproveById { get; set; }

    public bool Ovarlap { get; set; }

    public int? OwnerId { get; set; }

    public DateTime ScheduleDate { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? CommencedDate { get; set; }

    public bool? BusinessAsUsual { get; set; }

    public string? Duration { get; set; }

    public string? TestingComments { get; set; }

    public DateTime? CompletedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanImpactAnalysisTest> BcmBiaPlanImpactAnalysisTests { get; set; } = new List<BcmBiaPlanImpactAnalysisTest>();

    public virtual ICollection<BcmBiaPlanProcessTest> BcmBiaPlanProcessTests { get; set; } = new List<BcmBiaPlanProcessTest>();

    public virtual ICollection<BcmBiaPlanRecoveryTest> BcmBiaPlanRecoveryTests { get; set; } = new List<BcmBiaPlanRecoveryTest>();

    public virtual ICollection<BcmBiaPlanResourceTest> BcmBiaPlanResourceTests { get; set; } = new List<BcmBiaPlanResourceTest>();

    public virtual ICollection<BcmBiaPlanTest> BcmBiaPlanTests { get; set; } = new List<BcmBiaPlanTest>();

    public virtual BcmBiaPlan BiaPlan { get; set; } = null!;

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual GrcUser? OvarlapApproveBy { get; set; }

    public virtual GrcUser? Owner { get; set; }

    public virtual BcmPeriod? Period { get; set; }

    public virtual BcmStatus Status { get; set; } = null!;

    public virtual BcmTestResultStatus? TestResult { get; set; }
}
