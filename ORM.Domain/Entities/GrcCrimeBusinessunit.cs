using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCrimeBusinessunit
{
    public int Id { get; set; }

    public int CrimeId { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public int CreationBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcCrimeSituation Crime { get; set; } = null!;

    public virtual GrcDepartment? Department { get; set; }
}
