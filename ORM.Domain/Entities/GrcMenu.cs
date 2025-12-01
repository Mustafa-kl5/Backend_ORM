using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcMenu
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public int? Seq { get; set; }

    public virtual ICollection<GrcMenuRole> GrcMenuRoles { get; set; } = new List<GrcMenuRole>();
}
