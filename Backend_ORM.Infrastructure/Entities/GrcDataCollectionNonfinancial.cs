using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDataCollectionNonfinancial
{
    public int CollectionId { get; set; }

    public int DepDepartmentId { get; set; }

    public int? SreSubRegulationId { get; set; }

    public int? RegRegulationId { get; set; }

    public int? RegRepId { get; set; }

    public int? UseApprovedBy { get; set; }

    public int? ComApprovedBy { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? EntryDate { get; set; }

    public int? ComplyStatusId { get; set; }

    public string? Reason { get; set; }

    public bool? ReminderEmail1 { get; set; }

    public bool? ReminderEmail2 { get; set; }

    public bool? ComplaintsEmail { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? AttachedFile { get; set; }

    public int? CompApprove { get; set; }

    public int? TestHeaderId { get; set; }

    public int? StagingCompApprovedBy { get; set; }

    public int? StagingCompApprove { get; set; }

    public string? DepCheckerReason { get; set; }

    public string? CompCheckerReason { get; set; }

    public int? DepMakerId { get; set; }

    public string? CompMakerReason { get; set; }

    public int? DepCheckerAnswer { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser? ComApprovedByNavigation { get; set; }

    public virtual GrcComply? ComplyStatus { get; set; }

    public virtual GrcDepartment DepDepartment { get; set; } = null!;

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCollectionQuestionnaire> GrcCollectionQuestionnaires { get; set; } = new List<GrcCollectionQuestionnaire>();

    public virtual ICollection<GrcDataCollectionAnswer> GrcDataCollectionAnswers { get; set; } = new List<GrcDataCollectionAnswer>();

    public virtual ICollection<GrcDataNonFinancialAttachFile> GrcDataNonFinancialAttachFiles { get; set; } = new List<GrcDataNonFinancialAttachFile>();

    public virtual GrcRegulation? RegRegulation { get; set; }

    public virtual GrcRegulatoryReportingTrack? RegRep { get; set; }

    public virtual GrcSubRegulation? SreSubRegulation { get; set; }

    public virtual GrcUser? StagingCompApprovedByNavigation { get; set; }

    public virtual GrcTestHeader? TestHeader { get; set; }

    public virtual GrcUser? UseApprovedByNavigation { get; set; }
}
