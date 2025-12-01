using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanVendorDetailsTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanVendorTestId { get; set; }

    public string SupplierRole { get; set; } = null!;

    public string Vendor { get; set; } = null!;

    public string Product { get; set; } = null!;

    public string SlaDetails { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlanVendorTest BiaPlanVendorTest { get; set; } = null!;
}
