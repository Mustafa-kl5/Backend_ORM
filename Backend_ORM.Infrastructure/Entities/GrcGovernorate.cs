using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcGovernorate
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public int Code { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();
}
