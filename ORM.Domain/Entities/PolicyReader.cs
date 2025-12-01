using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class PolicyReader
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int PolicyId { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;
}
