using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcMenuRole
{
    public int Id { get; set; }

    public int RoleCode { get; set; }

    public int MenuId { get; set; }

    public virtual GrcMenu Menu { get; set; } = null!;
}
