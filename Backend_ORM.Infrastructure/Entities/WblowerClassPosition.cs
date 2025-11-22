using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class WblowerClassPosition
{
    public int Id { get; set; }

    public int JobTitleId { get; set; }

    public int WblowerClassId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcJobTitle JobTitle { get; set; } = null!;

    public virtual ICollection<WblowerCaseClassPosition> WblowerCaseClassPositions { get; set; } = new List<WblowerCaseClassPosition>();

    public virtual WblowerClassification WblowerClass { get; set; } = null!;
}
