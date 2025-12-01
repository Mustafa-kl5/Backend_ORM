using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcControlClassSubjective
{
    public int Id { get; set; }

    public int ControlId { get; set; }

    public int ControlProbabilityId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcControl Control { get; set; } = null!;

    public virtual GrcControlPropabilityClass ControlProbability { get; set; } = null!;

    public virtual ICollection<GrcRegulationControl> GrcRegulationControls { get; set; } = new List<GrcRegulationControl>();

    public virtual ICollection<GrcTestDetailControl> GrcTestDetailControls { get; set; } = new List<GrcTestDetailControl>();
}
