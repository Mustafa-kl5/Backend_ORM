using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcControlPropabilityClass
{
    public int CpProbabilityId { get; set; }

    public string CpName { get; set; } = null!;

    public string CpDescription { get; set; } = null!;

    public int CpUpperValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? ClassColor { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcControlClassSubjective> GrcControlClassSubjectives { get; set; } = new List<GrcControlClassSubjective>();

    public virtual ICollection<GrcRegulationControl> GrcRegulationControls { get; set; } = new List<GrcRegulationControl>();

    public virtual ICollection<GrcTestDetailControl> GrcTestDetailControls { get; set; } = new List<GrcTestDetailControl>();
}
