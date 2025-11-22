using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAccount
{
    public int Id { get; set; }

    public int IndustryId { get; set; }

    public string Name { get; set; } = null!;

    public string? Telephone { get; set; }

    public string EmailAddress { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime ActicateDate { get; set; }

    public DateTime? DeactivateDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ComplaintNotification { get; set; }

    public virtual ICollection<AbcExtract> AbcExtracts { get; set; } = new List<AbcExtract>();

    public virtual ICollection<AuditLossImpact> AuditLossImpacts { get; set; } = new List<AuditLossImpact>();

    public virtual ICollection<BcmBiaCriticality> BcmBiaCriticalities { get; set; } = new List<BcmBiaCriticality>();

    public virtual ICollection<BcmBiaFuntionProcess> BcmBiaFuntionProcesses { get; set; } = new List<BcmBiaFuntionProcess>();

    public virtual ICollection<BcmBiaFuntion> BcmBiaFuntions { get; set; } = new List<BcmBiaFuntion>();

    public virtual ICollection<BcmBiaImpactAnalysis> BcmBiaImpactAnalyses { get; set; } = new List<BcmBiaImpactAnalysis>();

    public virtual ICollection<BcmBiaPlanElementTest> BcmBiaPlanElementTests { get; set; } = new List<BcmBiaPlanElementTest>();

    public virtual ICollection<BcmBiaPlanElement> BcmBiaPlanElements { get; set; } = new List<BcmBiaPlanElement>();

    public virtual ICollection<BcmBiaPlanImpactAnalysisDetailsTest> BcmBiaPlanImpactAnalysisDetailsTests { get; set; } = new List<BcmBiaPlanImpactAnalysisDetailsTest>();

    public virtual ICollection<BcmBiaPlanImpactAnalysisTest> BcmBiaPlanImpactAnalysisTests { get; set; } = new List<BcmBiaPlanImpactAnalysisTest>();

    public virtual ICollection<BcmBiaPlanNotifiProcDetailsTest> BcmBiaPlanNotifiProcDetailsTests { get; set; } = new List<BcmBiaPlanNotifiProcDetailsTest>();

    public virtual ICollection<BcmBiaPlanNotifiProcTest> BcmBiaPlanNotifiProcTests { get; set; } = new List<BcmBiaPlanNotifiProcTest>();

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual ICollection<BcmBiaPlanProcessTest> BcmBiaPlanProcessTests { get; set; } = new List<BcmBiaPlanProcessTest>();

    public virtual ICollection<BcmBiaPlanRecTeamDetailsTest> BcmBiaPlanRecTeamDetailsTests { get; set; } = new List<BcmBiaPlanRecTeamDetailsTest>();

    public virtual ICollection<BcmBiaPlanRecTeamTest> BcmBiaPlanRecTeamTests { get; set; } = new List<BcmBiaPlanRecTeamTest>();

    public virtual ICollection<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTests { get; set; } = new List<BcmBiaPlanRecoveryDetailsTest>();

    public virtual ICollection<BcmBiaPlanRecoveryTest> BcmBiaPlanRecoveryTests { get; set; } = new List<BcmBiaPlanRecoveryTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceTest> BcmBiaPlanResourceTests { get; set; } = new List<BcmBiaPlanResourceTest>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanSchedules { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmBiaPlanTest> BcmBiaPlanTests { get; set; } = new List<BcmBiaPlanTest>();

    public virtual ICollection<BcmBiaPlanVendorDetailsTest> BcmBiaPlanVendorDetailsTests { get; set; } = new List<BcmBiaPlanVendorDetailsTest>();

    public virtual ICollection<BcmBiaPlanVendorTest> BcmBiaPlanVendorTests { get; set; } = new List<BcmBiaPlanVendorTest>();

    public virtual ICollection<BcmBiaPlan> BcmBiaPlans { get; set; } = new List<BcmBiaPlan>();

    public virtual ICollection<BcmBiaRecovery> BcmBiaRecoveries { get; set; } = new List<BcmBiaRecovery>();

    public virtual ICollection<BcmBiaResource> BcmBiaResources { get; set; } = new List<BcmBiaResource>();

    public virtual ICollection<BcmBiaType> BcmBiaTypes { get; set; } = new List<BcmBiaType>();

    public virtual ICollection<BcmBusinessImpact> BcmBusinessImpacts { get; set; } = new List<BcmBusinessImpact>();

    public virtual ICollection<BcmBusinessResponsibility> BcmBusinessResponsibilities { get; set; } = new List<BcmBusinessResponsibility>();

    public virtual ICollection<BcmBusinessRole> BcmBusinessRoles { get; set; } = new List<BcmBusinessRole>();

    public virtual ICollection<BcmBusinessTitle> BcmBusinessTitles { get; set; } = new List<BcmBusinessTitle>();

    public virtual ICollection<BcmFunction> BcmFunctions { get; set; } = new List<BcmFunction>();

    public virtual ICollection<BcmImpactAnalysis> BcmImpactAnalyses { get; set; } = new List<BcmImpactAnalysis>();

    public virtual ICollection<BcmLocation> BcmLocations { get; set; } = new List<BcmLocation>();

    public virtual ICollection<BcmPeriod> BcmPeriods { get; set; } = new List<BcmPeriod>();

    public virtual ICollection<BcmPlanElement> BcmPlanElements { get; set; } = new List<BcmPlanElement>();

    public virtual ICollection<BcmPlanEventCategory> BcmPlanEventCategories { get; set; } = new List<BcmPlanEventCategory>();

    public virtual ICollection<BcmPlanNotificationProc> BcmPlanNotificationProcs { get; set; } = new List<BcmPlanNotificationProc>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual ICollection<BcmPlanVendorList> BcmPlanVendorLists { get; set; } = new List<BcmPlanVendorList>();

    public virtual ICollection<BcmPlan> BcmPlans { get; set; } = new List<BcmPlan>();

    public virtual ICollection<BcmProduct> BcmProducts { get; set; } = new List<BcmProduct>();

    public virtual ICollection<BcmResourceDetail> BcmResourceDetails { get; set; } = new List<BcmResourceDetail>();

    public virtual ICollection<BcmResourceType> BcmResourceTypes { get; set; } = new List<BcmResourceType>();

    public virtual ICollection<BcmSlaDetail> BcmSlaDetails { get; set; } = new List<BcmSlaDetail>();

    public virtual ICollection<BcmStatus> BcmStatuses { get; set; } = new List<BcmStatus>();

    public virtual ICollection<BcmSupplierRole> BcmSupplierRoles { get; set; } = new List<BcmSupplierRole>();

    public virtual ICollection<BcmTestResultStatus> BcmTestResultStatuses { get; set; } = new List<BcmTestResultStatus>();

    public virtual ICollection<BcmVendor> BcmVendors { get; set; } = new List<BcmVendor>();

    public virtual ICollection<CbjclassificationHeader> CbjclassificationHeaders { get; set; } = new List<CbjclassificationHeader>();

    public virtual ICollection<Cbjclassification> Cbjclassifications { get; set; } = new List<Cbjclassification>();

    public virtual ICollection<ComRootCauseType> ComRootCauseTypes { get; set; } = new List<ComRootCauseType>();

    public virtual ICollection<CompBreachDepartment> CompBreachDepartments { get; set; } = new List<CompBreachDepartment>();

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual ICollection<CompReceivedType> CompReceivedTypes { get; set; } = new List<CompReceivedType>();

    public virtual ICollection<CompRecoveryMean> CompRecoveryMeans { get; set; } = new List<CompRecoveryMean>();

    public virtual ICollection<CompRejectReason> CompRejectReasons { get; set; } = new List<CompRejectReason>();

    public virtual ICollection<CompRootCause> CompRootCauses { get; set; } = new List<CompRootCause>();

    public virtual ICollection<CompStatus> CompStatuses { get; set; } = new List<CompStatus>();

    public virtual ICollection<CompType> CompTypes { get; set; } = new List<CompType>();

    public virtual ICollection<ContactChannel> ContactChannels { get; set; } = new List<ContactChannel>();

    public virtual ICollection<CorresCategory> CorresCategories { get; set; } = new List<CorresCategory>();

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual ICollection<CorresLettersDep> CorresLettersDeps { get; set; } = new List<CorresLettersDep>();

    public virtual ICollection<CorresOrgPerson> CorresOrgPeople { get; set; } = new List<CorresOrgPerson>();

    public virtual ICollection<CorresOrganization> CorresOrganizations { get; set; } = new List<CorresOrganization>();

    public virtual ICollection<CorresStatus> CorresStatuses { get; set; } = new List<CorresStatus>();

    public virtual ICollection<CorresType> CorresTypes { get; set; } = new List<CorresType>();

    public virtual ICollection<Currency> Currencies { get; set; } = new List<Currency>();

    public virtual ICollection<CustomerDetail> CustomerDetails { get; set; } = new List<CustomerDetail>();

    public virtual ICollection<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();

    public virtual ICollection<Division> Divisions { get; set; } = new List<Division>();

    public virtual ICollection<ExtractRegulation> ExtractRegulations { get; set; } = new List<ExtractRegulation>();

    public virtual ICollection<ExtractSubRegulation> ExtractSubRegulations { get; set; } = new List<ExtractSubRegulation>();

    public virtual ICollection<FinancialLossRecoverySource> FinancialLossRecoverySources { get; set; } = new List<FinancialLossRecoverySource>();

    public virtual ICollection<FinancialLossType> FinancialLossTypes { get; set; } = new List<FinancialLossType>();

    public virtual ICollection<GrcApproveStatus> GrcApproveStatuses { get; set; } = new List<GrcApproveStatus>();

    public virtual ICollection<GrcArchivingPolicy> GrcArchivingPolicies { get; set; } = new List<GrcArchivingPolicy>();

    public virtual ICollection<GrcAuditEscalationAction> GrcAuditEscalationActions { get; set; } = new List<GrcAuditEscalationAction>();

    public virtual ICollection<GrcAuditFinding> GrcAuditFindings { get; set; } = new List<GrcAuditFinding>();

    public virtual ICollection<GrcAuditIssueLink> GrcAuditIssueLinks { get; set; } = new List<GrcAuditIssueLink>();

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();

    public virtual ICollection<GrcAuditRiskRating> GrcAuditRiskRatings { get; set; } = new List<GrcAuditRiskRating>();

    public virtual ICollection<GrcAuditSeverityClass> GrcAuditSeverityClasses { get; set; } = new List<GrcAuditSeverityClass>();

    public virtual ICollection<GrcAuditSource> GrcAuditSources { get; set; } = new List<GrcAuditSource>();

    public virtual ICollection<GrcBranch> GrcBranches { get; set; } = new List<GrcBranch>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcBusinessFunctionJobTitle> GrcBusinessFunctionJobTitles { get; set; } = new List<GrcBusinessFunctionJobTitle>();

    public virtual ICollection<GrcBusinessUnitDepartment> GrcBusinessUnitDepartments { get; set; } = new List<GrcBusinessUnitDepartment>();

    public virtual ICollection<GrcBusinessUnitFunction> GrcBusinessUnitFunctions { get; set; } = new List<GrcBusinessUnitFunction>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual ICollection<GrcCalendarHoliday> GrcCalendarHolidays { get; set; } = new List<GrcCalendarHoliday>();

    public virtual ICollection<GrcCalendarYear> GrcCalendarYears { get; set; } = new List<GrcCalendarYear>();

    public virtual ICollection<GrcComply> GrcComplies { get; set; } = new List<GrcComply>();

    public virtual ICollection<GrcControlBusinessUnit> GrcControlBusinessUnits { get; set; } = new List<GrcControlBusinessUnit>();

    public virtual ICollection<GrcControlClassSubjective> GrcControlClassSubjectives { get; set; } = new List<GrcControlClassSubjective>();

    public virtual ICollection<GrcControlPropabilityClass> GrcControlPropabilityClasses { get; set; } = new List<GrcControlPropabilityClass>();

    public virtual ICollection<GrcControlType> GrcControlTypes { get; set; } = new List<GrcControlType>();

    public virtual ICollection<GrcControlUserAccess> GrcControlUserAccesses { get; set; } = new List<GrcControlUserAccess>();

    public virtual ICollection<GrcControl> GrcControls { get; set; } = new List<GrcControl>();

    public virtual ICollection<GrcCrimeNature> GrcCrimeNatures { get; set; } = new List<GrcCrimeNature>();

    public virtual ICollection<GrcCrimeReporting> GrcCrimeReportings { get; set; } = new List<GrcCrimeReporting>();

    public virtual ICollection<GrcCrimeSituation> GrcCrimeSituations { get; set; } = new List<GrcCrimeSituation>();

    public virtual ICollection<GrcCriterion> GrcCriteria { get; set; } = new List<GrcCriterion>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcDepartmentCriteriaRank> GrcDepartmentCriteriaRanks { get; set; } = new List<GrcDepartmentCriteriaRank>();

    public virtual ICollection<GrcDepartmentRank> GrcDepartmentRanks { get; set; } = new List<GrcDepartmentRank>();

    public virtual ICollection<GrcDepartmentRegulationsMatrix> GrcDepartmentRegulationsMatrices { get; set; } = new List<GrcDepartmentRegulationsMatrix>();

    public virtual ICollection<GrcDepartment> GrcDepartments { get; set; } = new List<GrcDepartment>();

    public virtual ICollection<GrcEmailControl> GrcEmailControls { get; set; } = new List<GrcEmailControl>();

    public virtual ICollection<GrcEmail> GrcEmails { get; set; } = new List<GrcEmail>();

    public virtual ICollection<GrcEntity> GrcEntities { get; set; } = new List<GrcEntity>();

    public virtual ICollection<GrcEntityAssessmentDetail> GrcEntityAssessmentDetails { get; set; } = new List<GrcEntityAssessmentDetail>();

    public virtual ICollection<GrcEscalationAction> GrcEscalationActions { get; set; } = new List<GrcEscalationAction>();

    public virtual ICollection<GrcEscalationMonitor> GrcEscalationMonitors { get; set; } = new List<GrcEscalationMonitor>();

    public virtual ICollection<GrcEscalationStatus> GrcEscalationStatuses { get; set; } = new List<GrcEscalationStatus>();

    public virtual ICollection<GrcFinancialCollectionLevel2> GrcFinancialCollectionLevel2s { get; set; } = new List<GrcFinancialCollectionLevel2>();

    public virtual ICollection<GrcFinancialCollection> GrcFinancialCollections { get; set; } = new List<GrcFinancialCollection>();

    public virtual ICollection<GrcFinancialRefLevel2> GrcFinancialRefLevel2s { get; set; } = new List<GrcFinancialRefLevel2>();

    public virtual ICollection<GrcFinancialRefLevelLink> GrcFinancialRefLevelLinks { get; set; } = new List<GrcFinancialRefLevelLink>();

    public virtual ICollection<GrcFinancialRefReg> GrcFinancialRefRegs { get; set; } = new List<GrcFinancialRefReg>();

    public virtual ICollection<GrcFinancialRef> GrcFinancialRefs { get; set; } = new List<GrcFinancialRef>();

    public virtual ICollection<GrcIntegrationApiCode> GrcIntegrationApiCodes { get; set; } = new List<GrcIntegrationApiCode>();

    public virtual ICollection<GrcIntegrationMonitor> GrcIntegrationMonitors { get; set; } = new List<GrcIntegrationMonitor>();

    public virtual ICollection<GrcIntegrationService> GrcIntegrationServices { get; set; } = new List<GrcIntegrationService>();

    public virtual ICollection<GrcIntegrationStatus> GrcIntegrationStatuses { get; set; } = new List<GrcIntegrationStatus>();

    public virtual ICollection<GrcIntegrationType> GrcIntegrationTypes { get; set; } = new List<GrcIntegrationType>();

    public virtual ICollection<GrcIssuer> GrcIssuers { get; set; } = new List<GrcIssuer>();

    public virtual ICollection<GrcJobTitle> GrcJobTitles { get; set; } = new List<GrcJobTitle>();

    public virtual ICollection<GrcLanguage> GrcLanguages { get; set; } = new List<GrcLanguage>();

    public virtual ICollection<GrcMapAuditTable> GrcMapAuditTables { get; set; } = new List<GrcMapAuditTable>();

    public virtual ICollection<GrcMatrix> GrcMatrices { get; set; } = new List<GrcMatrix>();

    public virtual ICollection<GrcPage> GrcPages { get; set; } = new List<GrcPage>();

    public virtual ICollection<GrcPriority> GrcPriorities { get; set; } = new List<GrcPriority>();

    public virtual ICollection<GrcRegulationLanguage> GrcRegulationLanguages { get; set; } = new List<GrcRegulationLanguage>();

    public virtual ICollection<GrcRegulationLink> GrcRegulationLinks { get; set; } = new List<GrcRegulationLink>();

    public virtual ICollection<GrcRegulationType> GrcRegulationTypes { get; set; } = new List<GrcRegulationType>();

    public virtual ICollection<GrcRegulation> GrcRegulations { get; set; } = new List<GrcRegulation>();

    public virtual ICollection<GrcRegulatoryReportingTrack> GrcRegulatoryReportingTracks { get; set; } = new List<GrcRegulatoryReportingTrack>();

    public virtual ICollection<GrcResponsibilityType> GrcResponsibilityTypes { get; set; } = new List<GrcResponsibilityType>();

    public virtual ICollection<GrcRiskClassification> GrcRiskClassifications { get; set; } = new List<GrcRiskClassification>();

    public virtual ICollection<GrcRiskFinAppetite> GrcRiskFinAppetites { get; set; } = new List<GrcRiskFinAppetite>();

    public virtual ICollection<GrcRiskNatureRule> GrcRiskNatureRules { get; set; } = new List<GrcRiskNatureRule>();

    public virtual ICollection<GrcRiskProfileEoy> GrcRiskProfileEoys { get; set; } = new List<GrcRiskProfileEoy>();

    public virtual ICollection<GrcRiskProfile> GrcRiskProfiles { get; set; } = new List<GrcRiskProfile>();

    public virtual ICollection<GrcRiskSubjective> GrcRiskSubjectives { get; set; } = new List<GrcRiskSubjective>();

    public virtual ICollection<GrcRiskType> GrcRiskTypes { get; set; } = new List<GrcRiskType>();

    public virtual ICollection<GrcRisk> GrcRisks { get; set; } = new List<GrcRisk>();

    public virtual ICollection<GrcRole> GrcRoles { get; set; } = new List<GrcRole>();

    public virtual ICollection<GrcSector> GrcSectors { get; set; } = new List<GrcSector>();

    public virtual ICollection<GrcSelfAssessmentStatus> GrcSelfAssessmentStatuses { get; set; } = new List<GrcSelfAssessmentStatus>();

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();

    public virtual ICollection<GrcStagingStatus> GrcStagingStatuses { get; set; } = new List<GrcStagingStatus>();

    public virtual ICollection<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; } = new List<GrcStagingSubRegulation>();

    public virtual ICollection<GrcSubRegulation> GrcSubRegulations { get; set; } = new List<GrcSubRegulation>();

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual ICollection<GrcTheme> GrcThemes { get; set; } = new List<GrcTheme>();

    public virtual ICollection<GrcUserActivitiesLog> GrcUserActivitiesLogs { get; set; } = new List<GrcUserActivitiesLog>();

    public virtual ICollection<GrcUserAuditLog> GrcUserAuditLogs { get; set; } = new List<GrcUserAuditLog>();

    public virtual ICollection<GrcUserDepartment> GrcUserDepartments { get; set; } = new List<GrcUserDepartment>();

    public virtual ICollection<GrcUserManagementLog> GrcUserManagementLogs { get; set; } = new List<GrcUserManagementLog>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<GrcVariable> GrcVariables { get; set; } = new List<GrcVariable>();

    public virtual ICollection<GrcWblowerCaseBranch> GrcWblowerCaseBranches { get; set; } = new List<GrcWblowerCaseBranch>();

    public virtual GrcIndustry Industry { get; set; } = null!;

    public virtual ICollection<Institute> Institutes { get; set; } = new List<Institute>();

    public virtual ICollection<License> Licenses { get; set; } = new List<License>();

    public virtual ICollection<LicensesDetail> LicensesDetails { get; set; } = new List<LicensesDetail>();

    public virtual ICollection<MapCountry> MapCountries { get; set; } = new List<MapCountry>();

    public virtual ICollection<OrmActionMonitorDetail> OrmActionMonitorDetails { get; set; } = new List<OrmActionMonitorDetail>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmActionStatus> OrmActionStatuses { get; set; } = new List<OrmActionStatus>();

    public virtual ICollection<OrmAssessmentStatus> OrmAssessmentStatuses { get; set; } = new List<OrmAssessmentStatus>();

    public virtual ICollection<OrmCategory> OrmCategories { get; set; } = new List<OrmCategory>();

    public virtual ICollection<OrmControlCategory> OrmControlCategories { get; set; } = new List<OrmControlCategory>();

    public virtual ICollection<OrmControlCategoryElement> OrmControlCategoryElements { get; set; } = new List<OrmControlCategoryElement>();

    public virtual ICollection<OrmControlDesignEffective> OrmControlDesignEffectives { get; set; } = new List<OrmControlDesignEffective>();

    public virtual ICollection<OrmControlEffectScore> OrmControlEffectScores { get; set; } = new List<OrmControlEffectScore>();

    public virtual ICollection<OrmEmail> OrmEmails { get; set; } = new List<OrmEmail>();

    public virtual ICollection<OrmInherentRiskScore> OrmInherentRiskScores { get; set; } = new List<OrmInherentRiskScore>();

    public virtual ICollection<OrmKriDirection> OrmKriDirections { get; set; } = new List<OrmKriDirection>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriPeriod> OrmKriPeriods { get; set; } = new List<OrmKriPeriod>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmKriProcess> OrmKriProcesses { get; set; } = new List<OrmKriProcess>();

    public virtual ICollection<OrmKriType> OrmKriTypes { get; set; } = new List<OrmKriType>();

    public virtual ICollection<OrmKri> OrmKris { get; set; } = new List<OrmKri>();

    public virtual ICollection<OrmLossEventCategory> OrmLossEventCategories { get; set; } = new List<OrmLossEventCategory>();

    public virtual ICollection<OrmLossEventCauseOfLoss> OrmLossEventCauseOfLosses { get; set; } = new List<OrmLossEventCauseOfLoss>();

    public virtual ICollection<OrmLossEventControl> OrmLossEventControls { get; set; } = new List<OrmLossEventControl>();

    public virtual ICollection<OrmLossEventKri> OrmLossEventKris { get; set; } = new List<OrmLossEventKri>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmLossEventProduct> OrmLossEventProducts { get; set; } = new List<OrmLossEventProduct>();

    public virtual ICollection<OrmLossEventRecoverySource> OrmLossEventRecoverySources { get; set; } = new List<OrmLossEventRecoverySource>();

    public virtual ICollection<OrmLossEventRisk> OrmLossEventRisks { get; set; } = new List<OrmLossEventRisk>();

    public virtual ICollection<OrmLossEventStatus> OrmLossEventStatuses { get; set; } = new List<OrmLossEventStatus>();

    public virtual ICollection<OrmLossEventType> OrmLossEventTypes { get; set; } = new List<OrmLossEventType>();

    public virtual ICollection<OrmLossEvent> OrmLossEvents { get; set; } = new List<OrmLossEvent>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmProcessControlLink> OrmProcessControlLinks { get; set; } = new List<OrmProcessControlLink>();

    public virtual ICollection<OrmProcessDetail> OrmProcessDetails { get; set; } = new List<OrmProcessDetail>();

    public virtual ICollection<OrmProcessRiskLink> OrmProcessRiskLinks { get; set; } = new List<OrmProcessRiskLink>();

    public virtual ICollection<OrmProcessSubject> OrmProcessSubjects { get; set; } = new List<OrmProcessSubject>();

    public virtual ICollection<OrmProcessType> OrmProcessTypes { get; set; } = new List<OrmProcessType>();

    public virtual ICollection<OrmProcess> OrmProcesses { get; set; } = new List<OrmProcess>();

    public virtual ICollection<OrmQuadrantValue> OrmQuadrantValues { get; set; } = new List<OrmQuadrantValue>();

    public virtual ICollection<OrmQuestionnnaire> OrmQuestionnnaires { get; set; } = new List<OrmQuestionnnaire>();

    public virtual ICollection<OrmRbaControlAsesmnt> OrmRbaControlAsesmnts { get; set; } = new List<OrmRbaControlAsesmnt>();

    public virtual ICollection<OrmRbaControlProcessControl> OrmRbaControlProcessControls { get; set; } = new List<OrmRbaControlProcessControl>();

    public virtual ICollection<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; } = new List<OrmRbaProcessRiskAsesmnt>();

    public virtual ICollection<OrmRbaRisk> OrmRbaRisks { get; set; } = new List<OrmRbaRisk>();

    public virtual ICollection<OrmRbacontrolQuestAnswer> OrmRbacontrolQuestAnswers { get; set; } = new List<OrmRbacontrolQuestAnswer>();

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();

    public virtual ICollection<OrmRcsaDueAsesmntRisk> OrmRcsaDueAsesmntRisks { get; set; } = new List<OrmRcsaDueAsesmntRisk>();

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<OrmRcsaTaskOfficer> OrmRcsaTaskOfficers { get; set; } = new List<OrmRcsaTaskOfficer>();

    public virtual ICollection<OrmRcsaTaskTemplate> OrmRcsaTaskTemplates { get; set; } = new List<OrmRcsaTaskTemplate>();

    public virtual ICollection<OrmRcsaTask> OrmRcsaTasks { get; set; } = new List<OrmRcsaTask>();

    public virtual ICollection<OrmRcsaofficerStatus> OrmRcsaofficerStatuses { get; set; } = new List<OrmRcsaofficerStatus>();

    public virtual ICollection<OrmRcsataskRiskControlAttachment> OrmRcsataskRiskControlAttachments { get; set; } = new List<OrmRcsataskRiskControlAttachment>();

    public virtual ICollection<OrmResidualRiskExposure> OrmResidualRiskExposures { get; set; } = new List<OrmResidualRiskExposure>();

    public virtual ICollection<OrmResidualRiskQuadrant> OrmResidualRiskQuadrants { get; set; } = new List<OrmResidualRiskQuadrant>();

    public virtual ICollection<OrmRiskCategory> OrmRiskCategories { get; set; } = new List<OrmRiskCategory>();

    public virtual ICollection<OrmRiskClassification> OrmRiskClassifications { get; set; } = new List<OrmRiskClassification>();

    public virtual ICollection<OrmRiskControlCategory> OrmRiskControlCategories { get; set; } = new List<OrmRiskControlCategory>();

    public virtual ICollection<OrmRiskControlElement> OrmRiskControlElements { get; set; } = new List<OrmRiskControlElement>();

    public virtual ICollection<OrmRiskElement> OrmRiskElements { get; set; } = new List<OrmRiskElement>();

    public virtual ICollection<OrmRiskImpact> OrmRiskImpacts { get; set; } = new List<OrmRiskImpact>();

    public virtual ICollection<OrmRiskOccurence> OrmRiskOccurences { get; set; } = new List<OrmRiskOccurence>();

    public virtual ICollection<OrmRole> OrmRoles { get; set; } = new List<OrmRole>();

    public virtual ICollection<OrmSource> OrmSources { get; set; } = new List<OrmSource>();

    public virtual ICollection<OrmTaskStatus> OrmTaskStatuses { get; set; } = new List<OrmTaskStatus>();

    public virtual ICollection<OrmTemplateProcess> OrmTemplateProcesses { get; set; } = new List<OrmTemplateProcess>();

    public virtual ICollection<OrmTemplate> OrmTemplates { get; set; } = new List<OrmTemplate>();

    public virtual ICollection<OrmmapTable> OrmmapTables { get; set; } = new List<OrmmapTable>();

    public virtual ICollection<OrmuserActivitiesLog> OrmuserActivitiesLogs { get; set; } = new List<OrmuserActivitiesLog>();

    public virtual ICollection<OrmuserAuditLog> OrmuserAuditLogs { get; set; } = new List<OrmuserAuditLog>();

    public virtual ICollection<OrmuserManagementLog> OrmuserManagementLogs { get; set; } = new List<OrmuserManagementLog>();

    public virtual ICollection<PasswordPolicy> PasswordPolicies { get; set; } = new List<PasswordPolicy>();

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<PolicyApprovalStage> PolicyApprovalStages { get; set; } = new List<PolicyApprovalStage>();

    public virtual ICollection<PolicyDeveloper> PolicyDevelopers { get; set; } = new List<PolicyDeveloper>();

    public virtual ICollection<PolicyMgmRole> PolicyMgmRoles { get; set; } = new List<PolicyMgmRole>();

    public virtual ICollection<PolicyMgmtUser> PolicyMgmtUsers { get; set; } = new List<PolicyMgmtUser>();

    public virtual ICollection<PolicyReader> PolicyReaders { get; set; } = new List<PolicyReader>();

    public virtual ICollection<PolicyReviewer> PolicyReviewers { get; set; } = new List<PolicyReviewer>();

    public virtual ICollection<PolicyReview> PolicyReviews { get; set; } = new List<PolicyReview>();

    public virtual ICollection<PolicyStatus> PolicyStatuses { get; set; } = new List<PolicyStatus>();

    public virtual ICollection<PolicyType> PolicyTypes { get; set; } = new List<PolicyType>();

    public virtual ICollection<ProductAssessmentHeader> ProductAssessmentHeaders { get; set; } = new List<ProductAssessmentHeader>();

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public virtual ICollection<ProductClassification> ProductClassifications { get; set; } = new List<ProductClassification>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<RcamAdvisoryCategory> RcamAdvisoryCategories { get; set; } = new List<RcamAdvisoryCategory>();

    public virtual ICollection<RcamAdvisoryPriority> RcamAdvisoryPriorities { get; set; } = new List<RcamAdvisoryPriority>();

    public virtual ICollection<RcamAdvisoryRequest> RcamAdvisoryRequests { get; set; } = new List<RcamAdvisoryRequest>();

    public virtual ICollection<RcamAdvisoryStatus> RcamAdvisoryStatuses { get; set; } = new List<RcamAdvisoryStatus>();

    public virtual ICollection<RcamAdvisoryType> RcamAdvisoryTypes { get; set; } = new List<RcamAdvisoryType>();

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual ICollection<RccmCmPriority> RccmCmPriorities { get; set; } = new List<RccmCmPriority>();

    public virtual ICollection<RccmCmStatus> RccmCmStatuses { get; set; } = new List<RccmCmStatus>();

    public virtual ICollection<RccmCmTaskStatus> RccmCmTaskStatuses { get; set; } = new List<RccmCmTaskStatus>();

    public virtual ICollection<RccmCmTask> RccmCmTasks { get; set; } = new List<RccmCmTask>();

    public virtual ICollection<RccmCmType> RccmCmTypes { get; set; } = new List<RccmCmType>();

    public virtual ICollection<RcmaAssessmentElementHeader> RcmaAssessmentElementHeaders { get; set; } = new List<RcmaAssessmentElementHeader>();

    public virtual ICollection<RcmaCalendarTask> RcmaCalendarTasks { get; set; } = new List<RcmaCalendarTask>();

    public virtual ICollection<RcmaDepartmentTaskScore> RcmaDepartmentTaskScores { get; set; } = new List<RcmaDepartmentTaskScore>();

    public virtual ICollection<RcmaElement> RcmaElements { get; set; } = new List<RcmaElement>();

    public virtual ICollection<RcmaMaturityCode> RcmaMaturityCodes { get; set; } = new List<RcmaMaturityCode>();

    public virtual ICollection<RcmaPrincipleType> RcmaPrincipleTypes { get; set; } = new List<RcmaPrincipleType>();

    public virtual ICollection<RcmaPrinciple> RcmaPrinciples { get; set; } = new List<RcmaPrinciple>();

    public virtual ICollection<RcmaStatus> RcmaStatuses { get; set; } = new List<RcmaStatus>();

    public virtual ICollection<RcmaTask> RcmaTasks { get; set; } = new List<RcmaTask>();

    public virtual ICollection<RcmaTemplate> RcmaTemplates { get; set; } = new List<RcmaTemplate>();

    public virtual ICollection<Region> Regions { get; set; } = new List<Region>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();

    public virtual ICollection<Status> Statuses { get; set; } = new List<Status>();

    public virtual ICollection<StrategicObjective> StrategicObjectives { get; set; } = new List<StrategicObjective>();

    public virtual ICollection<StrategicProgramProject> StrategicProgramProjects { get; set; } = new List<StrategicProgramProject>();

    public virtual ICollection<StrategicProgram> StrategicPrograms { get; set; } = new List<StrategicProgram>();

    public virtual ICollection<SubProduct> SubProducts { get; set; } = new List<SubProduct>();

    public virtual ICollection<UserBranch> UserBranches { get; set; } = new List<UserBranch>();

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();

    public virtual ICollection<UserDivision> UserDivisions { get; set; } = new List<UserDivision>();

    public virtual ICollection<WblowerCaseAction> WblowerCaseActions { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseAttachment> WblowerCaseAttachments { get; set; } = new List<WblowerCaseAttachment>();

    public virtual ICollection<WblowerCaseBreachDepartment> WblowerCaseBreachDepartments { get; set; } = new List<WblowerCaseBreachDepartment>();

    public virtual ICollection<WblowerCaseClassPosition> WblowerCaseClassPositions { get; set; } = new List<WblowerCaseClassPosition>();

    public virtual ICollection<WblowerCaseDepartment> WblowerCaseDepartments { get; set; } = new List<WblowerCaseDepartment>();

    public virtual ICollection<WblowerCaseEscPosition> WblowerCaseEscPositions { get; set; } = new List<WblowerCaseEscPosition>();

    public virtual ICollection<WblowerCaseResolution> WblowerCaseResolutions { get; set; } = new List<WblowerCaseResolution>();

    public virtual ICollection<WblowerCaseRisk> WblowerCaseRisks { get; set; } = new List<WblowerCaseRisk>();

    public virtual ICollection<WblowerCase> WblowerCases { get; set; } = new List<WblowerCase>();

    public virtual ICollection<WblowerClassPosition> WblowerClassPositions { get; set; } = new List<WblowerClassPosition>();

    public virtual ICollection<WblowerClassification> WblowerClassifications { get; set; } = new List<WblowerClassification>();

    public virtual ICollection<WblowerReportChannel> WblowerReportChannels { get; set; } = new List<WblowerReportChannel>();

    public virtual ICollection<WblowerReportClass> WblowerReportClasses { get; set; } = new List<WblowerReportClass>();
}
