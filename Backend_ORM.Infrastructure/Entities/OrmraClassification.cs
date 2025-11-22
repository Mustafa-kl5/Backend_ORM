using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmraClassification
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateOnly? LastUpdateDate { get; set; }

    public string? ClassColor { get; set; }
}
