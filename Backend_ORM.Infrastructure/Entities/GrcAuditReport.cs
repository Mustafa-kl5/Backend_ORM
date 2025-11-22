using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditReport
{
    public int AuditReportId { get; set; }

    public int CouCountryId { get; set; }

    public int? AsoAuditSourceId { get; set; }

    public int? DepAuditDept { get; set; }

    public int? BraBranchId { get; set; }

    public int? ThTestHeaderId { get; set; }

    public string? ReferenceNumber { get; set; }

    public DateTime? ReportIssueDate { get; set; }

    public DateTime? VisitStartDate { get; set; }

    public DateTime? VisitEndDate { get; set; }

    public DateTime? AuditCoverageStart { get; set; }

    public DateTime? AuditCoverageEnd { get; set; }

    public string? ExamNote { get; set; }

    public string? ReviewerName { get; set; }

    public string? Source { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? ScopeProcess { get; set; }

    public string? AttachFile { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditSource? AsoAuditSource { get; set; }

    public virtual GrcBranch? BraBranch { get; set; }

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual GrcDepartment? DepAuditDeptNavigation { get; set; }

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual GrcTestHeader? ThTestHeader { get; set; }
}
