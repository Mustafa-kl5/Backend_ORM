using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcDepartmentSubRegulation
{
    public int DepartmentSubRegulationId { get; set; }

    public int? DepartmentId { get; set; }

    public int? SubRegulationId { get; set; }

    public int ResponsibilityLevel { get; set; }

    public bool? BreachFlag { get; set; }

    public bool? ThresholdFlag { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdateBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool? ExamFollowupFlag { get; set; }

    public bool? EmailSentFlag { get; set; }

    public string? Notes { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }
}
