using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaDueAsesmnt
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TaskId { get; set; }

    public int? DepartmentId { get; set; }

    public int? BranchId { get; set; }

    public int? DivisionId { get; set; }

    public int? UserId { get; set; }

    public int StatusId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();

    public virtual OrmTaskStatus Status { get; set; } = null!;

    public virtual OrmRcsaTask Task { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
