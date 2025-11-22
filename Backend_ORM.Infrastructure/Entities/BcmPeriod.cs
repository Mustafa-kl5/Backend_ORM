using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmPeriod
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTestRpoPeriodTests { get; set; } = new List<BcmBiaPlanRecoveryDetailsTest>();

    public virtual ICollection<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTestRpoPeriods { get; set; } = new List<BcmBiaPlanRecoveryDetailsTest>();

    public virtual ICollection<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTestRtoPeriodTests { get; set; } = new List<BcmBiaPlanRecoveryDetailsTest>();

    public virtual ICollection<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTestRtoPeriods { get; set; } = new List<BcmBiaPlanRecoveryDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTestRpoPeriodTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTestRpoPeriods { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTestRtoPeriodTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTestRtoPeriods { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanSchedules { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmBiaRecovery> BcmBiaRecoveryRpoPeriods { get; set; } = new List<BcmBiaRecovery>();

    public virtual ICollection<BcmBiaRecovery> BcmBiaRecoveryRtoPeriods { get; set; } = new List<BcmBiaRecovery>();

    public virtual ICollection<BcmResourceDetail> BcmResourceDetailRpoPeriods { get; set; } = new List<BcmResourceDetail>();

    public virtual ICollection<BcmResourceDetail> BcmResourceDetailRtoPeriods { get; set; } = new List<BcmResourceDetail>();
}
