using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Code { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Institute> Institutes { get; set; } = new List<Institute>();
}
