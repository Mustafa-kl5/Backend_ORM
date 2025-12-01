using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcDepartmentBreachsSource
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public string? Source { get; set; }

    public int? BreachCount { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcDepartment Department { get; set; } = null!;
}
