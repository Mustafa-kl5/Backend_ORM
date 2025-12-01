using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanNotifiProcTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BcmBiaPlanTestId { get; set; }

    public string TestResult { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanNotifiProcDetailsTest> BcmBiaPlanNotifiProcDetailsTests { get; set; } = new List<BcmBiaPlanNotifiProcDetailsTest>();

    public virtual BcmBiaPlanTest BcmBiaPlanTest { get; set; } = null!;
}
