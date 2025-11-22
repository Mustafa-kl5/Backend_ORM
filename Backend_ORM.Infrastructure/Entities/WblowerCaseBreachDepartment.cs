using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class WblowerCaseBreachDepartment
{
    public int Id { get; set; }

    public int WblowerCaseId { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public bool IsBreach { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual WblowerCase WblowerCase { get; set; } = null!;
}
