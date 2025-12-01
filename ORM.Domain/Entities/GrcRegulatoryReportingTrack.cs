using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRegulatoryReportingTrack
{
    public int ReportingId { get; set; }

    public int? DepDepartmentId { get; set; }

    public string? ReportName { get; set; }

    public string? Periodic { get; set; }

    public int? Day { get; set; }

    public int? Month { get; set; }

    public string? Weekday { get; set; }

    public int? SreSubRegulationId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool? BreachFlag { get; set; }

    public DateTime? ManualStartingDate { get; set; }

    public int? ManualRepeatMonth { get; set; }

    public bool SelfAssessmentFlag { get; set; }

    public int? IssuerId { get; set; }

    public string? Comment { get; set; }

    public string? DepCheckerReason { get; set; }

    public string? CompCheckerReason { get; set; }

    public int? DepMakerId { get; set; }

    public int AccountId { get; set; }

    public string? CompMakerReason { get; set; }

    public int? DepCheckerAnswer { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment? DepDepartment { get; set; }

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcRegulatoryReportingAttachment> GrcRegulatoryReportingAttachments { get; set; } = new List<GrcRegulatoryReportingAttachment>();

    public virtual GrcIssuer? Issuer { get; set; }

    public virtual GrcSubRegulation? SreSubRegulation { get; set; }
}
