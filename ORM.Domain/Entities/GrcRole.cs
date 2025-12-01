using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRole
{
    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public int? SecurityLevel { get; set; }

    public bool? ViewAll { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcRolePage> GrcRolePages { get; set; } = new List<GrcRolePage>();

    public virtual ICollection<GrcUserRole> GrcUserRoles { get; set; } = new List<GrcUserRole>();
}
