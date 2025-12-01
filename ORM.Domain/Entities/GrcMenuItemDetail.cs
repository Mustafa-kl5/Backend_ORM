using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcMenuItemDetail
{
    public int Id { get; set; }

    public int MenuItemId { get; set; }

    public string Description { get; set; } = null!;

    public string Link { get; set; } = null!;

    public int? Seq { get; set; }

    public virtual ICollection<GrcMenuDetailsRole> GrcMenuDetailsRoles { get; set; } = new List<GrcMenuDetailsRole>();
}
