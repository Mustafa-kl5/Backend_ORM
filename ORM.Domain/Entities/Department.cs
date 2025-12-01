using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class Department
{
    public int Id { get; set; }

    public int InstituteId { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int Manager { get; set; }

    public int Deputy { get; set; }

    public bool? IsBranchDepartment { get; set; }

    public bool? IsRisk { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Institute Institute { get; set; } = null!;

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
