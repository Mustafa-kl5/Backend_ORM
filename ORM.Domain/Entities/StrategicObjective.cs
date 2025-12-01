using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class StrategicObjective
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? EndDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<StrategicProgram> StrategicPrograms { get; set; } = new List<StrategicProgram>();
}
