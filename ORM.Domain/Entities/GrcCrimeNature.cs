using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCrimeNature
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Nature { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime Createddate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcCrimeSituation> GrcCrimeSituations { get; set; } = new List<GrcCrimeSituation>();
}
