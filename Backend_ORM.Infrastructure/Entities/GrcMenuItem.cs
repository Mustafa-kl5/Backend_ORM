using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcMenuItem
{
    public int Id { get; set; }

    public int MenuId { get; set; }

    public string Description { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int? Seq { get; set; }

    public virtual ICollection<GrcMenuItemRole> GrcMenuItemRoles { get; set; } = new List<GrcMenuItemRole>();
}
