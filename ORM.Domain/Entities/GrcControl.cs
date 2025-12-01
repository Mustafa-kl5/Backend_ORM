using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcControl
{
    public int ControlId { get; set; }

    public string ControlName { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ControlsWeight { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcControlBusinessUnit> GrcControlBusinessUnits { get; set; } = new List<GrcControlBusinessUnit>();

    public virtual ICollection<GrcControlClassSubjective> GrcControlClassSubjectives { get; set; } = new List<GrcControlClassSubjective>();

    public virtual ICollection<GrcRegulationControl> GrcRegulationControls { get; set; } = new List<GrcRegulationControl>();

    public virtual ICollection<GrcTestDetailControl> GrcTestDetailControls { get; set; } = new List<GrcTestDetailControl>();
}
