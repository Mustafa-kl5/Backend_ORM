using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class StrategicProgramProject
{
    public int Id { get; set; }

    public int StrategiccProgramId { get; set; }

    public string ProjectCodeReference { get; set; } = null!;

    public string ProjectDescription { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcProjectDepartment> GrcProjectDepartments { get; set; } = new List<GrcProjectDepartment>();

    public virtual StrategicProgram StrategiccProgram { get; set; } = null!;
}
