using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string UserLogin { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public int? DepDepartmentId { get; set; }

    public int? CouCountryId { get; set; }

    public bool? DefaultActionUser { get; set; }

    public bool? EscalationActionApproval { get; set; }

    public bool? Deactivate { get; set; }

    public DateTime? PasswordChangedDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public bool? IsPassMustChange { get; set; }

    public string? ResetPasswordToken { get; set; }

    public string? DefaultRegLanguage { get; set; }

    public int? JobTitleId { get; set; }

    public bool? AddRegFlag { get; set; }

    public bool? BreachManagementFlag { get; set; }

    public bool? WhistleManagementFlag { get; set; }

    public int? LanguageCode { get; set; }

    public int? WhistleManagementActionFlag { get; set; }

    public bool? ApproveStagingReg { get; set; }

    public int? BranchId { get; set; }

    public bool? RcmaFlag { get; set; }

    public bool? RccmFlag { get; set; }

    public bool? AdminAccess { get; set; }

    public bool? AdvisoryFlag { get; set; }

    public bool? Lock { get; set; }

    public int AccountId { get; set; }

    public bool? OrmLock { get; set; }

    public bool? OrmDeactivate { get; set; }

    public int? DivisionId { get; set; }

    public string? Phone { get; set; }

    public string? Mobile { get; set; }

    public string? Extention { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntion> BcmBiaFuntions { get; set; } = new List<BcmBiaFuntion>();

    public virtual ICollection<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; } = new List<BcmBiaFuntionsBusinessUnit>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanScheduleOvarlapApproveBies { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanScheduleOwners { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual GrcBranch? Branch { get; set; }

    public virtual ICollection<CompActionDetail> CompActionDetailAssignUsers { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompActionDetail> CompActionDetailEscalatedUsers { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompActionDetail> CompActionDetailLoggedByUsers { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual GrcCountry? CouCountry { get; set; }

    public virtual GrcRegulationLanguage? DefaultRegLanguageNavigation { get; set; }

    public virtual GrcDepartment? DepDepartment { get; set; }

    public virtual Division? Division { get; set; }

    public virtual ICollection<GrcAuditEscalationAction> GrcAuditEscalationActionUseActionUsers { get; set; } = new List<GrcAuditEscalationAction>();

    public virtual ICollection<GrcAuditEscalationAction> GrcAuditEscalationActionUseApprovedByNavigations { get; set; } = new List<GrcAuditEscalationAction>();

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCollectionQuestionnaire> GrcCollectionQuestionnaires { get; set; } = new List<GrcCollectionQuestionnaire>();

    public virtual ICollection<GrcComplianceAdminDepartment> GrcComplianceAdminDepartments { get; set; } = new List<GrcComplianceAdminDepartment>();

    public virtual ICollection<GrcControlUserAccess> GrcControlUserAccesses { get; set; } = new List<GrcControlUserAccess>();

    public virtual ICollection<GrcCrimeSituation> GrcCrimeSituationEmployeeInCharges { get; set; } = new List<GrcCrimeSituation>();

    public virtual ICollection<GrcCrimeSituation> GrcCrimeSituationInitiatedByNavigations { get; set; } = new List<GrcCrimeSituation>();

    public virtual ICollection<GrcDataCollectionAnswer> GrcDataCollectionAnswers { get; set; } = new List<GrcDataCollectionAnswer>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancialComApprovedByNavigations { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancialStagingCompApprovedByNavigations { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancialUseApprovedByNavigations { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcEntityAssessmentDetail> GrcEntityAssessmentDetails { get; set; } = new List<GrcEntityAssessmentDetail>();

    public virtual ICollection<GrcEscalationAction> GrcEscalationActionUseActionUsers { get; set; } = new List<GrcEscalationAction>();

    public virtual ICollection<GrcEscalationAction> GrcEscalationActionUseApprovedByNavigations { get; set; } = new List<GrcEscalationAction>();

    public virtual ICollection<GrcEscalationMonitor> GrcEscalationMonitors { get; set; } = new List<GrcEscalationMonitor>();

    public virtual ICollection<GrcFinancialRegulationsUser> GrcFinancialRegulationsUsers { get; set; } = new List<GrcFinancialRegulationsUser>();

    public virtual ICollection<GrcRegulationUserAccess> GrcRegulationUserAccesses { get; set; } = new List<GrcRegulationUserAccess>();

    public virtual ICollection<GrcRegulation> GrcRegulations { get; set; } = new List<GrcRegulation>();

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();

    public virtual ICollection<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; } = new List<GrcStagingSubRegulation>();

    public virtual ICollection<GrcSubRegulation> GrcSubRegulations { get; set; } = new List<GrcSubRegulation>();

    public virtual ICollection<GrcTestDetailAction> GrcTestDetailActions { get; set; } = new List<GrcTestDetailAction>();

    public virtual ICollection<GrcTestDetail> GrcTestDetailComplianceApproves { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<GrcTestDetail> GrcTestDetailManagerApproves { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<GrcTestDetail> GrcTestDetailStagingComplianceApproves { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual ICollection<GrcUserActivitiesLog> GrcUserActivitiesLogs { get; set; } = new List<GrcUserActivitiesLog>();

    public virtual ICollection<GrcUserAuditLog> GrcUserAuditLogs { get; set; } = new List<GrcUserAuditLog>();

    public virtual ICollection<GrcUserDepartment> GrcUserDepartments { get; set; } = new List<GrcUserDepartment>();

    public virtual ICollection<GrcUserRole> GrcUserRoles { get; set; } = new List<GrcUserRole>();

    public virtual GrcJobTitle? JobTitle { get; set; }

    public virtual GrcLanguage? LanguageCodeNavigation { get; set; }

    public virtual ICollection<OrmActionMonitorDetail> OrmActionMonitorDetailActionUsers { get; set; } = new List<OrmActionMonitorDetail>();

    public virtual ICollection<OrmActionMonitorDetail> OrmActionMonitorDetailAprovedByNavigations { get; set; } = new List<OrmActionMonitorDetail>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControlCompCheckers { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControlCompMakers { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControlDepMakers { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControlDepcheckers { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<OrmRcsaTaskOfficer> OrmRcsaTaskOfficers { get; set; } = new List<OrmRcsaTaskOfficer>();

    public virtual ICollection<OrmRoleUser> OrmRoleUsers { get; set; } = new List<OrmRoleUser>();

    public virtual ICollection<OrmuserActivitiesLog> OrmuserActivitiesLogs { get; set; } = new List<OrmuserActivitiesLog>();

    public virtual ICollection<OrmuserAuditLog> OrmuserAuditLogs { get; set; } = new List<OrmuserAuditLog>();

    public virtual ICollection<PolicyApprovalStage> PolicyApprovalStages { get; set; } = new List<PolicyApprovalStage>();

    public virtual ICollection<PolicyDeveloper> PolicyDevelopers { get; set; } = new List<PolicyDeveloper>();

    public virtual ICollection<PolicyFollowUpReview> PolicyFollowUpReviews { get; set; } = new List<PolicyFollowUpReview>();

    public virtual ICollection<Policy> PolicyInitiatedUsers { get; set; } = new List<Policy>();

    public virtual ICollection<PolicyMgmtUser> PolicyMgmtUserInitiatedUsers { get; set; } = new List<PolicyMgmtUser>();

    public virtual ICollection<PolicyMgmtUser> PolicyMgmtUserUsers { get; set; } = new List<PolicyMgmtUser>();

    public virtual ICollection<Policy> PolicyPolicyOwners { get; set; } = new List<Policy>();

    public virtual ICollection<PolicyRejectReasonLog> PolicyRejectReasonLogs { get; set; } = new List<PolicyRejectReasonLog>();

    public virtual ICollection<PolicyReviewer> PolicyReviewers { get; set; } = new List<PolicyReviewer>();

    public virtual ICollection<PolicyReview> PolicyReviews { get; set; } = new List<PolicyReview>();

    public virtual ICollection<RcamAdvisoryRequestAction> RcamAdvisoryRequestActions { get; set; } = new List<RcamAdvisoryRequestAction>();

    public virtual ICollection<RcamAdvisoryRequestUser> RcamAdvisoryRequestUsers { get; set; } = new List<RcamAdvisoryRequestUser>();

    public virtual ICollection<RcamAdvisoryRequest> RcamAdvisoryRequests { get; set; } = new List<RcamAdvisoryRequest>();

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual ICollection<RccmTaskUserAction> RccmTaskUserActions { get; set; } = new List<RccmTaskUserAction>();

    public virtual ICollection<RccmTaskUser> RccmTaskUserApproveUsers { get; set; } = new List<RccmTaskUser>();

    public virtual ICollection<RccmTaskUser> RccmTaskUserUsers { get; set; } = new List<RccmTaskUser>();

    public virtual ICollection<RcmaAssessmentElementHeader> RcmaAssessmentElementHeaders { get; set; } = new List<RcmaAssessmentElementHeader>();

    public virtual ICollection<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; } = new List<RcmaTaskUserTemplate>();

    public virtual ICollection<UserBranch> UserBranches { get; set; } = new List<UserBranch>();

    public virtual ICollection<UserDivision> UserDivisions { get; set; } = new List<UserDivision>();

    public virtual ICollection<WblowerCaseAction> WblowerCaseActionAssignUsers { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseAction> WblowerCaseActionEscalatedUsers { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseAction> WblowerCaseActionLoggedUsers { get; set; } = new List<WblowerCaseAction>();
}
