using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDepartment
{
    public int DepartmentId { get; set; }

    public int? CountryId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public string DepartmentEmail1 { get; set; } = null!;

    public string? DepartmentEmail2 { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? SectorId { get; set; }

    public int AccountId { get; set; }

    public string? DepartmentCode { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; } = new List<BcmBiaFuntionsBusinessUnit>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual ICollection<CompActionDetail> CompActionDetails { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompBreachDepartment> CompBreachDepartments { get; set; } = new List<CompBreachDepartment>();

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual ICollection<CorresLetterToPerson> CorresLetterToPeople { get; set; } = new List<CorresLetterToPerson>();

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual ICollection<CorresLettersDep> CorresLettersDeps { get; set; } = new List<CorresLettersDep>();

    public virtual GrcCountry? Country { get; set; }

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<GrcAuditDepBranch> GrcAuditDepBranches { get; set; } = new List<GrcAuditDepBranch>();

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();

    public virtual ICollection<GrcBranch> GrcBranches { get; set; } = new List<GrcBranch>();

    public virtual ICollection<GrcBusinessUnitDepartment> GrcBusinessUnitDepartments { get; set; } = new List<GrcBusinessUnitDepartment>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual ICollection<GrcComplianceAdminDepartment> GrcComplianceAdminDepartments { get; set; } = new List<GrcComplianceAdminDepartment>();

    public virtual ICollection<GrcControlUserAccess> GrcControlUserAccesses { get; set; } = new List<GrcControlUserAccess>();

    public virtual ICollection<GrcCrimeBusinessunit> GrcCrimeBusinessunits { get; set; } = new List<GrcCrimeBusinessunit>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDepartmentBreachsSource> GrcDepartmentBreachsSources { get; set; } = new List<GrcDepartmentBreachsSource>();

    public virtual ICollection<GrcDepartmentCriteriaRank> GrcDepartmentCriteriaRanks { get; set; } = new List<GrcDepartmentCriteriaRank>();

    public virtual ICollection<GrcDepartmentRank> GrcDepartmentRanks { get; set; } = new List<GrcDepartmentRank>();

    public virtual ICollection<GrcDepartmentRegulationsMatrix> GrcDepartmentRegulationsMatrices { get; set; } = new List<GrcDepartmentRegulationsMatrix>();

    public virtual ICollection<GrcDepartmentSubRegulation> GrcDepartmentSubRegulations { get; set; } = new List<GrcDepartmentSubRegulation>();

    public virtual ICollection<GrcExternalUserAccess> GrcExternalUserAccesses { get; set; } = new List<GrcExternalUserAccess>();

    public virtual ICollection<GrcGoalDetailsBu> GrcGoalDetailsBus { get; set; } = new List<GrcGoalDetailsBu>();

    public virtual ICollection<GrcGoalsBu> GrcGoalsBus { get; set; } = new List<GrcGoalsBu>();

    public virtual ICollection<GrcMatrix> GrcMatrices { get; set; } = new List<GrcMatrix>();

    public virtual ICollection<GrcProjectDepartment> GrcProjectDepartments { get; set; } = new List<GrcProjectDepartment>();

    public virtual ICollection<GrcRegulatoryReportingTrack> GrcRegulatoryReportingTracks { get; set; } = new List<GrcRegulatoryReportingTrack>();

    public virtual ICollection<GrcRiskProfileEoy> GrcRiskProfileEoys { get; set; } = new List<GrcRiskProfileEoy>();

    public virtual ICollection<GrcRiskProfile> GrcRiskProfiles { get; set; } = new List<GrcRiskProfile>();

    public virtual ICollection<GrcSubProductsDepartment> GrcSubProductsDepartments { get; set; } = new List<GrcSubProductsDepartment>();

    public virtual ICollection<GrcTestDetail> GrcTestDetails { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual ICollection<GrcUserDepartment> GrcUserDepartments { get; set; } = new List<GrcUserDepartment>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<PolicyReader> PolicyReaders { get; set; } = new List<PolicyReader>();

    public virtual ICollection<RcmaDepartmentTaskScore> RcmaDepartmentTaskScores { get; set; } = new List<RcmaDepartmentTaskScore>();

    public virtual ICollection<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; } = new List<RcmaTaskUserTemplate>();

    public virtual GrcSector? Sector { get; set; }

    public virtual ICollection<WblowerCaseAction> WblowerCaseActions { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseBreachDepartment> WblowerCaseBreachDepartments { get; set; } = new List<WblowerCaseBreachDepartment>();

    public virtual ICollection<WblowerCaseDepartment> WblowerCaseDepartments { get; set; } = new List<WblowerCaseDepartment>();
}
