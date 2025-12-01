using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcUserDepartment
{
    public int UserDepartmentId { get; set; }

    public int UserId { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
