using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class StrategicProgram
{
    public int Id { get; set; }

    public int StrateigcObjectivesId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime? EndDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmRiskElement> OrmRiskElements { get; set; } = new List<OrmRiskElement>();

    public virtual ICollection<StrategicProgramProject> StrategicProgramProjects { get; set; } = new List<StrategicProgramProject>();

    public virtual StrategicObjective StrateigcObjectives { get; set; } = null!;
}
