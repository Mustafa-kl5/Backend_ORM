using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcMenuDetailsRole
{
    public int Id { get; set; }

    public int MenuDetailId { get; set; }

    public int RoleCode { get; set; }

    public virtual GrcMenuItemDetail MenuDetail { get; set; } = null!;
}
