using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationControl
{
    public int RegulationControlId { get; set; }

    public int? ControlId { get; set; }

    public int? SubRegulationId { get; set; }

    public int? ControlValue { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ControlSubjectiveId { get; set; }

    public int? ControlProbClassId { get; set; }

    public int? CopyControlValue { get; set; }

    public virtual GrcControl? Control { get; set; }

    public virtual GrcControlPropabilityClass? ControlProbClass { get; set; }

    public virtual GrcControlClassSubjective? ControlSubjective { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }
}
