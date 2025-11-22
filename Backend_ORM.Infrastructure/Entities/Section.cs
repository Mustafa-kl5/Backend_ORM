using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class Section
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int DepartmentId { get; set; }

    public int Manager { get; set; }

    public int Deputy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Department Department { get; set; } = null!;
}
