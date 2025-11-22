using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditFinding
{
    public int IssueId { get; set; }

    public int AreAuditReportId { get; set; }

    public int? SreRegulationId { get; set; }

    public int? RegRegulationId { get; set; }

    public int? AscSeverityId { get; set; }

    public int? RtRiskType { get; set; }

    public int? TdTestDetailId { get; set; }

    public string? IssueReference { get; set; }

    public string? IssueSummary { get; set; }

    public string? FindingDescription { get; set; }

    public string? Risk { get; set; }

    public string? Recommendations { get; set; }

    public string? Comments { get; set; }

    public DateTime? InitialEtaDate { get; set; }

    public int? OccuranceCount { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? BreachesDescription { get; set; }

    public int? Riskclassificationid { get; set; }

    public string? ResponsibleParty { get; set; }

    public string? AttachFile { get; set; }

    public int? AuditRiskRatingId { get; set; }

    public int? StatusId { get; set; }

    public bool? BreachFlag { get; set; }

    public int? CompletedBy { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditReport AreAuditReport { get; set; } = null!;

    public virtual GrcAuditSeverityClass? AscSeverity { get; set; }

    public virtual ICollection<AuditLossImpact> AuditLossImpacts { get; set; } = new List<AuditLossImpact>();

    public virtual GrcAuditRiskRating? AuditRiskRating { get; set; }

    public virtual GrcUser? CompletedByNavigation { get; set; }

    public virtual ICollection<GrcAuditDepBranch> GrcAuditDepBranches { get; set; } = new List<GrcAuditDepBranch>();

    public virtual ICollection<GrcAuditEscalationAction> GrcAuditEscalationActions { get; set; } = new List<GrcAuditEscalationAction>();

    public virtual ICollection<GrcAuditFindingAttachment> GrcAuditFindingAttachments { get; set; } = new List<GrcAuditFindingAttachment>();

    public virtual ICollection<GrcAuditFindingSubRegulation> GrcAuditFindingSubRegulations { get; set; } = new List<GrcAuditFindingSubRegulation>();

    public virtual ICollection<GrcAuditFindingsRisk> GrcAuditFindingsRisks { get; set; } = new List<GrcAuditFindingsRisk>();

    public virtual ICollection<GrcAuditIssueLink> GrcAuditIssueLinkParentAfiIssues { get; set; } = new List<GrcAuditIssueLink>();

    public virtual ICollection<GrcAuditIssueLink> GrcAuditIssueLinkRelatedAfiIssues { get; set; } = new List<GrcAuditIssueLink>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual GrcRegulation? RegRegulation { get; set; }

    public virtual GrcRiskClassification? Riskclassification { get; set; }

    public virtual GrcRiskType? RtRiskTypeNavigation { get; set; }

    public virtual GrcSubRegulation? SreRegulation { get; set; }

    public virtual GrcEscalationStatus? Status { get; set; }

    public virtual GrcTestDetail? TdTestDetail { get; set; }
}
