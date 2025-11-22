using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class WblowerCase
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public string? Reference { get; set; }

    public DateTime Date { get; set; }

    public string? Name { get; set; }

    public string? ConcernedUsers { get; set; }

    public string? Subject { get; set; }

    public string? CaseDescription { get; set; }

    public DateTime? IncidentDate { get; set; }

    public string? IncidentDescription { get; set; }

    public string? IncidentOther { get; set; }

    public string? IncidentReason { get; set; }

    public bool ChkRelatedPolicies { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ReportChannelId { get; set; }

    public int? ReportClassId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcWblowerCaseBranch> GrcWblowerCaseBranches { get; set; } = new List<GrcWblowerCaseBranch>();

    public virtual WblowerReportChannel? ReportChannel { get; set; }

    public virtual WblowerReportClass? ReportClass { get; set; }

    public virtual Status Status { get; set; } = null!;

    public virtual ICollection<WblowerCaseAction> WblowerCaseActions { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseAttachment> WblowerCaseAttachments { get; set; } = new List<WblowerCaseAttachment>();

    public virtual ICollection<WblowerCaseBreachDepartment> WblowerCaseBreachDepartments { get; set; } = new List<WblowerCaseBreachDepartment>();

    public virtual ICollection<WblowerCaseClassPosition> WblowerCaseClassPositions { get; set; } = new List<WblowerCaseClassPosition>();

    public virtual ICollection<WblowerCaseDepartment> WblowerCaseDepartments { get; set; } = new List<WblowerCaseDepartment>();

    public virtual ICollection<WblowerCaseEscPosition> WblowerCaseEscPositions { get; set; } = new List<WblowerCaseEscPosition>();

    public virtual ICollection<WblowerCaseResolution> WblowerCaseResolutions { get; set; } = new List<WblowerCaseResolution>();

    public virtual ICollection<WblowerCaseRisk> WblowerCaseRisks { get; set; } = new List<WblowerCaseRisk>();
}
