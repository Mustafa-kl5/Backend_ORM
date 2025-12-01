using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmKriEntry
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int KriId { get; set; }

    public int? CurrencyId { get; set; }

    public int? Period { get; set; }

    public int? Amount { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public int? DivisionId { get; set; }

    public int? UserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public DateTime? AssessmentDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual Currency? Currency { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual OrmKri Kri { get; set; } = null!;

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual GrcUser? User { get; set; }
}
