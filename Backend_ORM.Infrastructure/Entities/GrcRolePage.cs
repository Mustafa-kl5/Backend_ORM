using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRolePage
{
    public int RolePageId { get; set; }

    public int RoleRoleCode { get; set; }

    public int PagPageId { get; set; }

    public bool UpdateAllowed { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcPage PagPage { get; set; } = null!;

    public virtual GrcRole RoleRoleCodeNavigation { get; set; } = null!;
}
