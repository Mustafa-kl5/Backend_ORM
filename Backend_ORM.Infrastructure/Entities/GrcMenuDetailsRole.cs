using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcMenuDetailsRole
{
    public int Id { get; set; }

    public int MenuDetailId { get; set; }

    public int RoleCode { get; set; }

    public virtual GrcMenuItemDetail MenuDetail { get; set; } = null!;
}
