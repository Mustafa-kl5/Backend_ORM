using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcGoalsBu
{
    public int Id { get; set; }

    public int? GoalId { get; set; }

    public int? DepartmentId { get; set; }

    public int? DivisionId { get; set; }

    public int? BranchId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual GrcGoal? Goal { get; set; }
}
