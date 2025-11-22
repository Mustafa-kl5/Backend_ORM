using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcControlUserAccess
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int UserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
