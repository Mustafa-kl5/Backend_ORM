using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanScheduleId { get; set; }

    public int? TestResultId { get; set; }

    public string TestResult { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanElementTest> BcmBiaPlanElementTests { get; set; } = new List<BcmBiaPlanElementTest>();

    public virtual ICollection<BcmBiaPlanNotifiProcTest> BcmBiaPlanNotifiProcTests { get; set; } = new List<BcmBiaPlanNotifiProcTest>();

    public virtual ICollection<BcmBiaPlanRecTeamTest> BcmBiaPlanRecTeamTests { get; set; } = new List<BcmBiaPlanRecTeamTest>();

    public virtual ICollection<BcmBiaPlanVendorTest> BcmBiaPlanVendorTests { get; set; } = new List<BcmBiaPlanVendorTest>();

    public virtual BcmBiaPlanSchedule BiaPlanSchedule { get; set; } = null!;

    public virtual BcmTestResultStatus? TestResultNavigation { get; set; }
}
