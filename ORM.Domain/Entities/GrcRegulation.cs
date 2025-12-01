using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRegulation
{
    public int RegulationId { get; set; }

    public int? CouCountryId { get; set; }

    public string Refrence { get; set; } = null!;

    public string? Subject { get; set; }

    public DateTime IssueDate { get; set; }

    public int IssueYear { get; set; }

    public int? Issuer { get; set; }

    public DateTime? EndDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? InstituteCategoryId { get; set; }

    public int? RegulationTypeId { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? ReferenceOtherLang { get; set; }

    public string? SubjectOtherLang { get; set; }

    public string? Processed { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? ApprovedById { get; set; }

    public string? StagingEditReference { get; set; }

    public string? StagingEditSubject { get; set; }

    public string? StagingEditOtherLangRef { get; set; }

    public string? StagingHeditOtherLangSubject { get; set; }

    public int RegulationSeq { get; set; }

    public int? StagingEditIssuerId { get; set; }

    public int? StagingEditRegulationTypeId { get; set; }

    public DateTime? StagingEditIssueDate { get; set; }

    public DateTime? StagingEditEffectiveDate { get; set; }

    public DateTime? StagingEditExpiryDate { get; set; }

    public int? StagingEditCategoryId { get; set; }

    public int? CategoryId { get; set; }

    public int? AccountId { get; set; }

    public string? AiscanReference { get; set; }

    public string? AiscanReferenceDescription { get; set; }

    public string? AiscanOtherReference { get; set; }

    public string? AiscanOtherSubject { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual GrcUser? ApprovedBy { get; set; }

    public virtual GrcRegulationCategory? Category { get; set; }

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual GrcCountry? CouCountry { get; set; }

    public virtual ICollection<GrcAuditFindingSubRegulation> GrcAuditFindingSubRegulations { get; set; } = new List<GrcAuditFindingSubRegulation>();

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDepartmentRegulationsMatrix> GrcDepartmentRegulationsMatrices { get; set; } = new List<GrcDepartmentRegulationsMatrix>();

    public virtual ICollection<GrcFinancialRefReg> GrcFinancialRefRegs { get; set; } = new List<GrcFinancialRefReg>();

    public virtual ICollection<GrcFinancialRegulationsUser> GrcFinancialRegulationsUsers { get; set; } = new List<GrcFinancialRegulationsUser>();

    public virtual ICollection<GrcRegulationLink> GrcRegulationLinkLinkRegulations { get; set; } = new List<GrcRegulationLink>();

    public virtual ICollection<GrcRegulationLink> GrcRegulationLinkRegulations { get; set; } = new List<GrcRegulationLink>();

    public virtual ICollection<GrcRegulationUserAccess> GrcRegulationUserAccesses { get; set; } = new List<GrcRegulationUserAccess>();

    public virtual ICollection<GrcRegulationsAttachment> GrcRegulationsAttachments { get; set; } = new List<GrcRegulationsAttachment>();

    public virtual ICollection<GrcSubRegulation> GrcSubRegulations { get; set; } = new List<GrcSubRegulation>();

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual GrcIssuer? IssuerNavigation { get; set; }

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual GrcRegulationType? RegulationType { get; set; }
}
