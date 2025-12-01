using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcDepartmentRegulationsMatrix
{
    public int Id { get; set; }

    public int RegulationId { get; set; }

    public int DepartmentId { get; set; }

    public int? RiskLevel { get; set; }

    public int? RiskClassification { get; set; }

    public int? ControlClassification { get; set; }

    public int? ThresholdWarning { get; set; }

    public int? BreachCount { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual GrcRegulation Regulation { get; set; } = null!;
}
