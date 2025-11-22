using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRiskProfile
{
    public int Id { get; set; }

    public int RiskProfileYearId { get; set; }

    public int DepartmentId { get; set; }

    public string RiskType { get; set; } = null!;

    public string Month { get; set; } = null!;

    public int EventCount { get; set; }

    public DateTime LastRunDate { get; set; }

    public bool? YearClosed { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? SaproceedsArticle { get; set; }

    public string? SaansweredArticles { get; set; }

    public string? ExminedArticles { get; set; }

    public string? ExminedAnsweredArticles { get; set; }

    public bool? EomClose { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual GrcCalendarYear RiskProfileYear { get; set; } = null!;
}
