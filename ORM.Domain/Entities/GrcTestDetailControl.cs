using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcTestDetailControl
{
    public int Id { get; set; }

    public int ControlId { get; set; }

    public int? ControlSubjectiveId { get; set; }

    public int? ControlProbClassId { get; set; }

    public int TestDetailId { get; set; }

    public int? ControlValue { get; set; }

    public int? CopyControlValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcControl Control { get; set; } = null!;

    public virtual GrcControlPropabilityClass? ControlProbClass { get; set; }

    public virtual GrcControlClassSubjective? ControlSubjective { get; set; }

    public virtual GrcTestDetail TestDetail { get; set; } = null!;
}
