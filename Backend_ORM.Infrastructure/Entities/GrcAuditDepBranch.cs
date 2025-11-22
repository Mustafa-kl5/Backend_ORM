using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditDepBranch
{
    public int DepartmentAuditId { get; set; }

    public int? DepDepartmentId { get; set; }

    public int? BraBranchId { get; set; }

    public int AfiIssueId { get; set; }

    public bool? BreachFlag { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAuditFinding AfiIssue { get; set; } = null!;

    public virtual GrcBranch? BraBranch { get; set; }

    public virtual GrcDepartment? DepDepartment { get; set; }
}
