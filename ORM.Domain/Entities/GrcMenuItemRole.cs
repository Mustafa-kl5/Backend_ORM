using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcMenuItemRole
{
    public int Id { get; set; }

    public int MenuItemId { get; set; }

    public int RoleCode { get; set; }

    public virtual GrcMenuItem MenuItem { get; set; } = null!;
}
