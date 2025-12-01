using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanResourceTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanScheduleId { get; set; }

    public int? TestResultId { get; set; }

    public string? TestResult { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual BcmBiaPlanSchedule BiaPlanSchedule { get; set; } = null!;

    public virtual BcmTestResultStatus? TestResultNavigation { get; set; }
}
