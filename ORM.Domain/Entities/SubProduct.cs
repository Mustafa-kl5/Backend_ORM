using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class SubProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string Description { get; set; } = null!;

    public int? Sla { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ExtendedSla { get; set; }

    public int? AllowedResolvedPeriod { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual ICollection<GrcSubProductsDepartment> GrcSubProductsDepartments { get; set; } = new List<GrcSubProductsDepartment>();

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<RccmCmTaskDetail> RccmCmTaskDetails { get; set; } = new List<RccmCmTaskDetail>();
}
