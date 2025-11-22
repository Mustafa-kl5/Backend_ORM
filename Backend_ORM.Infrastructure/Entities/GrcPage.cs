using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcPage
{
    public int PageId { get; set; }

    public string PageUrl { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcRolePage> GrcRolePages { get; set; } = new List<GrcRolePage>();
}
