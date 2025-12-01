using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcStagingRegulation
{
    public int Id { get; set; }

    public int CountryId { get; set; }

    public int IssuerId { get; set; }

    public int StagingStatusId { get; set; }

    public int RegulationTypeId { get; set; }

    public int? ApprovedById { get; set; }

    public string Reference { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string? ReferenceOtherLang { get; set; }

    public string? SubjectOtherLang { get; set; }

    public DateTime IssueDate { get; set; }

    public DateTime EffectiveDate { get; set; }

    public string Source { get; set; } = null!;

    public string? ReleaseNumber { get; set; }

    public string? UploadFileName { get; set; }

    public DateTime? ApproveDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Comment { get; set; }

    public int? CategoryId { get; set; }

    public int? AccountId { get; set; }

    public string? AiscanReference { get; set; }

    public string? AiscanReferenceDescription { get; set; }

    public string? AiscanOtherReference { get; set; }

    public string? AiscanOtherSubject { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual GrcUser? ApprovedBy { get; set; }

    public virtual GrcCountry Country { get; set; } = null!;

    public virtual ICollection<GrcRegulationUserAccess> GrcRegulationUserAccesses { get; set; } = new List<GrcRegulationUserAccess>();

    public virtual ICollection<GrcRegulationsStagingAttachment> GrcRegulationsStagingAttachments { get; set; } = new List<GrcRegulationsStagingAttachment>();

    public virtual ICollection<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; } = new List<GrcStagingSubRegulation>();

    public virtual GrcIssuer Issuer { get; set; } = null!;

    public virtual GrcRegulationType RegulationType { get; set; } = null!;

    public virtual GrcStagingStatus StagingStatus { get; set; } = null!;
}
