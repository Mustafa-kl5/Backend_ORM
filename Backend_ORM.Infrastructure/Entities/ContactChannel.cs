using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ContactChannel
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();
}
