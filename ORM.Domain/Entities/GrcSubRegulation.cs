using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcSubRegulation
{
    public int SubRegulationId { get; set; }

    public int? RegRegulationId { get; set; }

    public string SubRegulationRef { get; set; } = null!;

    public string? ReferenceDescription { get; set; }

    public int IssueYear { get; set; }

    public bool Formula { get; set; }

    public string? CalenderOccurance { get; set; }

    public int? CalenderDay { get; set; }

    public int? CalenderMonth { get; set; }

    public int? RiskLevel { get; set; }

    public int? RiskClassification { get; set; }

    public int? ControlClassification { get; set; }

    public int? BreachCount { get; set; }

    public int? ThresholdWarning { get; set; }

    public DateTime? EndDate { get; set; }

    public string? WeekDay { get; set; }

    public string? Notes { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? RegulationTypeId { get; set; }

    public string? ReferenceOtherLang { get; set; }

    public string? SubjectOtherLang { get; set; }

    public string? Processed { get; set; }

    public DateTime? IssueDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public string? ExamReq { get; set; }

    public int? ApprovedById { get; set; }

    public DateTime? ManualStartingDate { get; set; }

    public int? ManualRepeatMonth { get; set; }

    public string? StagingEditReference { get; set; }

    public string? StagingEditDescription { get; set; }

    public string? StaginEditOtherLangRef { get; set; }

    public string? StagingEditOtherLangDesc { get; set; }

    public int ArticleSeq { get; set; }

    public int? StagingEditSubRegulationTypeId { get; set; }

    public DateTime? StagingEditIssueDate { get; set; }

    public string? StagingEditNote { get; set; }

    public int? AccountId { get; set; }

    public string? AiscanReferenceDescription { get; set; }

    public string? AiscanReference { get; set; }

    public string? AiscanOtherReference { get; set; }

    public string? AiscanOtherSubject { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual GrcUser? ApprovedBy { get; set; }

    public virtual ICollection<CompRootCause> CompRootCauses { get; set; } = new List<CompRootCause>();

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual ICollection<GrcAuditFindingSubRegulation> GrcAuditFindingSubRegulations { get; set; } = new List<GrcAuditFindingSubRegulation>();

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDepartmentSubRegulation> GrcDepartmentSubRegulations { get; set; } = new List<GrcDepartmentSubRegulation>();

    public virtual ICollection<GrcRegulationControl> GrcRegulationControls { get; set; } = new List<GrcRegulationControl>();

    public virtual ICollection<GrcRegulationRisk> GrcRegulationRisks { get; set; } = new List<GrcRegulationRisk>();

    public virtual ICollection<GrcRegulationsAttachment> GrcRegulationsAttachments { get; set; } = new List<GrcRegulationsAttachment>();

    public virtual ICollection<GrcRegulatoryReportingTrack> GrcRegulatoryReportingTracks { get; set; } = new List<GrcRegulatoryReportingTrack>();

    public virtual ICollection<GrcSubRegulationDepartmentActivity> GrcSubRegulationDepartmentActivities { get; set; } = new List<GrcSubRegulationDepartmentActivity>();

    public virtual ICollection<GrcSubRegulationFunction> GrcSubRegulationFunctions { get; set; } = new List<GrcSubRegulationFunction>();

    public virtual ICollection<GrcSubRegulationRule> GrcSubRegulationRules { get; set; } = new List<GrcSubRegulationRule>();

    public virtual ICollection<GrcTestDetail> GrcTestDetails { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<RcamAdvisoryRequestSubRequlation> RcamAdvisoryRequestSubRequlations { get; set; } = new List<RcamAdvisoryRequestSubRequlation>();

    public virtual ICollection<RccmCmTaskDetail> RccmCmTaskDetails { get; set; } = new List<RccmCmTaskDetail>();

    public virtual GrcRegulation? RegRegulation { get; set; }

    public virtual GrcRegulationType? RegulationType { get; set; }

    public virtual ICollection<WblowerCaseResolution> WblowerCaseResolutions { get; set; } = new List<WblowerCaseResolution>();
}
