using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanVendorTest
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

    public virtual BcmBiaPlanTest BcmBiaPlanTest { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanVendorDetailsTest> BcmBiaPlanVendorDetailsTests { get; set; } = new List<BcmBiaPlanVendorDetailsTest>();
}
