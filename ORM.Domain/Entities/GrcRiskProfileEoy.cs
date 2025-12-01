using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRiskProfileEoy
{
    public int Id { get; set; }

    public int? CalendarYearId { get; set; }

    public int? DepartmentId { get; set; }

    public string? RiskImpact { get; set; }

    public string? SubRegulationId { get; set; }

    public string? ComplianceFeedback { get; set; }

    public string? RecommendedActionPlan { get; set; }

    public double? Rank { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment? Department { get; set; }
}
