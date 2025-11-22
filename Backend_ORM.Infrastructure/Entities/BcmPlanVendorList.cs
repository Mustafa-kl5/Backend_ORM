using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmPlanVendorList
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanId { get; set; }

    public int SupplierRoleId { get; set; }

    public int VendorId { get; set; }

    public int ProductId { get; set; }

    public int SlaDetailId { get; set; }

    public string Mobile { get; set; } = null!;

    public string ContactPerson { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlan BiaPlan { get; set; } = null!;

    public virtual BcmProduct Product { get; set; } = null!;

    public virtual BcmSlaDetail SlaDetail { get; set; } = null!;

    public virtual BcmSupplierRole SupplierRole { get; set; } = null!;

    public virtual BcmVendor Vendor { get; set; } = null!;
}
