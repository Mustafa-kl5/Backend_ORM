using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcStagingSubRegulation
{
    public int Id { get; set; }

    public int? RegulationId { get; set; }

    public int? ApprovedById { get; set; }

    public int StagingStatusId { get; set; }

    public string SubRegulationRef { get; set; } = null!;

    public string? ReferenceDescription { get; set; }

    public string? ReferenceOtherLang { get; set; }

    public string? SubjectOtherLang { get; set; }

    public bool? Formula { get; set; }

    public string CalendarOccurance { get; set; } = null!;

    public int? CalendarDay { get; set; }

    public int? CalendarMonth { get; set; }

    public string? Source { get; set; }

    public int? ReleaseNumber { get; set; }

    public string? FileName { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string? Comment { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Notes { get; set; }

    public DateTime IssueDate { get; set; }

    public int? RegulationTypeId { get; set; }

    public int AccountId { get; set; }

    public string? AiscanReference { get; set; }

    public string? AiscanReferenceDescription { get; set; }

    public string? AiscanOtherReference { get; set; }

    public string? AiscanOtherSubject { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser? ApprovedBy { get; set; }

    public virtual ICollection<GrcRegulationsStagingAttachment> GrcRegulationsStagingAttachments { get; set; } = new List<GrcRegulationsStagingAttachment>();

    public virtual GrcStagingRegulation? Regulation { get; set; }

    public virtual GrcRegulationType? RegulationType { get; set; }

    public virtual GrcStagingStatus StagingStatus { get; set; } = null!;
}
