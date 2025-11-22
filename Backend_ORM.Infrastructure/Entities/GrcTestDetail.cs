using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcTestDetail
{
    public int TestDetailsId { get; set; }

    public int ThTestHeaderId { get; set; }

    public int SubSubRegulationId { get; set; }

    public string? Status { get; set; }

    public string? Finding { get; set; }

    public string? Recommendation { get; set; }

    public DateTime? DueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? DepartmentId { get; set; }

    public int? ManagerApproveId { get; set; }

    public int? ComplianceApproveId { get; set; }

    public int? StatusId { get; set; }

    public string? Reason { get; set; }

    public string? Comment { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? CompApprove { get; set; }

    public string? ReminderEmail1 { get; set; }

    public string? ReminderEmail2 { get; set; }

    public string? CompEmail { get; set; }

    public bool? ExamFollowupFlag { get; set; }

    public DateTime? ExamFollowupDueDate { get; set; }

    public string? ExamFollowupDesc { get; set; }

    public bool? ExamFollowupEmail { get; set; }

    public int? StagingComplianceApproveId { get; set; }

    public int? StagingCompApprove { get; set; }

    public string? ComplianceReq { get; set; }

    public virtual GrcUser? ComplianceApprove { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcTestAttachment> GrcTestAttachments { get; set; } = new List<GrcTestAttachment>();

    public virtual ICollection<GrcTestDetailAction> GrcTestDetailActions { get; set; } = new List<GrcTestDetailAction>();

    public virtual ICollection<GrcTestDetailControl> GrcTestDetailControls { get; set; } = new List<GrcTestDetailControl>();

    public virtual GrcUser? ManagerApprove { get; set; }

    public virtual GrcUser? StagingComplianceApprove { get; set; }

    public virtual GrcComply? StatusNavigation { get; set; }

    public virtual GrcSubRegulation SubSubRegulation { get; set; } = null!;

    public virtual GrcTestHeader ThTestHeader { get; set; } = null!;
}
