using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class CompBreachDepartment
{
    public int Id { get; set; }

    public int CustomerCallId { get; set; }

    public int DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public bool BreachFlag { get; set; }

    public int CreatedBy { get; set; }

    public DateTime Creationdate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual CompCustomerCall CustomerCall { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;
}
