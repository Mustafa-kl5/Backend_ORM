using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCalendarDepartment
{
    public int CalendarId { get; set; }

    public int DepDepartmentId { get; set; }

    public int? SreSubRegulationId { get; set; }

    public int? RegRepId { get; set; }

    public DateTime CalendarDate { get; set; }

    public string WeekDay { get; set; } = null!;

    public int? AfiIssueId { get; set; }

    public int? BrBranchId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcAuditFinding? AfiIssue { get; set; }

    public virtual GrcBranch? BrBranch { get; set; }

    public virtual GrcDepartment DepDepartment { get; set; } = null!;

    public virtual GrcRegulatoryReportingTrack? RegRep { get; set; }

    public virtual GrcSubRegulation? SreSubRegulation { get; set; }
}
