using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCrimeStatus
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<GrcCrimeSituation> GrcCrimeSituations { get; set; } = new List<GrcCrimeSituation>();
}
