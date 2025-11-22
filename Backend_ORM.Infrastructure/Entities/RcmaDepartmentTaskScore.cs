using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaDepartmentTaskScore
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int DepartmentId { get; set; }

    public int Score { get; set; }

    public DateTime CompleteDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual RcmaTask Task { get; set; } = null!;
}
