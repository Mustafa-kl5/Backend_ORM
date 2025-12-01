using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmProduct
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int VendorId { get; set; }

    public int Slaid { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public string? ContactPerson { get; set; }

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmPlanVendorList> BcmPlanVendorLists { get; set; } = new List<BcmPlanVendorList>();

    public virtual BcmSlaDetail Sla { get; set; } = null!;

    public virtual BcmVendor Vendor { get; set; } = null!;
}
