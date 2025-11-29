using System;
using System.Collections.Generic;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Context;

public partial class ORMContext : DbContext
{
    public ORMContext()
    {
    }

    public ORMContext(DbContextOptions<ORMContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbcExtract> AbcExtracts { get; set; }

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<AiCombination> AiCombinations { get; set; }

    public virtual DbSet<AiCombinationDetail> AiCombinationDetails { get; set; }

    public virtual DbSet<AiCombinationRisk> AiCombinationRisks { get; set; }

    public virtual DbSet<AiKeyWord> AiKeyWords { get; set; }

    public virtual DbSet<ArchGrcUserActivitiesLog> ArchGrcUserActivitiesLogs { get; set; }

    public virtual DbSet<ArchGrcUserManagementLog> ArchGrcUserManagementLogs { get; set; }

    public virtual DbSet<ArchUserAuditLog> ArchUserAuditLogs { get; set; }

    public virtual DbSet<AspstateTempApplication> AspstateTempApplications { get; set; }

    public virtual DbSet<AspstateTempSession> AspstateTempSessions { get; set; }

    public virtual DbSet<AuditLossImpact> AuditLossImpacts { get; set; }

    public virtual DbSet<BcmBiaCriticality> BcmBiaCriticalities { get; set; }

    public virtual DbSet<BcmBiaFuntion> BcmBiaFuntions { get; set; }

    public virtual DbSet<BcmBiaFuntionProcess> BcmBiaFuntionProcesses { get; set; }

    public virtual DbSet<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; }

    public virtual DbSet<BcmBiaImpactAnalysis> BcmBiaImpactAnalyses { get; set; }

    public virtual DbSet<BcmBiaPlan> BcmBiaPlans { get; set; }

    public virtual DbSet<BcmBiaPlanElement> BcmBiaPlanElements { get; set; }

    public virtual DbSet<BcmBiaPlanElementTest> BcmBiaPlanElementTests { get; set; }

    public virtual DbSet<BcmBiaPlanImpactAnalysisDetailsTest> BcmBiaPlanImpactAnalysisDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanImpactAnalysisTest> BcmBiaPlanImpactAnalysisTests { get; set; }

    public virtual DbSet<BcmBiaPlanNotifiProcDetailsTest> BcmBiaPlanNotifiProcDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanNotifiProcTest> BcmBiaPlanNotifiProcTests { get; set; }

    public virtual DbSet<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; }

    public virtual DbSet<BcmBiaPlanProcessTest> BcmBiaPlanProcessTests { get; set; }

    public virtual DbSet<BcmBiaPlanRecTeamDetailsTest> BcmBiaPlanRecTeamDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanRecTeamTest> BcmBiaPlanRecTeamTests { get; set; }

    public virtual DbSet<BcmBiaPlanRecoveryDetailsTest> BcmBiaPlanRecoveryDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanRecoveryTest> BcmBiaPlanRecoveryTests { get; set; }

    public virtual DbSet<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanResourceTest> BcmBiaPlanResourceTests { get; set; }

    public virtual DbSet<BcmBiaPlanSchedule> BcmBiaPlanSchedules { get; set; }

    public virtual DbSet<BcmBiaPlanTest> BcmBiaPlanTests { get; set; }

    public virtual DbSet<BcmBiaPlanVendorDetailsTest> BcmBiaPlanVendorDetailsTests { get; set; }

    public virtual DbSet<BcmBiaPlanVendorTest> BcmBiaPlanVendorTests { get; set; }

    public virtual DbSet<BcmBiaRecovery> BcmBiaRecoveries { get; set; }

    public virtual DbSet<BcmBiaResource> BcmBiaResources { get; set; }

    public virtual DbSet<BcmBiaType> BcmBiaTypes { get; set; }

    public virtual DbSet<BcmBusinessImpact> BcmBusinessImpacts { get; set; }

    public virtual DbSet<BcmBusinessResponsibility> BcmBusinessResponsibilities { get; set; }

    public virtual DbSet<BcmBusinessRole> BcmBusinessRoles { get; set; }

    public virtual DbSet<BcmBusinessTitle> BcmBusinessTitles { get; set; }

    public virtual DbSet<BcmFunction> BcmFunctions { get; set; }

    public virtual DbSet<BcmFunctionDetail> BcmFunctionDetails { get; set; }

    public virtual DbSet<BcmImpactAnalysis> BcmImpactAnalyses { get; set; }

    public virtual DbSet<BcmLocation> BcmLocations { get; set; }

    public virtual DbSet<BcmPeriod> BcmPeriods { get; set; }

    public virtual DbSet<BcmPlan> BcmPlans { get; set; }

    public virtual DbSet<BcmPlanElement> BcmPlanElements { get; set; }

    public virtual DbSet<BcmPlanEventCategory> BcmPlanEventCategories { get; set; }

    public virtual DbSet<BcmPlanNotificationProc> BcmPlanNotificationProcs { get; set; }

    public virtual DbSet<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; }

    public virtual DbSet<BcmPlanVendorList> BcmPlanVendorLists { get; set; }

    public virtual DbSet<BcmProduct> BcmProducts { get; set; }

    public virtual DbSet<BcmResourceDetail> BcmResourceDetails { get; set; }

    public virtual DbSet<BcmResourceDetailsControl> BcmResourceDetailsControls { get; set; }

    public virtual DbSet<BcmResourceDetailsRisk> BcmResourceDetailsRisks { get; set; }

    public virtual DbSet<BcmResourceType> BcmResourceTypes { get; set; }

    public virtual DbSet<BcmSlaDetail> BcmSlaDetails { get; set; }

    public virtual DbSet<BcmStatus> BcmStatuses { get; set; }

    public virtual DbSet<BcmSupplierRole> BcmSupplierRoles { get; set; }

    public virtual DbSet<BcmTestResultStatus> BcmTestResultStatuses { get; set; }

    public virtual DbSet<BcmVendor> BcmVendors { get; set; }

    public virtual DbSet<Cbjclassification> Cbjclassifications { get; set; }

    public virtual DbSet<CbjclassificationHeader> CbjclassificationHeaders { get; set; }

    public virtual DbSet<ComRootCauseType> ComRootCauseTypes { get; set; }

    public virtual DbSet<CompActionDetail> CompActionDetails { get; set; }

    public virtual DbSet<CompBreachDepartment> CompBreachDepartments { get; set; }

    public virtual DbSet<CompCommType> CompCommTypes { get; set; }

    public virtual DbSet<CompCustomerCall> CompCustomerCalls { get; set; }

    public virtual DbSet<CompReceivedType> CompReceivedTypes { get; set; }

    public virtual DbSet<CompRecoveryMean> CompRecoveryMeans { get; set; }

    public virtual DbSet<CompRejectReason> CompRejectReasons { get; set; }

    public virtual DbSet<CompRootCause> CompRootCauses { get; set; }

    public virtual DbSet<CompRootCauseAttachment> CompRootCauseAttachments { get; set; }

    public virtual DbSet<CompStatus> CompStatuses { get; set; }

    public virtual DbSet<CompType> CompTypes { get; set; }

    public virtual DbSet<ConfigRullId> ConfigRullIds { get; set; }

    public virtual DbSet<ContactChannel> ContactChannels { get; set; }

    public virtual DbSet<CorresAttachFile> CorresAttachFiles { get; set; }

    public virtual DbSet<CorresCategory> CorresCategories { get; set; }

    public virtual DbSet<CorresLetter> CorresLetters { get; set; }

    public virtual DbSet<CorresLetterLink> CorresLetterLinks { get; set; }

    public virtual DbSet<CorresLetterToPerson> CorresLetterToPeople { get; set; }

    public virtual DbSet<CorresLettersDep> CorresLettersDeps { get; set; }

    public virtual DbSet<CorresOrgPerson> CorresOrgPeople { get; set; }

    public virtual DbSet<CorresOrganization> CorresOrganizations { get; set; }

    public virtual DbSet<CorresStatus> CorresStatuses { get; set; }

    public virtual DbSet<CorresType> CorresTypes { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }

    public virtual DbSet<CustomerDisabilityNeed> CustomerDisabilityNeeds { get; set; }

    public virtual DbSet<CustomerType> CustomerTypes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<ExtractRegulation> ExtractRegulations { get; set; }

    public virtual DbSet<ExtractSubRegulation> ExtractSubRegulations { get; set; }

    public virtual DbSet<FinancialLossRecoverySource> FinancialLossRecoverySources { get; set; }

    public virtual DbSet<FinancialLossType> FinancialLossTypes { get; set; }

    public virtual DbSet<GrcAccount> GrcAccounts { get; set; }

    public virtual DbSet<GrcApproveStatus> GrcApproveStatuses { get; set; }

    public virtual DbSet<GrcArchivingPolicy> GrcArchivingPolicies { get; set; }

    public virtual DbSet<GrcAuditDepBranch> GrcAuditDepBranches { get; set; }

    public virtual DbSet<GrcAuditEscalationAction> GrcAuditEscalationActions { get; set; }

    public virtual DbSet<GrcAuditFinding> GrcAuditFindings { get; set; }

    public virtual DbSet<GrcAuditFindingAttachment> GrcAuditFindingAttachments { get; set; }

    public virtual DbSet<GrcAuditFindingSubRegulation> GrcAuditFindingSubRegulations { get; set; }

    public virtual DbSet<GrcAuditFindingsRisk> GrcAuditFindingsRisks { get; set; }

    public virtual DbSet<GrcAuditIssueLink> GrcAuditIssueLinks { get; set; }

    public virtual DbSet<GrcAuditReport> GrcAuditReports { get; set; }

    public virtual DbSet<GrcAuditRiskRating> GrcAuditRiskRatings { get; set; }

    public virtual DbSet<GrcAuditSeverityClass> GrcAuditSeverityClasses { get; set; }

    public virtual DbSet<GrcAuditSource> GrcAuditSources { get; set; }

    public virtual DbSet<GrcBranch> GrcBranches { get; set; }

    public virtual DbSet<GrcBranchAttachFile> GrcBranchAttachFiles { get; set; }

    public virtual DbSet<GrcBreach> GrcBreaches { get; set; }

    public virtual DbSet<GrcBusinessFunctionJobTitle> GrcBusinessFunctionJobTitles { get; set; }

    public virtual DbSet<GrcBusinessUnitDepartment> GrcBusinessUnitDepartments { get; set; }

    public virtual DbSet<GrcBusinessUnitFunction> GrcBusinessUnitFunctions { get; set; }

    public virtual DbSet<GrcCalendarDepartment> GrcCalendarDepartments { get; set; }

    public virtual DbSet<GrcCalendarHoliday> GrcCalendarHolidays { get; set; }

    public virtual DbSet<GrcCalendarYear> GrcCalendarYears { get; set; }

    public virtual DbSet<GrcCollectionQuestionnaire> GrcCollectionQuestionnaires { get; set; }

    public virtual DbSet<GrcComplianceAdminDepartment> GrcComplianceAdminDepartments { get; set; }

    public virtual DbSet<GrcComply> GrcComplies { get; set; }

    public virtual DbSet<GrcControl> GrcControls { get; set; }

    public virtual DbSet<GrcControlBusinessUnit> GrcControlBusinessUnits { get; set; }

    public virtual DbSet<GrcControlClassSubjective> GrcControlClassSubjectives { get; set; }

    public virtual DbSet<GrcControlPropabilityClass> GrcControlPropabilityClasses { get; set; }

    public virtual DbSet<GrcControlType> GrcControlTypes { get; set; }

    public virtual DbSet<GrcControlUserAccess> GrcControlUserAccesses { get; set; }

    public virtual DbSet<GrcCountry> GrcCountries { get; set; }

    public virtual DbSet<GrcCrimeAttachment> GrcCrimeAttachments { get; set; }

    public virtual DbSet<GrcCrimeBusinessunit> GrcCrimeBusinessunits { get; set; }

    public virtual DbSet<GrcCrimeDetail> GrcCrimeDetails { get; set; }

    public virtual DbSet<GrcCrimeNature> GrcCrimeNatures { get; set; }

    public virtual DbSet<GrcCrimeReporting> GrcCrimeReportings { get; set; }

    public virtual DbSet<GrcCrimeSituation> GrcCrimeSituations { get; set; }

    public virtual DbSet<GrcCrimeStatus> GrcCrimeStatuses { get; set; }

    public virtual DbSet<GrcCriterion> GrcCriteria { get; set; }

    public virtual DbSet<GrcDataCollectionAnswer> GrcDataCollectionAnswers { get; set; }

    public virtual DbSet<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; }

    public virtual DbSet<GrcDataNonFinancialAttachFile> GrcDataNonFinancialAttachFiles { get; set; }

    public virtual DbSet<GrcDepartment> GrcDepartments { get; set; }

    public virtual DbSet<GrcDepartmentBreachRegulationMatrix> GrcDepartmentBreachRegulationMatrices { get; set; }

    public virtual DbSet<GrcDepartmentBreachsSource> GrcDepartmentBreachsSources { get; set; }

    public virtual DbSet<GrcDepartmentCriteriaRank> GrcDepartmentCriteriaRanks { get; set; }

    public virtual DbSet<GrcDepartmentRank> GrcDepartmentRanks { get; set; }

    public virtual DbSet<GrcDepartmentRegulationsMatrix> GrcDepartmentRegulationsMatrices { get; set; }

    public virtual DbSet<GrcDepartmentSubRegulation> GrcDepartmentSubRegulations { get; set; }

    public virtual DbSet<GrcEmail> GrcEmails { get; set; }

    public virtual DbSet<GrcEmailControl> GrcEmailControls { get; set; }

    public virtual DbSet<GrcEntity> GrcEntities { get; set; }

    public virtual DbSet<GrcEntityAssessmentDetail> GrcEntityAssessmentDetails { get; set; }

    public virtual DbSet<GrcEscalationAction> GrcEscalationActions { get; set; }

    public virtual DbSet<GrcEscalationMonitor> GrcEscalationMonitors { get; set; }

    public virtual DbSet<GrcEscalationStatus> GrcEscalationStatuses { get; set; }

    public virtual DbSet<GrcExtention> GrcExtentions { get; set; }

    public virtual DbSet<GrcExternalUserAccess> GrcExternalUserAccesses { get; set; }

    public virtual DbSet<GrcFinancialCollection> GrcFinancialCollections { get; set; }

    public virtual DbSet<GrcFinancialCollectionLevel2> GrcFinancialCollectionLevel2s { get; set; }

    public virtual DbSet<GrcFinancialRef> GrcFinancialRefs { get; set; }

    public virtual DbSet<GrcFinancialRefLevel2> GrcFinancialRefLevel2s { get; set; }

    public virtual DbSet<GrcFinancialRefLevelLink> GrcFinancialRefLevelLinks { get; set; }

    public virtual DbSet<GrcFinancialRefReg> GrcFinancialRefRegs { get; set; }

    public virtual DbSet<GrcFinancialRegulationsUser> GrcFinancialRegulationsUsers { get; set; }

    public virtual DbSet<GrcFinancialXmlattachment> GrcFinancialXmlattachments { get; set; }

    public virtual DbSet<GrcFunctionDetail> GrcFunctionDetails { get; set; }

    public virtual DbSet<GrcGoal> GrcGoals { get; set; }

    public virtual DbSet<GrcGoalDetailsBu> GrcGoalDetailsBus { get; set; }

    public virtual DbSet<GrcGoalsBu> GrcGoalsBus { get; set; }

    public virtual DbSet<GrcGoalsCategory> GrcGoalsCategories { get; set; }

    public virtual DbSet<GrcGoalsDetail> GrcGoalsDetails { get; set; }

    public virtual DbSet<GrcGovernorate> GrcGovernorates { get; set; }

    public virtual DbSet<GrcIndustry> GrcIndustries { get; set; }

    public virtual DbSet<GrcIntegrationApiCode> GrcIntegrationApiCodes { get; set; }

    public virtual DbSet<GrcIntegrationEntity> GrcIntegrationEntities { get; set; }

    public virtual DbSet<GrcIntegrationMonitor> GrcIntegrationMonitors { get; set; }

    public virtual DbSet<GrcIntegrationService> GrcIntegrationServices { get; set; }

    public virtual DbSet<GrcIntegrationStatus> GrcIntegrationStatuses { get; set; }

    public virtual DbSet<GrcIntegrationType> GrcIntegrationTypes { get; set; }

    public virtual DbSet<GrcIssuer> GrcIssuers { get; set; }

    public virtual DbSet<GrcJobTitle> GrcJobTitles { get; set; }

    public virtual DbSet<GrcLanguage> GrcLanguages { get; set; }

    public virtual DbSet<GrcMapAuditTable> GrcMapAuditTables { get; set; }

    public virtual DbSet<GrcMatrix> GrcMatrices { get; set; }

    public virtual DbSet<GrcMenu> GrcMenus { get; set; }

    public virtual DbSet<GrcMenuDetailsRole> GrcMenuDetailsRoles { get; set; }

    public virtual DbSet<GrcMenuItem> GrcMenuItems { get; set; }

    public virtual DbSet<GrcMenuItemDetail> GrcMenuItemDetails { get; set; }

    public virtual DbSet<GrcMenuItemRole> GrcMenuItemRoles { get; set; }

    public virtual DbSet<GrcMenuRole> GrcMenuRoles { get; set; }

    public virtual DbSet<GrcPage> GrcPages { get; set; }

    public virtual DbSet<GrcPasswordHistory> GrcPasswordHistories { get; set; }

    public virtual DbSet<GrcPriority> GrcPriorities { get; set; }

    public virtual DbSet<GrcProjectDepartment> GrcProjectDepartments { get; set; }

    public virtual DbSet<GrcRegulation> GrcRegulations { get; set; }

    public virtual DbSet<GrcRegulationCategory> GrcRegulationCategories { get; set; }

    public virtual DbSet<GrcRegulationControl> GrcRegulationControls { get; set; }

    public virtual DbSet<GrcRegulationLanguage> GrcRegulationLanguages { get; set; }

    public virtual DbSet<GrcRegulationLink> GrcRegulationLinks { get; set; }

    public virtual DbSet<GrcRegulationRisk> GrcRegulationRisks { get; set; }

    public virtual DbSet<GrcRegulationType> GrcRegulationTypes { get; set; }

    public virtual DbSet<GrcRegulationUserAccess> GrcRegulationUserAccesses { get; set; }

    public virtual DbSet<GrcRegulationsAttachment> GrcRegulationsAttachments { get; set; }

    public virtual DbSet<GrcRegulationsStagingAttachment> GrcRegulationsStagingAttachments { get; set; }

    public virtual DbSet<GrcRegulatoryReportingAttachment> GrcRegulatoryReportingAttachments { get; set; }

    public virtual DbSet<GrcRegulatoryReportingTrack> GrcRegulatoryReportingTracks { get; set; }

    public virtual DbSet<GrcResponsibilityType> GrcResponsibilityTypes { get; set; }

    public virtual DbSet<GrcRisk> GrcRisks { get; set; }

    public virtual DbSet<GrcRiskClassification> GrcRiskClassifications { get; set; }

    public virtual DbSet<GrcRiskFinAppetite> GrcRiskFinAppetites { get; set; }

    public virtual DbSet<GrcRiskNatureRule> GrcRiskNatureRules { get; set; }

    public virtual DbSet<GrcRiskProfile> GrcRiskProfiles { get; set; }

    public virtual DbSet<GrcRiskProfileEoy> GrcRiskProfileEoys { get; set; }

    public virtual DbSet<GrcRiskSubjective> GrcRiskSubjectives { get; set; }

    public virtual DbSet<GrcRiskType> GrcRiskTypes { get; set; }

    public virtual DbSet<GrcRole> GrcRoles { get; set; }

    public virtual DbSet<GrcRolePage> GrcRolePages { get; set; }

    public virtual DbSet<GrcSaqanswer> GrcSaqanswers { get; set; }

    public virtual DbSet<GrcSector> GrcSectors { get; set; }

    public virtual DbSet<GrcSelfAssessmentQuestionnaire> GrcSelfAssessmentQuestionnaires { get; set; }

    public virtual DbSet<GrcSelfAssessmentStatus> GrcSelfAssessmentStatuses { get; set; }

    public virtual DbSet<GrcSource> GrcSources { get; set; }

    public virtual DbSet<GrcStagingRegulation> GrcStagingRegulations { get; set; }

    public virtual DbSet<GrcStagingStatus> GrcStagingStatuses { get; set; }

    public virtual DbSet<GrcStagingSubRegulation> GrcStagingSubRegulations { get; set; }

    public virtual DbSet<GrcSubProductsDepartment> GrcSubProductsDepartments { get; set; }

    public virtual DbSet<GrcSubRegulation> GrcSubRegulations { get; set; }

    public virtual DbSet<GrcSubRegulationDepartmentActivity> GrcSubRegulationDepartmentActivities { get; set; }

    public virtual DbSet<GrcSubRegulationFunction> GrcSubRegulationFunctions { get; set; }

    public virtual DbSet<GrcSubRegulationRule> GrcSubRegulationRules { get; set; }

    public virtual DbSet<GrcTestAttachment> GrcTestAttachments { get; set; }

    public virtual DbSet<GrcTestDetail> GrcTestDetails { get; set; }

    public virtual DbSet<GrcTestDetailAction> GrcTestDetailActions { get; set; }

    public virtual DbSet<GrcTestDetailControl> GrcTestDetailControls { get; set; }

    public virtual DbSet<GrcTestHeader> GrcTestHeaders { get; set; }

    public virtual DbSet<GrcTheme> GrcThemes { get; set; }

    public virtual DbSet<GrcThemeDetail> GrcThemeDetails { get; set; }

    public virtual DbSet<GrcUser> GrcUsers { get; set; }

    public virtual DbSet<GrcUserActivitiesLog> GrcUserActivitiesLogs { get; set; }

    public virtual DbSet<GrcUserAuditLog> GrcUserAuditLogs { get; set; }

    public virtual DbSet<GrcUserDepartment> GrcUserDepartments { get; set; }

    public virtual DbSet<GrcUserManagementLog> GrcUserManagementLogs { get; set; }

    public virtual DbSet<GrcUserRole> GrcUserRoles { get; set; }

    public virtual DbSet<GrcVariable> GrcVariables { get; set; }

    public virtual DbSet<GrcWblowerCaseBranch> GrcWblowerCaseBranches { get; set; }

    public virtual DbSet<GrcWhistleblowerProcess> GrcWhistleblowerProcesses { get; set; }

    public virtual DbSet<GrcWhistleblowerRisk> GrcWhistleblowerRisks { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Institute> Institutes { get; set; }

    public virtual DbSet<IntegrationApiMonitor> IntegrationApiMonitors { get; set; }

    public virtual DbSet<IntegrationApiStatus> IntegrationApiStatuses { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<License> Licenses { get; set; }

    public virtual DbSet<LicensesDetail> LicensesDetails { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<MapCountry> MapCountries { get; set; }

    public virtual DbSet<OldgrcFinancialCollection> OldgrcFinancialCollections { get; set; }

    public virtual DbSet<OrmActionMonitor> OrmActionMonitors { get; set; }

    public virtual DbSet<OrmActionMonitorDetail> OrmActionMonitorDetails { get; set; }

    public virtual DbSet<OrmActionStatus> OrmActionStatuses { get; set; }

    public virtual DbSet<OrmAssessmentStatus> OrmAssessmentStatuses { get; set; }

    public virtual DbSet<OrmCategory> OrmCategories { get; set; }

    public virtual DbSet<OrmControlCategory> OrmControlCategories { get; set; }

    public virtual DbSet<OrmControlCategoryElement> OrmControlCategoryElements { get; set; }

    public virtual DbSet<OrmControlDesignEffective> OrmControlDesignEffectives { get; set; }

    public virtual DbSet<OrmControlEffectScore> OrmControlEffectScores { get; set; }

    public virtual DbSet<OrmEmail> OrmEmails { get; set; }

    public virtual DbSet<OrmEmailsControl> OrmEmailsControls { get; set; }

    public virtual DbSet<OrmInherentRiskScore> OrmInherentRiskScores { get; set; }

    public virtual DbSet<OrmKri> OrmKris { get; set; }

    public virtual DbSet<OrmKriDirection> OrmKriDirections { get; set; }

    public virtual DbSet<OrmKriEntry> OrmKriEntries { get; set; }

    public virtual DbSet<OrmKriPeriod> OrmKriPeriods { get; set; }

    public virtual DbSet<OrmKriProccessBl> OrmKriProccessBls { get; set; }

    public virtual DbSet<OrmKriProcess> OrmKriProcesses { get; set; }

    public virtual DbSet<OrmKriType> OrmKriTypes { get; set; }

    public virtual DbSet<OrmLossEvent> OrmLossEvents { get; set; }

    public virtual DbSet<OrmLossEventCategory> OrmLossEventCategories { get; set; }

    public virtual DbSet<OrmLossEventCauseOfLoss> OrmLossEventCauseOfLosses { get; set; }

    public virtual DbSet<OrmLossEventControl> OrmLossEventControls { get; set; }

    public virtual DbSet<OrmLossEventKri> OrmLossEventKris { get; set; }

    public virtual DbSet<OrmLossEventProcess> OrmLossEventProcesses { get; set; }

    public virtual DbSet<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; }

    public virtual DbSet<OrmLossEventProduct> OrmLossEventProducts { get; set; }

    public virtual DbSet<OrmLossEventRecoverySource> OrmLossEventRecoverySources { get; set; }

    public virtual DbSet<OrmLossEventRisk> OrmLossEventRisks { get; set; }

    public virtual DbSet<OrmLossEventStatus> OrmLossEventStatuses { get; set; }

    public virtual DbSet<OrmLossEventType> OrmLossEventTypes { get; set; }

    public virtual DbSet<OrmProcess> OrmProcesses { get; set; }

    public virtual DbSet<OrmProcessBlLink> OrmProcessBlLinks { get; set; }

    public virtual DbSet<OrmProcessControlLink> OrmProcessControlLinks { get; set; }

    public virtual DbSet<OrmProcessDetail> OrmProcessDetails { get; set; }

    public virtual DbSet<OrmProcessDetailBlwork> OrmProcessDetailBlworks { get; set; }

    public virtual DbSet<OrmProcessDetailBlworkDetail> OrmProcessDetailBlworkDetails { get; set; }

    public virtual DbSet<OrmProcessDetailBlworkDetailsRange> OrmProcessDetailBlworkDetailsRanges { get; set; }

    public virtual DbSet<OrmProcessRiskLink> OrmProcessRiskLinks { get; set; }

    public virtual DbSet<OrmProcessSubject> OrmProcessSubjects { get; set; }

    public virtual DbSet<OrmProcessType> OrmProcessTypes { get; set; }

    public virtual DbSet<OrmQuadrantValue> OrmQuadrantValues { get; set; }

    public virtual DbSet<OrmQuestionnaireAnswer> OrmQuestionnaireAnswers { get; set; }

    public virtual DbSet<OrmQuestionnnaire> OrmQuestionnnaires { get; set; }

    public virtual DbSet<OrmRbaControlAsesmnt> OrmRbaControlAsesmnts { get; set; }

    public virtual DbSet<OrmRbaControlProcessControl> OrmRbaControlProcessControls { get; set; }

    public virtual DbSet<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; }

    public virtual DbSet<OrmRbaProcessRiskAsesmntDetail> OrmRbaProcessRiskAsesmntDetails { get; set; }

    public virtual DbSet<OrmRbaProcessRiskAsesmntDetailsRange> OrmRbaProcessRiskAsesmntDetailsRanges { get; set; }

    public virtual DbSet<OrmRbaProcessRiskAsesmntWork> OrmRbaProcessRiskAsesmntWorks { get; set; }

    public virtual DbSet<OrmRbaRisk> OrmRbaRisks { get; set; }

    public virtual DbSet<OrmRbacontrolQuestAnswer> OrmRbacontrolQuestAnswers { get; set; }

    public virtual DbSet<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; }

    public virtual DbSet<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; }

    public virtual DbSet<OrmRcsaDueAsesmntRisk> OrmRcsaDueAsesmntRisks { get; set; }

    public virtual DbSet<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; }

    public virtual DbSet<OrmRcsaTask> OrmRcsaTasks { get; set; }

    public virtual DbSet<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; }

    public virtual DbSet<OrmRcsaTaskOfficer> OrmRcsaTaskOfficers { get; set; }

    public virtual DbSet<OrmRcsaTaskTemplate> OrmRcsaTaskTemplates { get; set; }

    public virtual DbSet<OrmRcsaofficerStatus> OrmRcsaofficerStatuses { get; set; }

    public virtual DbSet<OrmRcsaquestioniareAnswer> OrmRcsaquestioniareAnswers { get; set; }

    public virtual DbSet<OrmRcsataskRiskControlAttachment> OrmRcsataskRiskControlAttachments { get; set; }

    public virtual DbSet<OrmResidualRiskExposure> OrmResidualRiskExposures { get; set; }

    public virtual DbSet<OrmResidualRiskQuadrant> OrmResidualRiskQuadrants { get; set; }

    public virtual DbSet<OrmRiskCategory> OrmRiskCategories { get; set; }

    public virtual DbSet<OrmRiskClassification> OrmRiskClassifications { get; set; }

    public virtual DbSet<OrmRiskControlCategory> OrmRiskControlCategories { get; set; }

    public virtual DbSet<OrmRiskControlElement> OrmRiskControlElements { get; set; }

    public virtual DbSet<OrmRiskElement> OrmRiskElements { get; set; }

    public virtual DbSet<OrmRiskImpact> OrmRiskImpacts { get; set; }

    public virtual DbSet<OrmRiskOccurence> OrmRiskOccurences { get; set; }

    public virtual DbSet<OrmRole> OrmRoles { get; set; }

    public virtual DbSet<OrmRoleUser> OrmRoleUsers { get; set; }

    public virtual DbSet<OrmSource> OrmSources { get; set; }

    public virtual DbSet<OrmTaskStatus> OrmTaskStatuses { get; set; }

    public virtual DbSet<OrmTasksCalendar> OrmTasksCalendars { get; set; }

    public virtual DbSet<OrmTemplate> OrmTemplates { get; set; }

    public virtual DbSet<OrmTemplateProcess> OrmTemplateProcesses { get; set; }

    public virtual DbSet<OrmmapTable> OrmmapTables { get; set; }

    public virtual DbSet<OrmraCategory> OrmraCategories { get; set; }

    public virtual DbSet<OrmraClassification> OrmraClassifications { get; set; }

    public virtual DbSet<OrmraElement> OrmraElements { get; set; }

    public virtual DbSet<OrmraElementDetail> OrmraElementDetails { get; set; }

    public virtual DbSet<OrmraElementDetailRange> OrmraElementDetailRanges { get; set; }

    public virtual DbSet<OrmraElementRange> OrmraElementRanges { get; set; }

    public virtual DbSet<OrmrbaRiskDetail> OrmrbaRiskDetails { get; set; }

    public virtual DbSet<OrmrbaRiskDetailsRange> OrmrbaRiskDetailsRanges { get; set; }

    public virtual DbSet<OrmrbaRiskWork> OrmrbaRiskWorks { get; set; }

    public virtual DbSet<OrmriskGoal> OrmriskGoals { get; set; }

    public virtual DbSet<OrmuserActivitiesLog> OrmuserActivitiesLogs { get; set; }

    public virtual DbSet<OrmuserAuditLog> OrmuserAuditLogs { get; set; }

    public virtual DbSet<OrmuserManagementLog> OrmuserManagementLogs { get; set; }

    public virtual DbSet<PasswordPolicy> PasswordPolicies { get; set; }

    public virtual DbSet<Policy> Policies { get; set; }

    public virtual DbSet<PolicyApprovalStage> PolicyApprovalStages { get; set; }

    public virtual DbSet<PolicyDeveloper> PolicyDevelopers { get; set; }

    public virtual DbSet<PolicyFile> PolicyFiles { get; set; }

    public virtual DbSet<PolicyFollowUpReview> PolicyFollowUpReviews { get; set; }

    public virtual DbSet<PolicyMgmRole> PolicyMgmRoles { get; set; }

    public virtual DbSet<PolicyMgmtUser> PolicyMgmtUsers { get; set; }

    public virtual DbSet<PolicyReader> PolicyReaders { get; set; }

    public virtual DbSet<PolicyRejectReasonLog> PolicyRejectReasonLogs { get; set; }

    public virtual DbSet<PolicyReview> PolicyReviews { get; set; }

    public virtual DbSet<PolicyReviewer> PolicyReviewers { get; set; }

    public virtual DbSet<PolicyStatus> PolicyStatuses { get; set; }

    public virtual DbSet<PolicyType> PolicyTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductAssessmentDetail> ProductAssessmentDetails { get; set; }

    public virtual DbSet<ProductAssessmentHeader> ProductAssessmentHeaders { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductCategoryIndicator> ProductCategoryIndicators { get; set; }

    public virtual DbSet<ProductClassification> ProductClassifications { get; set; }

    public virtual DbSet<ProductIndicatorLink> ProductIndicatorLinks { get; set; }

    public virtual DbSet<RcamAdvisoryActionAttachment> RcamAdvisoryActionAttachments { get; set; }

    public virtual DbSet<RcamAdvisoryCategory> RcamAdvisoryCategories { get; set; }

    public virtual DbSet<RcamAdvisoryPriority> RcamAdvisoryPriorities { get; set; }

    public virtual DbSet<RcamAdvisoryRequest> RcamAdvisoryRequests { get; set; }

    public virtual DbSet<RcamAdvisoryRequestAction> RcamAdvisoryRequestActions { get; set; }

    public virtual DbSet<RcamAdvisoryRequestAttachment> RcamAdvisoryRequestAttachments { get; set; }

    public virtual DbSet<RcamAdvisoryRequestSubRequlation> RcamAdvisoryRequestSubRequlations { get; set; }

    public virtual DbSet<RcamAdvisoryRequestUser> RcamAdvisoryRequestUsers { get; set; }

    public virtual DbSet<RcamAdvisoryStatus> RcamAdvisoryStatuses { get; set; }

    public virtual DbSet<RcamAdvisoryType> RcamAdvisoryTypes { get; set; }

    public virtual DbSet<RccmAttachment> RccmAttachments { get; set; }

    public virtual DbSet<RccmChangeManagement> RccmChangeManagements { get; set; }

    public virtual DbSet<RccmCmPriority> RccmCmPriorities { get; set; }

    public virtual DbSet<RccmCmStatus> RccmCmStatuses { get; set; }

    public virtual DbSet<RccmCmTask> RccmCmTasks { get; set; }

    public virtual DbSet<RccmCmTaskDetail> RccmCmTaskDetails { get; set; }

    public virtual DbSet<RccmCmTaskStatus> RccmCmTaskStatuses { get; set; }

    public virtual DbSet<RccmCmType> RccmCmTypes { get; set; }

    public virtual DbSet<RccmTaskUser> RccmTaskUsers { get; set; }

    public virtual DbSet<RccmTaskUserAction> RccmTaskUserActions { get; set; }

    public virtual DbSet<RcmaAssessmentElementDetail> RcmaAssessmentElementDetails { get; set; }

    public virtual DbSet<RcmaAssessmentElementHeader> RcmaAssessmentElementHeaders { get; set; }

    public virtual DbSet<RcmaAttachment> RcmaAttachments { get; set; }

    public virtual DbSet<RcmaCalendarTask> RcmaCalendarTasks { get; set; }

    public virtual DbSet<RcmaDepartmentTaskScore> RcmaDepartmentTaskScores { get; set; }

    public virtual DbSet<RcmaElement> RcmaElements { get; set; }

    public virtual DbSet<RcmaMaturityCode> RcmaMaturityCodes { get; set; }

    public virtual DbSet<RcmaPrinciple> RcmaPrinciples { get; set; }

    public virtual DbSet<RcmaPrincipleType> RcmaPrincipleTypes { get; set; }

    public virtual DbSet<RcmaStatus> RcmaStatuses { get; set; }

    public virtual DbSet<RcmaTask> RcmaTasks { get; set; }

    public virtual DbSet<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; }

    public virtual DbSet<RcmaTemplate> RcmaTemplates { get; set; }

    public virtual DbSet<RcmaTemplateElement> RcmaTemplateElements { get; set; }

    public virtual DbSet<RcmriskImpact> RcmriskImpacts { get; set; }

    public virtual DbSet<RcmriskOccurence> RcmriskOccurences { get; set; }

    public virtual DbSet<RcmsummaryDept> RcmsummaryDepts { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Section> Sections { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StrategicObjective> StrategicObjectives { get; set; }

    public virtual DbSet<StrategicProgram> StrategicPrograms { get; set; }

    public virtual DbSet<StrategicProgramProject> StrategicProgramProjects { get; set; }

    public virtual DbSet<SubProduct> SubProducts { get; set; }

    public virtual DbSet<SystemParameter> SystemParameters { get; set; }

    public virtual DbSet<UserBranch> UserBranches { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserDivision> UserDivisions { get; set; }

    public virtual DbSet<WblowerCase> WblowerCases { get; set; }

    public virtual DbSet<WblowerCaseAction> WblowerCaseActions { get; set; }

    public virtual DbSet<WblowerCaseAttachment> WblowerCaseAttachments { get; set; }

    public virtual DbSet<WblowerCaseBreachDepartment> WblowerCaseBreachDepartments { get; set; }

    public virtual DbSet<WblowerCaseClassPosition> WblowerCaseClassPositions { get; set; }

    public virtual DbSet<WblowerCaseDepartment> WblowerCaseDepartments { get; set; }

    public virtual DbSet<WblowerCaseEscPosition> WblowerCaseEscPositions { get; set; }

    public virtual DbSet<WblowerCaseResolution> WblowerCaseResolutions { get; set; }

    public virtual DbSet<WblowerCaseRisk> WblowerCaseRisks { get; set; }

    public virtual DbSet<WblowerClassPosition> WblowerClassPositions { get; set; }

    public virtual DbSet<WblowerClassification> WblowerClassifications { get; set; }

    public virtual DbSet<WblowerReportChannel> WblowerReportChannels { get; set; }

    public virtual DbSet<WblowerReportClass> WblowerReportClasses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AS");

        modelBuilder.Entity<AbcExtract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MbcExtract");

            entity.ToTable("AbcExtract");

            entity.HasIndex(e => e.AccountId, "IX_AbcExtract_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Abc).HasColumnName("ABC");
            entity.Property(e => e.Regid).HasColumnName("regid");
            entity.Property(e => e.Sub).HasColumnName("sub");

            entity.HasOne(d => d.Account).WithMany(p => p.AbcExtracts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AbcExtract_GRC_Accounts");
        });

        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_AggregatedCounter_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<AiCombination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AI_Combi__3214EC2704E30D6C");

            entity.ToTable("AI_Combination");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<AiCombinationDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AI_Combi__3214EC076760DD68");

            entity.ToTable("AI_Combination_Details");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Combination).WithMany(p => p.AiCombinationDetails)
                .HasForeignKey(d => d.CombinationId)
                .HasConstraintName("FK__AI_Combin__Combi__7C27ED21");

            entity.HasOne(d => d.KeyWord).WithMany(p => p.AiCombinationDetails)
                .HasForeignKey(d => d.KeyWordId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AI_Combin__KeyWo__7D1C115A");
        });

        modelBuilder.Entity<AiCombinationRisk>(entity =>
        {
            entity.ToTable("Ai_Combination_Risk");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Combination).WithMany(p => p.AiCombinationRisks)
                .HasForeignKey(d => d.CombinationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ai_Combination_Risk_AI_Combination");
        });

        modelBuilder.Entity<AiKeyWord>(entity =>
        {
            entity.ToTable("AI_KeyWord");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ArchGrcUserActivitiesLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ArchActivityLog");

            entity.ToTable("ArchGrcUserActivitiesLog");

            entity.Property(e => e.Activity).HasMaxLength(250);
            entity.Property(e => e.ActivityDate).HasColumnType("datetime");
            entity.Property(e => e.Businessname).HasMaxLength(200);
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        modelBuilder.Entity<ArchGrcUserManagementLog>(entity =>
        {
            entity.ToTable("ArchGrcUserManagementLog");

            entity.Property(e => e.ActivityUserName).HasMaxLength(250);
            entity.Property(e => e.BranchNameNew).HasMaxLength(250);
            entity.Property(e => e.BranchNameOld).HasMaxLength(250);
            entity.Property(e => e.CbChangeRequestAdminFlagOld).HasColumnName("cbChangeRequestAdminFlagOld");
            entity.Property(e => e.CbChangeRequestAdminFlagnew).HasColumnName("cbChangeRequestAdminFlagnew");
            entity.Property(e => e.DefaultActionUserNew).HasColumnName("default_action_userNew");
            entity.Property(e => e.DefaultActionUserOld).HasColumnName("default_action_userOld");
            entity.Property(e => e.JobTitleNew).HasMaxLength(250);
            entity.Property(e => e.JobTitleOld).HasMaxLength(250);
            entity.Property(e => e.RoleNameNew).HasMaxLength(250);
            entity.Property(e => e.RoleNameOld).HasMaxLength(250);
            entity.Property(e => e.UserNameNew).HasMaxLength(250);
            entity.Property(e => e.UserNameOld).HasMaxLength(250);
        });

        modelBuilder.Entity<ArchUserAuditLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Arch.UserAuditLog");

            entity.ToTable("ArchUserAuditLog");

            entity.Property(e => e.LogInDate).HasColumnType("datetime");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.UserName).HasMaxLength(250);
        });

        modelBuilder.Entity<AspstateTempApplication>(entity =>
        {
            entity.HasKey(e => e.AppId).HasName("PK__ASPState__8E2CF7F9DC5BF6FA");

            entity.ToTable("ASPStateTempApplications");

            entity.Property(e => e.AppId).ValueGeneratedNever();
            entity.Property(e => e.AppName)
                .HasMaxLength(280)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<AspstateTempSession>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__ASPState__C9F49290428BEE50");

            entity.ToTable("ASPStateTempSessions");

            entity.Property(e => e.SessionId).HasMaxLength(88);
            entity.Property(e => e.Created)
                .HasDefaultValueSql("(getutcdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Expires).HasColumnType("datetime");
            entity.Property(e => e.LockDate).HasColumnType("datetime");
            entity.Property(e => e.LockDateLocal).HasColumnType("datetime");
            entity.Property(e => e.SessionItemLong).HasColumnType("image");
            entity.Property(e => e.SessionItemShort).HasMaxLength(7000);
        });

        modelBuilder.Entity<AuditLossImpact>(entity =>
        {
            entity.ToTable("AuditLossImpact");

            entity.HasIndex(e => e.AccountId, "IX_AuditLossImpact_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseAmount).HasColumnType("decimal(14, 2)");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.FinancialRecoveryId).HasColumnName("financialRecoveryId");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LossAmount).HasColumnType("decimal(14, 2)");
            entity.Property(e => e.RecoveryAmount).HasColumnType("decimal(14, 2)");
            entity.Property(e => e.RecoveryDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.AuditLossImpacts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLossImpact_GRC_Accounts");

            entity.HasOne(d => d.BaseCurrency).WithMany(p => p.AuditLossImpactBaseCurrencies)
                .HasForeignKey(d => d.BaseCurrencyId)
                .HasConstraintName("FK_AuditLossImpact_Currency");

            entity.HasOne(d => d.CurrencyLossNavigation).WithMany(p => p.AuditLossImpactCurrencyLossNavigations)
                .HasForeignKey(d => d.CurrencyLoss)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLossImpact_Currency1");

            entity.HasOne(d => d.FinancialLossType).WithMany(p => p.AuditLossImpacts)
                .HasForeignKey(d => d.FinancialLossTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLossImpact_FinancialLossType");

            entity.HasOne(d => d.FinancialRecovery).WithMany(p => p.AuditLossImpacts)
                .HasForeignKey(d => d.FinancialRecoveryId)
                .HasConstraintName("FK_AuditLossImpact_FinancialLossRecoverySource");

            entity.HasOne(d => d.Issue).WithMany(p => p.AuditLossImpacts)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditLossImpact_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.RecoveryCurrencyNavigation).WithMany(p => p.AuditLossImpactRecoveryCurrencyNavigations)
                .HasForeignKey(d => d.RecoveryCurrency)
                .HasConstraintName("FK_AuditLossImpact_Currency2");
        });

        modelBuilder.Entity<BcmBiaCriticality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaCr__3214EC275583AC7D");

            entity.ToTable("BcmBiaCriticality");

            entity.HasIndex(e => e.Code, "IDX_BcmBiaCriticality_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaCriticality_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaCriticality_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaCriticality_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBiaCr__A25C5AA7CBABC26A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaCriticalities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaCriticality_AccountId");
        });

        modelBuilder.Entity<BcmBiaFuntion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaFu__3214EC271C30E2F6");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaFuntions_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaFuntions_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaFuntions_LastUpdatedBy");

            entity.HasIndex(e => e.OwnerId, "IDX_BcmBiaFuntions_OwnerId");

            entity.HasIndex(e => e.TypeId, "IDX_BcmBiaFuntions_TypeId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaFuntions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntions_AccountId");

            entity.HasOne(d => d.Crticality).WithMany(p => p.BcmBiaFuntions)
                .HasForeignKey(d => d.CrticalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntions_CrticalityId");

            entity.HasOne(d => d.Owner).WithMany(p => p.BcmBiaFuntions)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntions_OwnerId");

            entity.HasOne(d => d.Type).WithMany(p => p.BcmBiaFuntions)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntions_TypeId");
        });

        modelBuilder.Entity<BcmBiaFuntionProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaFu__3214EC27E79E3689");

            entity.ToTable("BcmBiaFuntionProcess");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaFuntionProcess_AccountId");

            entity.HasIndex(e => e.BiaFunctionId, "IDX_BcmBiaFuntionProcess_BiaFunctionId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaFuntionProcess_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaFuntionProcess_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaFuntionProcess_LastUpdatedBy");

            entity.HasIndex(e => e.ProcessDetailId, "IDX_BcmBiaFuntionProcess_ProcessDetailId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaFuntionProcesses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntionProcess_AccountId");

            entity.HasOne(d => d.BiaFunction).WithMany(p => p.BcmBiaFuntionProcesses)
                .HasForeignKey(d => d.BiaFunctionId)
                .HasConstraintName("FK_BcmBiaFuntionProcess_BiaFunctionId");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.BcmBiaFuntionProcesses)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntionProcess_ProcessDetailId");
        });

        modelBuilder.Entity<BcmBiaFuntionsBusinessUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaFu__3214EC279991E576");

            entity.HasIndex(e => e.BranchId, "IDX_BcmBiaFuntionsBusinessUnits_BranchId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaFuntionsBusinessUnits_CreatedBy");

            entity.HasIndex(e => e.DepartmentId, "IDX_BcmBiaFuntionsBusinessUnits_DepartmentId");

            entity.HasIndex(e => e.DivisionId, "IDX_BcmBiaFuntionsBusinessUnits_DivisionId");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaFuntionsBusinessUnits_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaFuntionsBusinessUnits_LastUpdatedBy");

            entity.HasIndex(e => e.UserId, "IDX_BcmBiaFuntionsBusinessUnits_User_Id");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.BcmBiaFuntionsBusinessUnits)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_BcmBiaFuntionsBusinessUnits_BranchId");

            entity.HasOne(d => d.Department).WithMany(p => p.BcmBiaFuntionsBusinessUnits)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_BcmBiaFuntionsBusinessUnits_DepartmentId");

            entity.HasOne(d => d.Division).WithMany(p => p.BcmBiaFuntionsBusinessUnits)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_BcmBiaFuntionsBusinessUnits_DivisionId");

            entity.HasOne(d => d.Funtion).WithMany(p => p.BcmBiaFuntionsBusinessUnits)
                .HasForeignKey(d => d.FuntionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaFuntionsBusinessUnits_FuntionId");

            entity.HasOne(d => d.User).WithMany(p => p.BcmBiaFuntionsBusinessUnits)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_BcmBiaFuntionsBusinessUnits_UserId");
        });

        modelBuilder.Entity<BcmBiaImpactAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaIm__3214EC27A8F69F10");

            entity.ToTable("BcmBiaImpactAnalysis");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaImpactAnalysis_AccountId");

            entity.HasIndex(e => e.BiaFunctionId, "IDX_BcmBiaImpactAnalysis_BiaFunctionId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaImpactAnalysis_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaImpactAnalysis_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaImpactAnalysis_LastUpdatedBy");

            entity.HasIndex(e => e.CrticalityId, "IDX_BcmBiaImpactAnalysis_RCrticalityId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaImpactAnalyses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaImpactAnalysis_AccountId");

            entity.HasOne(d => d.BiaFunction).WithMany(p => p.BcmBiaImpactAnalyses)
                .HasForeignKey(d => d.BiaFunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaImpactAnalysis_BiaFunctionId");

            entity.HasOne(d => d.Crticality).WithMany(p => p.BcmBiaImpactAnalyses)
                .HasForeignKey(d => d.CrticalityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaImpactAnalysis_CrticalityId");

            entity.HasOne(d => d.ImpactAnalysis).WithMany(p => p.BcmBiaImpactAnalyses)
                .HasForeignKey(d => d.ImpactAnalysisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaImpactAnalysis_ImpactAnalysisId");
        });

        modelBuilder.Entity<BcmBiaPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC273F6C91F4");

            entity.ToTable("BcmBiaPlan");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlan_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlan_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlan_LastUpdatedBy");

            entity.HasIndex(e => e.PlanId, "IDX_BcmBiaPlan_PlanId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlans)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlan_AccountId");

            entity.HasOne(d => d.Bia).WithMany(p => p.BcmBiaPlans)
                .HasForeignKey(d => d.BiaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlan_BiaId");

            entity.HasOne(d => d.Plan).WithMany(p => p.BcmBiaPlans)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlan_PlanId");
        });

        modelBuilder.Entity<BcmBiaPlanElement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC272A1B9F1B");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanElements_AccountId");

            entity.HasIndex(e => e.BiaPlanId, "IDX_BcmBiaPlanElements_BiaPlanId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanElements_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanElements_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanElements_LastUpdatedBy");

            entity.HasIndex(e => e.PlanElementId, "IDX_BcmBiaPlanElements_PlanElementId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanElements_AccountId");

            entity.HasOne(d => d.BiaPlan).WithMany(p => p.BcmBiaPlanElements)
                .HasForeignKey(d => d.BiaPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanElements_BiaId");

            entity.HasOne(d => d.PlanElement).WithMany(p => p.BcmBiaPlanElements)
                .HasForeignKey(d => d.PlanElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanElements_PlanElementId");
        });

        modelBuilder.Entity<BcmBiaPlanElementTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27FF199EDB");

            entity.ToTable("BcmBiaPlanElementTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanTestElements_AccountId");

            entity.HasIndex(e => e.BcmBiaPlanTestId, "IDX_BcmBiaPlanTestElements_BcmBiaPlanTestId");

            entity.HasIndex(e => e.BiaPlanElementId, "IDX_BcmBiaPlanTestElements_BiaPlanElementId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanTestElements_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanTestElements_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanTestElements_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanElementTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanTestElements_AccountId");

            entity.HasOne(d => d.BcmBiaPlanTest).WithMany(p => p.BcmBiaPlanElementTests)
                .HasForeignKey(d => d.BcmBiaPlanTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanTestElements_BcmBiaPlanTestId");

            entity.HasOne(d => d.BiaPlanElement).WithMany(p => p.BcmBiaPlanElementTests)
                .HasForeignKey(d => d.BiaPlanElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanTestElements_BiaPlanElementId");
        });

        modelBuilder.Entity<BcmBiaPlanImpactAnalysisDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27A0ACAC33");

            entity.ToTable("BcmBiaPlanImpactAnalysisDetailsTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_AccountId");

            entity.HasIndex(e => e.BiaImpactAnalysisId, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_BiaImpactAnalysisId");

            entity.HasIndex(e => e.BiaPlanImpactTestId, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_BiaPlanImpactTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_CreatedBy");

            entity.HasIndex(e => e.CriticalityIdAnswer, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_CriticalityIdAnswer");

            entity.HasIndex(e => e.CriticalityIdTestResult, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_CriticalityIdTestResult");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanImpactAnalysisDetailsTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanImpactAnalysisDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisDetailsTest_AccountId");

            entity.HasOne(d => d.BiaImpactAnalysis).WithMany(p => p.BcmBiaPlanImpactAnalysisDetailsTests)
                .HasForeignKey(d => d.BiaImpactAnalysisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisDetailsTest_BiaImpactAnalysisId");

            entity.HasOne(d => d.BiaPlanImpactTest).WithMany(p => p.BcmBiaPlanImpactAnalysisDetailsTests)
                .HasForeignKey(d => d.BiaPlanImpactTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisDetailsTest_BiaPlanImpactTestId");

            entity.HasOne(d => d.CriticalityIdAnswerNavigation).WithMany(p => p.BcmBiaPlanImpactAnalysisDetailsTestCriticalityIdAnswerNavigations)
                .HasForeignKey(d => d.CriticalityIdAnswer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisDetailsTest_CriticalityIdAnswer");

            entity.HasOne(d => d.CriticalityIdTestResultNavigation).WithMany(p => p.BcmBiaPlanImpactAnalysisDetailsTestCriticalityIdTestResultNavigations)
                .HasForeignKey(d => d.CriticalityIdTestResult)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisDetailsTest_CriticalityIdTestResult");
        });

        modelBuilder.Entity<BcmBiaPlanImpactAnalysisTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC279B47BE6C");

            entity.ToTable("BcmBiaPlanImpactAnalysisTest");

            entity.HasIndex(e => e.BiaPlanScheduleId, "IDX_BcmBiaPlanImpactAnalysisTest_BiaPlanScheduleId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanImpactAnalysisTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanImpactAnalysisTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanImpactAnalysisTest_LastUpdatedBy");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanImpactAnalysisTest_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanImpactAnalysisTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisTest_AccountId");

            entity.HasOne(d => d.BiaPlanSchedule).WithMany(p => p.BcmBiaPlanImpactAnalysisTests)
                .HasForeignKey(d => d.BiaPlanScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisTest_BiaPlanScheduleId");

            entity.HasOne(d => d.TestResult).WithMany(p => p.BcmBiaPlanImpactAnalysisTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanImpactAnalysisTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanNotifiProcDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC277E02C742");

            entity.ToTable("BcmBiaPlanNotifiProcDetailsTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanNotifiProcDetailsTest_AccountId");

            entity.HasIndex(e => e.BiaPlanNotifiProcTestId, "IDX_BcmBiaPlanNotifiProcDetailsTest_BiaPlanNotifiProcTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanNotifiProcDetailsTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanNotifiProcDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanNotifiProcDetailsTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanNotifiProcDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanNotifiProcDetailsTest_AccountId");

            entity.HasOne(d => d.BiaPlanNotifiProcTest).WithMany(p => p.BcmBiaPlanNotifiProcDetailsTests)
                .HasForeignKey(d => d.BiaPlanNotifiProcTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanNotifiProcDetailsTest_BiaPlanNotifiProcTest");
        });

        modelBuilder.Entity<BcmBiaPlanNotifiProcTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27E3627CD3");

            entity.ToTable("BcmBiaPlanNotifiProcTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmNotificationProcTestResult_AccountId");

            entity.HasIndex(e => e.BcmBiaPlanTestId, "IDX_BcmNotificationProcTestResult_BcmBiaPlanTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmNotificationProcTestResult_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmNotificationProcTestResult_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmNotificationProcTestResult_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanNotifiProcTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanNotifiProcTest_AccountId");

            entity.HasOne(d => d.BcmBiaPlanTest).WithMany(p => p.BcmBiaPlanNotifiProcTests)
                .HasForeignKey(d => d.BcmBiaPlanTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanNotifiProcTest_BcmBiaPlanTestId");
        });

        modelBuilder.Entity<BcmBiaPlanProcessRiskControlTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC276A2ED8A9");

            entity.ToTable("BcmBiaPlanProcessRiskControlTest");

            entity.HasIndex(e => e.BiaPlanProcessTestId, "IDX_BcmBiaPlanProcessRiskControlTest_BiaPlanProcessTestId");

            entity.HasIndex(e => e.ControlId, "IDX_BcmBiaPlanProcessRiskControlTest_ControlId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanProcessRiskControlTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanProcessRiskControlTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanProcessRiskControlTest_LastUpdatedBy");

            entity.HasIndex(e => e.ProcessId, "IDX_BcmBiaPlanProcessRiskControlTest_ProcessId");

            entity.HasIndex(e => e.RiskId, "IDX_BcmBiaPlanProcessRiskControlTest_RiskId");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanProcessRiskControlTest_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_AccountId");

            entity.HasOne(d => d.BiaPlanProcessTest).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.BiaPlanProcessTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_BiaPlanProcessTestId");

            entity.HasOne(d => d.Control).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.ControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_ControlId");

            entity.HasOne(d => d.Process).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_ProcessId");

            entity.HasOne(d => d.Risk).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_RiskId");

            entity.HasOne(d => d.TestResult).WithMany(p => p.BcmBiaPlanProcessRiskControlTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanProcessRiskControlTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanProcessTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC2701AC372C");

            entity.ToTable("BcmBiaPlanProcessTest");

            entity.HasIndex(e => e.BiaPlanScheduleId, "IDX_BcmBiaPlanProcessTest_BiaPlanScheduleId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanProcessTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanProcessTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanProcessTest_LastUpdatedBy");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanProcessTest_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanProcessTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessTest_AccountId");

            entity.HasOne(d => d.BiaPlanSchedule).WithMany(p => p.BcmBiaPlanProcessTests)
                .HasForeignKey(d => d.BiaPlanScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanProcessTest_BiaPlanScheduleId");

            entity.HasOne(d => d.TestResult).WithMany(p => p.BcmBiaPlanProcessTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanProcessTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanRecTeamDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC2703E39E5B");

            entity.ToTable("BcmBiaPlanRecTeamDetailsTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanRecTeamDetailsTest_AccountId");

            entity.HasIndex(e => e.BiaPlanRecTeamTestId, "IDX_BcmBiaPlanRecTeamDetailsTest_BiaPlanNotifiProcTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanRecTeamDetailsTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanRecTeamDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanRecTeamDetailsTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanRecTeamDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecTeamDetailsTest_AccountId");

            entity.HasOne(d => d.BiaPlanRecTeamTest).WithMany(p => p.BcmBiaPlanRecTeamDetailsTests)
                .HasForeignKey(d => d.BiaPlanRecTeamTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecTeamDetailsTest_BiaPlanRecTeamTestId");
        });

        modelBuilder.Entity<BcmBiaPlanRecTeamTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC2746035158");

            entity.ToTable("BcmBiaPlanRecTeamTest");

            entity.HasIndex(e => e.BcmBiaPlanTestId, "IDX_BcmBiaPlanRecTeamTest_BiaPlanRecoveryTeamId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanRecTeamTest_CreatedBy");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanRecTeamTest_CrticalityId");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanRecTeamTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanRecTeamTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanRecTeamTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecTeamTest_AccountId");

            entity.HasOne(d => d.BcmBiaPlanTest).WithMany(p => p.BcmBiaPlanRecTeamTests)
                .HasForeignKey(d => d.BcmBiaPlanTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecTeamTest_BcmBiaPlanTestId");
        });

        modelBuilder.Entity<BcmBiaPlanRecoveryDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27F9002C64");

            entity.ToTable("BcmBiaPlanRecoveryDetailsTest");

            entity.HasIndex(e => e.BiaPlanRecoveryTestId, "IDX_BcmBiaPlanRecoveryDetailsTest_BiaPlanRecoveryTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanRecoveryDetailsTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanRecoveryDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanRecoveryDetailsTest_LastUpdatedBy");

            entity.HasIndex(e => e.RpoPeriodId, "IDX_BcmBiaPlanRecoveryDetailsTest_RpoPeriodId");

            entity.HasIndex(e => e.RpoPeriodTestId, "IDX_BcmBiaPlanRecoveryDetailsTest_RpoPeriodTestId");

            entity.HasIndex(e => e.RtoPeriodId, "IDX_BcmBiaPlanRecoveryDetailsTest_RtoPeriodId");

            entity.HasIndex(e => e.RtoPeriodTestId, "IDX_BcmBiaPlanRecoveryDetailsTest_RtoPeriodTestId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanRecoveryDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_AccountId");

            entity.HasOne(d => d.BiaPlanRecoveryTest).WithMany(p => p.BcmBiaPlanRecoveryDetailsTests)
                .HasForeignKey(d => d.BiaPlanRecoveryTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_BiaPlanRecoveryTestId");

            entity.HasOne(d => d.RpoPeriod).WithMany(p => p.BcmBiaPlanRecoveryDetailsTestRpoPeriods)
                .HasForeignKey(d => d.RpoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_RpoPeriodId");

            entity.HasOne(d => d.RpoPeriodTest).WithMany(p => p.BcmBiaPlanRecoveryDetailsTestRpoPeriodTests)
                .HasForeignKey(d => d.RpoPeriodTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_RpoPeriodTestId");

            entity.HasOne(d => d.RtoPeriod).WithMany(p => p.BcmBiaPlanRecoveryDetailsTestRtoPeriods)
                .HasForeignKey(d => d.RtoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_RtoPeriodId");

            entity.HasOne(d => d.RtoPeriodTest).WithMany(p => p.BcmBiaPlanRecoveryDetailsTestRtoPeriodTests)
                .HasForeignKey(d => d.RtoPeriodTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryDetailsTest_RtoPeriodTestId");
        });

        modelBuilder.Entity<BcmBiaPlanRecoveryTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27736A601F");

            entity.ToTable("BcmBiaPlanRecoveryTest");

            entity.HasIndex(e => e.BiaPlanScheduleId, "IDX_BcmBiaPlanRecoveryTest_BiaPlanScheduleId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanRecoveryTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanRecoveryTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanRecoveryTest_LastUpdatedBy");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanRecoveryTest_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanRecoveryTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryTest_AccountId");

            entity.HasOne(d => d.BiaPlanSchedule).WithMany(p => p.BcmBiaPlanRecoveryTests)
                .HasForeignKey(d => d.BiaPlanScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanRecoveryTest_BiaPlanScheduleId");

            entity.HasOne(d => d.TestResult).WithMany(p => p.BcmBiaPlanRecoveryTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanRecoveryTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanResourceDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC274258FADE");

            entity.ToTable("BcmBiaPlanResourceDetailsTest");

            entity.HasIndex(e => e.BiaPlanResourceTestId, "IDX_BcmBiaPlanResourceDetailsTest_BiaPlanResourceTestId");

            entity.HasIndex(e => e.BiaResourceId, "IDX_BcmBiaPlanResourceDetailsTest_BiaResourceId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanResourceDetailsTest_CreatedBy");

            entity.HasIndex(e => e.FunctionDetailsId, "IDX_BcmBiaPlanResourceDetailsTest_FunctionDetailsId");

            entity.HasIndex(e => e.FunctionId, "IDX_BcmBiaPlanResourceDetailsTest_FunctionId");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanResourceDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanResourceDetailsTest_LastUpdatedBy");

            entity.HasIndex(e => e.ResourceDetailsId, "IDX_BcmBiaPlanResourceDetailsTest_ResourceDetailsId");

            entity.HasIndex(e => e.RpoPeriodId, "IDX_BcmBiaPlanResourceDetailsTest_RpoPeriodId");

            entity.HasIndex(e => e.RpoPeriodTestId, "IDX_BcmBiaPlanResourceDetailsTest_RpoPeriodTestId");

            entity.HasIndex(e => e.RtoPeriodId, "IDX_BcmBiaPlanResourceDetailsTest_RtoPeriodId");

            entity.HasIndex(e => e.RtoPeriodTestId, "IDX_BcmBiaPlanResourceDetailsTest_RtoPeriodTestId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_AccountId");

            entity.HasOne(d => d.BiaPlanResourceTest).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.BiaPlanResourceTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_BiaPlanResourceTestId");

            entity.HasOne(d => d.BiaResource).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.BiaResourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_BiaResourceId");

            entity.HasOne(d => d.FunctionDetails).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.FunctionDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_FunctionDetailsId");

            entity.HasOne(d => d.Function).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_FunctionId");

            entity.HasOne(d => d.ResourceDetails).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.ResourceDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_ResourceDetailsId");

            entity.HasOne(d => d.RpoPeriod).WithMany(p => p.BcmBiaPlanResourceDetailsTestRpoPeriods)
                .HasForeignKey(d => d.RpoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_RpoPeriodId");

            entity.HasOne(d => d.RpoPeriodTest).WithMany(p => p.BcmBiaPlanResourceDetailsTestRpoPeriodTests)
                .HasForeignKey(d => d.RpoPeriodTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_RpoPeriodTestId");

            entity.HasOne(d => d.RtoPeriod).WithMany(p => p.BcmBiaPlanResourceDetailsTestRtoPeriods)
                .HasForeignKey(d => d.RtoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_RtoPeriodId");

            entity.HasOne(d => d.RtoPeriodTest).WithMany(p => p.BcmBiaPlanResourceDetailsTestRtoPeriodTests)
                .HasForeignKey(d => d.RtoPeriodTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_RtoPeriodTestId");

            entity.HasOne(d => d.TestResultNavigation).WithMany(p => p.BcmBiaPlanResourceDetailsTests)
                .HasForeignKey(d => d.TestResultId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceDetailsTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanResourceTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC277BA6D7CD");

            entity.ToTable("BcmBiaPlanResourceTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanResourceTest_AccountId");

            entity.HasIndex(e => e.BiaPlanScheduleId, "IDX_BcmBiaPlanResourceTest_BiaPlanScheduleId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanResourceTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanResourceTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanResourceTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanResourceTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceTest_AccountId");

            entity.HasOne(d => d.BiaPlanSchedule).WithMany(p => p.BcmBiaPlanResourceTests)
                .HasForeignKey(d => d.BiaPlanScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanResourceTest_BiaPlanScheduleId");

            entity.HasOne(d => d.TestResultNavigation).WithMany(p => p.BcmBiaPlanResourceTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanResourceTest_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanSchedule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC27F0A956CA");

            entity.ToTable("BcmBiaPlanSchedule");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanSchedule_AccountId");

            entity.HasIndex(e => e.BiaPlanId, "IDX_BcmBiaPlanSchedule_BiaPlanId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanSchedule_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanSchedule_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanSchedule_LastUpdatedBy");

            entity.HasIndex(e => e.OvarlapApproveById, "IDX_BcmBiaPlanSchedule_OvarlapApproveById");

            entity.HasIndex(e => e.OwnerId, "IDX_BcmBiaPlanSchedule_OwnerId");

            entity.HasIndex(e => e.PeriodId, "IDX_BcmBiaPlanSchedule_PeriodId");

            entity.HasIndex(e => e.StatusId, "IDX_BcmBiaPlanSchedule_StatusId");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanSchedule_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CommencedDate).HasColumnType("datetime");
            entity.Property(e => e.CompletedDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ScheduleDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanSchedules)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanSchedule_AccountId");

            entity.HasOne(d => d.BiaPlan).WithMany(p => p.BcmBiaPlanSchedules)
                .HasForeignKey(d => d.BiaPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanSchedule_BiaPlanId");

            entity.HasOne(d => d.OvarlapApproveBy).WithMany(p => p.BcmBiaPlanScheduleOvarlapApproveBies)
                .HasForeignKey(d => d.OvarlapApproveById)
                .HasConstraintName("FK_BcmBiaPlanSchedule_OvarlapApproveById");

            entity.HasOne(d => d.Owner).WithMany(p => p.BcmBiaPlanScheduleOwners)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_BcmBiaPlanSchedule_OwnerId");

            entity.HasOne(d => d.Period).WithMany(p => p.BcmBiaPlanSchedules)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK_BcmBiaPlanSchedule_PeriodId");

            entity.HasOne(d => d.Status).WithMany(p => p.BcmBiaPlanSchedules)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanSchedule_StatusId");

            entity.HasOne(d => d.TestResult).WithMany(p => p.BcmBiaPlanSchedules)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmBiaPlanSchedule_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC277D3E921A");

            entity.ToTable("BcmBiaPlanTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanTest_AccountId");

            entity.HasIndex(e => e.BiaPlanScheduleId, "IDX_BcmBiaPlanTest_BiaPlanScheduleId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanTest_LastUpdatedBy");

            entity.HasIndex(e => e.TestResultId, "IDX_BcmBiaPlanTest_TestResultId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanElementsResults_AccountId");

            entity.HasOne(d => d.BiaPlanSchedule).WithMany(p => p.BcmBiaPlanTests)
                .HasForeignKey(d => d.BiaPlanScheduleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanElementsResults_BiaPlanScheduleId");

            entity.HasOne(d => d.TestResultNavigation).WithMany(p => p.BcmBiaPlanTests)
                .HasForeignKey(d => d.TestResultId)
                .HasConstraintName("FK_BcmPlanElementsResults_TestResultId");
        });

        modelBuilder.Entity<BcmBiaPlanVendorDetailsTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC277F5BB2EA");

            entity.ToTable("BcmBiaPlanVendorDetailsTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanVendorDetailsTest_AccountId");

            entity.HasIndex(e => e.BiaPlanVendorTestId, "IDX_BcmBiaPlanVendorDetailsTest_BiaPlanVendorTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanVendorDetailsTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanVendorDetailsTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanVendorDetailsTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanVendorDetailsTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanVendorDetailsTest_AccountId");

            entity.HasOne(d => d.BiaPlanVendorTest).WithMany(p => p.BcmBiaPlanVendorDetailsTests)
                .HasForeignKey(d => d.BiaPlanVendorTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanVendorDetailsTest_BiaPlanVendorTestId");
        });

        modelBuilder.Entity<BcmBiaPlanVendorTest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaPl__3214EC274076A6E1");

            entity.ToTable("BcmBiaPlanVendorTest");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlanVendorTest_AccountId");

            entity.HasIndex(e => e.BcmBiaPlanTestId, "IDX_BcmBiaPlanVendorTest_BcmBiaPlanTestId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaPlanVendorTest_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaPlanVendorTest_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaPlanVendorTest_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaPlanVendorTests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanVendorTest_AccountId");

            entity.HasOne(d => d.BcmBiaPlanTest).WithMany(p => p.BcmBiaPlanVendorTests)
                .HasForeignKey(d => d.BcmBiaPlanTestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaPlanVendorTest_BcmBiaPlanTestId");
        });

        modelBuilder.Entity<BcmBiaRecovery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaRe__3214EC2763E64F7A");

            entity.ToTable("BcmBiaRecovery");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaRecovery_AccountId");

            entity.HasIndex(e => e.BiaFunctionId, "IDX_BcmBiaRecovery_BiaFunctionId");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaRecovery_Id");

            entity.HasIndex(e => e.RpoPeriodId, "IDX_BcmBiaRecovery_RpoPeriodId");

            entity.HasIndex(e => e.RtoPeriodId, "IDX_BcmBiaRecovery_RtoPeriodId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaRecoveries)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaRecovery_AccountId");

            entity.HasOne(d => d.BiaFunction).WithMany(p => p.BcmBiaRecoveries)
                .HasForeignKey(d => d.BiaFunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaRecovery_BiaFunctionId");

            entity.HasOne(d => d.RpoPeriod).WithMany(p => p.BcmBiaRecoveryRpoPeriods)
                .HasForeignKey(d => d.RpoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaRecovery_RpoPeriod");

            entity.HasOne(d => d.RtoPeriod).WithMany(p => p.BcmBiaRecoveryRtoPeriods)
                .HasForeignKey(d => d.RtoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaRecovery_RtoPeriod");
        });

        modelBuilder.Entity<BcmBiaResource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaRe__3214EC270170893D");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaResources_AccountId");

            entity.HasIndex(e => e.BiaFunctionId, "IDX_BcmBiaResources_BiaFunctionId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaResources_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaResources_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaResources_LastUpdatedBy");

            entity.HasIndex(e => e.ResourceDetailId, "IDX_BcmBiaResources_ResourceDetailId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaResources)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaResources_AccountId");

            entity.HasOne(d => d.BiaFunction).WithMany(p => p.BcmBiaResources)
                .HasForeignKey(d => d.BiaFunctionId)
                .HasConstraintName("FK_BcmBiaResources_BiaFunctionId");

            entity.HasOne(d => d.ResourceDetail).WithMany(p => p.BcmBiaResources)
                .HasForeignKey(d => d.ResourceDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaResources_ResourceDetailId");
        });

        modelBuilder.Entity<BcmBiaType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBiaTy__3214EC27CF983C07");

            entity.ToTable("BcmBiaType");

            entity.HasIndex(e => e.Code, "IDX_BcmBiaType_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBiaType_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBiaType_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBiaType_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBiaTy__A25C5AA74FC7CEE8").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBiaTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBiaType_AccountId");
        });

        modelBuilder.Entity<BcmBusinessImpact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBusin__3214EC2791897EDF");

            entity.ToTable("BcmBusinessImpact");

            entity.HasIndex(e => e.Code, "IDX_BcmBusinessImpact_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBusinessImpact_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBusinessImpact_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBusinessImpact_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBusin__A25C5AA7E0DA500C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBusinessImpacts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBusinessImpact_AccountId");
        });

        modelBuilder.Entity<BcmBusinessResponsibility>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBusin__3214EC278ED7432C");

            entity.ToTable("BcmBusinessResponsibility");

            entity.HasIndex(e => e.Code, "IDX_BcmBusinessResponsibility_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBusinessResponsibility_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBusinessResponsibility_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBusinessResponsibility_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBusin__A25C5AA778649158").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBusinessResponsibilities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBusinessResponsibility_AccountId");
        });

        modelBuilder.Entity<BcmBusinessRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBusin__3214EC279F2C74AE");

            entity.ToTable("BcmBusinessRole");

            entity.HasIndex(e => e.Code, "IDX_BcmBusinessRole_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBusinessRole_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBusinessRole_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBusinessRole_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBusin__A25C5AA7F0161526").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBusinessRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBusinessRole_AccountId");
        });

        modelBuilder.Entity<BcmBusinessTitle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmBusin__3214EC277BC3361F");

            entity.HasIndex(e => e.Code, "IDX_BcmBusinessTitles_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmBusinessTitles_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmBusinessTitles_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmBusinessTitles_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmBusin__A25C5AA7346358B4").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmBusinessTitles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmBusinessTitles_AccountId");
        });

        modelBuilder.Entity<BcmFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmFunct__3214EC27C5545B3B");

            entity.HasIndex(e => e.Code, "IDX_BcmFunctions_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmFunctions_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmFunctions_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmFunctions_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmFunct__A25C5AA7E3CB9136").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmFunctions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmFunctions_AccountId");
        });

        modelBuilder.Entity<BcmFunctionDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmFunct__3214EC27556BB565");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmFunctionDetails_CreatedBy");

            entity.HasIndex(e => e.FunctionId, "IDX_BcmFunctionDetails_FunctionId");

            entity.HasIndex(e => e.Id, "IDX_BcmFunctionDetails_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmFunctionDetails_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Function).WithMany(p => p.BcmFunctionDetails)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmFunctionDetails_FunctionId");
        });

        modelBuilder.Entity<BcmImpactAnalysis>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmImpac__3214EC271D8E05F0");

            entity.ToTable("BcmImpactAnalysis");

            entity.HasIndex(e => e.AccountId, "IDX_BcmImpactAnalysis_AccountId");

            entity.HasIndex(e => e.Code, "IDX_BcmImpactAnalysis_Code");

            entity.HasIndex(e => e.Id, "IDX_BcmImpactAnalysis_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmImpactAnalysis_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmImpac__A25C5AA7937F5BFD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmImpactAnalyses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmImpactAnalysis_AccountId");
        });

        modelBuilder.Entity<BcmLocation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmLocat__3214EC279EAEFF97");

            entity.ToTable("BcmLocation");

            entity.HasIndex(e => e.Code, "IDX_BcmLocation_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmLocation_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmLocation_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmLocation_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmLocat__A25C5AA708F6912C").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmLocations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmLocation_AccountId");
        });

        modelBuilder.Entity<BcmPeriod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPerio__3214EC27E305BED6");

            entity.ToTable("BcmPeriod");

            entity.HasIndex(e => e.Code, "IDX_BcmPeriod_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPeriod_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPeriod_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPeriod_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmPerio__A25C5AA74DE7B11B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPeriods)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPeriod_AccountId");
        });

        modelBuilder.Entity<BcmPlan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlan__3214EC2788C2C631");

            entity.ToTable("BcmPlan");

            entity.HasIndex(e => e.AccountId, "IDX_BcmBiaPlan_AccountId");

            entity.HasIndex(e => e.AccountId, "IDX_BcmPlan_AccountId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlan_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPlan_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlan_LastUpdatedBy");

            entity.HasIndex(e => e.PlanEventCategoryId, "IDX_BcmPlan_PlanEventCategoryId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlans)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlan_AccountId");

            entity.HasOne(d => d.PlanEventCategory).WithMany(p => p.BcmPlans)
                .HasForeignKey(d => d.PlanEventCategoryId)
                .HasConstraintName("FK_BcmPlan_PlanEventCategoryId");
        });

        modelBuilder.Entity<BcmPlanElement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlanE__3214EC270A977F73");

            entity.HasIndex(e => e.Code, "IDX_BcmPlanElements_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlanElements_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPlanElements_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlanElements_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmPlanE__A25C5AA7CC84B09D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlanElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanElements_AccountId");
        });

        modelBuilder.Entity<BcmPlanEventCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlanE__3214EC2737B5E135");

            entity.ToTable("BcmPlanEventCategory");

            entity.HasIndex(e => e.Code, "IDX_BcmPlanEventCategory_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlanEventCategory_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPlanEventCategory_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlanEventCategory_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmPlanE__A25C5AA7CFB90A6B").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlanEventCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanEventCategory_AccountId");
        });

        modelBuilder.Entity<BcmPlanNotificationProc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlanN__3214EC271575BCA6");

            entity.ToTable("BcmPlanNotificationProc");

            entity.HasIndex(e => e.AccountId, "IDX_BcmPlanNotificationProc_AccountId");

            entity.HasIndex(e => e.BiaPlanId, "IDX_BcmPlanNotificationProc_BiaPlanId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlanNotificationProc_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPlanNotificationProc_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlanNotificationProc_LastUpdatedBy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlanNotificationProcs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanNotificationProc_AccountId");

            entity.HasOne(d => d.BiaPlan).WithMany(p => p.BcmPlanNotificationProcs)
                .HasForeignKey(d => d.BiaPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanNotificationProc_planBiaId");
        });

        modelBuilder.Entity<BcmPlanRecoveryTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlanR__3214EC271151D29A");

            entity.ToTable("BcmPlanRecoveryTeam");

            entity.HasIndex(e => e.AccountId, "IDX_BcmPlanRecoveryTeam_AccountId");

            entity.HasIndex(e => e.BiaPlanId, "IDX_BcmPlanRecoveryTeam_BiaPlanId");

            entity.HasIndex(e => e.BranchId, "IDX_BcmPlanRecoveryTeam_BranchId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlanRecoveryTeam_CreatedBy");

            entity.HasIndex(e => e.DepartmentId, "IDX_BcmPlanRecoveryTeam_DepartmentId");

            entity.HasIndex(e => e.DivisionId, "IDX_BcmPlanRecoveryTeam_DivisionId");

            entity.HasIndex(e => e.Id, "IDX_BcmPlanRecoveryTeam_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlanRecoveryTeam_LastUpdatedBy");

            entity.HasIndex(e => e.ResponsibilityId, "IDX_BcmPlanRecoveryTeam_ResponsibilityId");

            entity.HasIndex(e => e.RoleId, "IDX_BcmPlanRecoveryTeam_RoleId");

            entity.HasIndex(e => e.TitleId, "IDX_BcmPlanRecoveryTeam_TitleId");

            entity.HasIndex(e => e.UserId, "IDX_BcmPlanRecoveryTeam_UserId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_AccountId");

            entity.HasOne(d => d.BiaPlan).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.BiaPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_planBiaId");

            entity.HasOne(d => d.Branch).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_BranchId");

            entity.HasOne(d => d.Department).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_DepartmentId");

            entity.HasOne(d => d.Division).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_DivisonId");

            entity.HasOne(d => d.Responsibility).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.ResponsibilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_ResponsibilityId");

            entity.HasOne(d => d.Role).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_RoleId");

            entity.HasOne(d => d.Title).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.TitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_TitleId");

            entity.HasOne(d => d.User).WithMany(p => p.BcmPlanRecoveryTeams)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanRecoveryTeam_UserId");
        });

        modelBuilder.Entity<BcmPlanVendorList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmPlanV__3214EC272185787B");

            entity.ToTable("BcmPlanVendorList");

            entity.HasIndex(e => e.AccountId, "IDX_BcmPlanVendorList_AccountId");

            entity.HasIndex(e => e.BiaPlanId, "IDX_BcmPlanVendorList_BiaPlanId");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmPlanVendorList_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmPlanVendorList_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmPlanVendorList_LastUpdatedBy");

            entity.HasIndex(e => e.ProductId, "IDX_BcmPlanVendorList_ProductId");

            entity.HasIndex(e => e.SlaDetailId, "IDX_BcmPlanVendorList_SlaDetailId");

            entity.HasIndex(e => e.SupplierRoleId, "IDX_BcmPlanVendorList_SupplierRoleId");

            entity.HasIndex(e => e.VendorId, "IDX_BcmPlanVendorList_VendorId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_AccountId");

            entity.HasOne(d => d.BiaPlan).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.BiaPlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_planBiaId");

            entity.HasOne(d => d.Product).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_ProductId");

            entity.HasOne(d => d.SlaDetail).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.SlaDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_SlaDetailId");

            entity.HasOne(d => d.SupplierRole).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.SupplierRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_SupplierRoleId");

            entity.HasOne(d => d.Vendor).WithMany(p => p.BcmPlanVendorLists)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmPlanVendorList_VendorId");
        });

        modelBuilder.Entity<BcmProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmProdu__3214EC279BBFB014");

            entity.HasIndex(e => e.Code, "IDX_BcmProducts_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmProducts_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmProducts_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmProducts_LastUpdatedBy");

            entity.HasIndex(e => e.Slaid, "IDX_BcmProducts_SLAId");

            entity.HasIndex(e => e.VendorId, "IDX_BcmProducts_VendorId");

            entity.HasIndex(e => e.Code, "UQ__BcmProdu__A25C5AA7B2AE3C8D").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContactPerson).HasColumnName("Contact Person");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Slaid).HasColumnName("SLAId");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmProducts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmProducts_AccountId");

            entity.HasOne(d => d.Sla).WithMany(p => p.BcmProducts)
                .HasForeignKey(d => d.Slaid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmProducts_BcmSlaDetails");

            entity.HasOne(d => d.Vendor).WithMany(p => p.BcmProducts)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmProducts_VendorId");
        });

        modelBuilder.Entity<BcmResourceDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmResou__3214EC2785E62638");

            entity.HasIndex(e => e.FunctionDetailId, "IDX_FunctionDetailId");

            entity.HasIndex(e => e.FunctionId, "IDX_FunctionID");

            entity.HasIndex(e => e.BussinessImpactId, "IDX_ImpactId");

            entity.HasIndex(e => e.InherentRiskId, "IDX_InherentRiskId");

            entity.HasIndex(e => e.LocationId, "IDX_LocationId");

            entity.HasIndex(e => e.ResourceTypeId, "IDX_ResourceTypeId");

            entity.HasIndex(e => e.RiskOccurenceId, "IDX_RiskOccurenceId");

            entity.HasIndex(e => e.RpoPeriodId, "IDX_RpoPeriodId");

            entity.HasIndex(e => e.RiskImpactId, "IDX_RskImpactId");

            entity.HasIndex(e => e.RtoPeriodId, "IDX_RtoPeriodId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.InherentRiskId).HasColumnName("inherentRiskId");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmResourceDetails_AccountId");

            entity.HasOne(d => d.BussinessImpact).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.BussinessImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Impact");

            entity.HasOne(d => d.FunctionDetail).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.FunctionDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FunctionDetail");

            entity.HasOne(d => d.Function).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Function");

            entity.HasOne(d => d.InherentRisk).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.InherentRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InherentRisk");

            entity.HasOne(d => d.Location).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Location");

            entity.HasOne(d => d.ResourceType).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.ResourceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceType");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.RiskImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.BcmResourceDetails)
                .HasForeignKey(d => d.RiskOccurenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskOccurence");

            entity.HasOne(d => d.RpoPeriod).WithMany(p => p.BcmResourceDetailRpoPeriods)
                .HasForeignKey(d => d.RpoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RpoPeriod");

            entity.HasOne(d => d.RtoPeriod).WithMany(p => p.BcmResourceDetailRtoPeriods)
                .HasForeignKey(d => d.RtoPeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RtoPeriod");
        });

        modelBuilder.Entity<BcmResourceDetailsControl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmResou__3214EC276DA88B14");

            entity.HasIndex(e => e.Id, "IDX_BcmResourceDetailsControls_ID");

            entity.HasIndex(e => e.ResourceDetailsId, "IDX_BcmResourceDetailsControls_ResourceDetailsId");

            entity.HasIndex(e => e.ControlElementId, "IDX_BcmResourceDetailsControls_RiskElementId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ControlElement).WithMany(p => p.BcmResourceDetailsControls)
                .HasForeignKey(d => d.ControlElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskControls");

            entity.HasOne(d => d.ResourceDetails).WithMany(p => p.BcmResourceDetailsControls)
                .HasForeignKey(d => d.ResourceDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceDetailsControls");
        });

        modelBuilder.Entity<BcmResourceDetailsRisk>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmResou__3214EC27DB48E2E9");

            entity.ToTable("BcmResourceDetailsRisk");

            entity.HasIndex(e => e.Id, "IDX_BcmResourceDetailsRisk_ID");

            entity.HasIndex(e => e.ResourceDetailsId, "IDX_BcmResourceDetailsRisk_ResourceDetailsId");

            entity.HasIndex(e => e.RiskElementId, "IDX_BcmResourceDetailsRisk_RiskElementId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ResourceDetails).WithMany(p => p.BcmResourceDetailsRisks)
                .HasForeignKey(d => d.ResourceDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResourceDetails");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.BcmResourceDetailsRisks)
                .HasForeignKey(d => d.RiskElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskElement");
        });

        modelBuilder.Entity<BcmResourceType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmResou__3214EC272A28DAFC");

            entity.ToTable("BcmResourceType");

            entity.HasIndex(e => e.Code, "IDX_BcmResourceType_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmResourceType_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmResourceType_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmResourceType_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmResou__A25C5AA73AEBACE0").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmResourceTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmResourceType_AccountId");
        });

        modelBuilder.Entity<BcmSlaDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmSlaDe__3214EC2709DC0D09");

            entity.HasIndex(e => e.Code, "IDX_BcmSlaDetails_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmSlaDetails_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmSlaDetails_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmSlaDetails_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmSlaDe__A25C5AA7F3CF6F88").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.SlaexpiryDate)
                .HasColumnType("datetime")
                .HasColumnName("SLAExpiryDate");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmSlaDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmSlaDetails_AccountId");
        });

        modelBuilder.Entity<BcmStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmStatu__3214EC27CC6AB430");

            entity.ToTable("BcmStatus");

            entity.HasIndex(e => e.Code, "IDX_BcmStatus_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmStatus_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmStatus_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmStatus_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmStatu__A25C5AA7F011DD51").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmStatus_AccountId");
        });

        modelBuilder.Entity<BcmSupplierRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmSuppl__3214EC277599D4D0");

            entity.ToTable("BcmSupplierRole");

            entity.HasIndex(e => e.Code, "IDX_BcmSupplierRole_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmSupplierRole_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmSupplierRole_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmSupplierRole_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmSuppl__A25C5AA7024990FA").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmSupplierRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmSupplierRole_AccountId");
        });

        modelBuilder.Entity<BcmTestResultStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmTestR__3214EC2771984582");

            entity.ToTable("BcmTestResultStatus");

            entity.HasIndex(e => e.Code, "IDX_BcmTestResultStatus_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmTestResultStatus_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmTestResultStatus_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmTestResultStatus_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmTestR__A25C5AA7671B2040").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmTestResultStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmTestResultStatus_AccountId");
        });

        modelBuilder.Entity<BcmVendor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BcmVendo__3214EC270DB4D292");

            entity.HasIndex(e => e.Code, "IDX_BcmVendors_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_BcmVendors_CreatedBy");

            entity.HasIndex(e => e.Id, "IDX_BcmVendors_ID");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_BcmVendors_LastUpdatedBy");

            entity.HasIndex(e => e.Code, "UQ__BcmVendo__A25C5AA7DF759262").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.BcmVendors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmVendors_AccountId");

            entity.HasOne(d => d.SupplierRole).WithMany(p => p.BcmVendors)
                .HasForeignKey(d => d.SupplierRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BcmVendors_SupplierRoleId");
        });

        modelBuilder.Entity<Cbjclassification>(entity =>
        {
            entity.ToTable("CBJClassification");

            entity.HasIndex(e => e.AccountId, "IX_CBJClassification_GRC_Accounts");

            entity.Property(e => e.CbjclassHeaderId).HasColumnName("CBJClassHeaderId");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Cbjclassifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CBJClassification_GRC_Accounts");

            entity.HasOne(d => d.CbjclassHeader).WithMany(p => p.Cbjclassifications)
                .HasForeignKey(d => d.CbjclassHeaderId)
                .HasConstraintName("FK_CBJClassification_CBJClassificationHeader");
        });

        modelBuilder.Entity<CbjclassificationHeader>(entity =>
        {
            entity.ToTable("CBJClassificationHeader");

            entity.HasIndex(e => e.AccountId, "IX_CBJClassificationHeader_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CbjclassificationHeaders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CBJClassificationHeader_GRC_Accounts");
        });

        modelBuilder.Entity<ComRootCauseType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ComRootC__3214EC07DB163E8A");

            entity.HasIndex(e => e.AccountId, "IDX_AccountId");

            entity.HasIndex(e => e.Code, "IDX_Code");

            entity.HasIndex(e => e.CreatedBy, "IDX_CreatedBy");

            entity.HasIndex(e => e.LastUpdatedBy, "IDX_LastUpdatedBy");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.ComRootCauseTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_ComRootCauseTypes");
        });

        modelBuilder.Entity<CompActionDetail>(entity =>
        {
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpectedResolvedDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedRespondDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssignUser).WithMany(p => p.CompActionDetailAssignUsers)
                .HasForeignKey(d => d.AssignUserId)
                .HasConstraintName("FK_CompActionDetails_GRC_USERS1");

            entity.HasOne(d => d.Branch).WithMany(p => p.CompActionDetails)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_CompActionDetails_GRC_BRANCHESId");

            entity.HasOne(d => d.CustomerCall).WithMany(p => p.CompActionDetails)
                .HasForeignKey(d => d.CustomerCallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompActionDetails_CompActions");

            entity.HasOne(d => d.Department).WithMany(p => p.CompActionDetails)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CompActionDetails_GRC_Departments");

            entity.HasOne(d => d.EscalatedUser).WithMany(p => p.CompActionDetailEscalatedUsers)
                .HasForeignKey(d => d.EscalatedUserId)
                .HasConstraintName("FK_CompActionDetails_GRC_USERS");

            entity.HasOne(d => d.LoggedByUser).WithMany(p => p.CompActionDetailLoggedByUsers)
                .HasForeignKey(d => d.LoggedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompActionDetails_GRC_USERS2");

            entity.HasOne(d => d.Status).WithMany(p => p.CompActionDetails)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompActionDetails_CompStatus");
        });

        modelBuilder.Entity<CompBreachDepartment>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_CompBreachDepartments_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creationdate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompBreachDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompBreachDepartments_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.CompBreachDepartments)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_CompBreachDepartments_GRC_BRANCHES1");

            entity.HasOne(d => d.CustomerCall).WithMany(p => p.CompBreachDepartments)
                .HasForeignKey(d => d.CustomerCallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompBreachDepartments_CompCustomerCall");

            entity.HasOne(d => d.Department).WithMany(p => p.CompBreachDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompBreachDepartments_GRC_Departments");
        });

        modelBuilder.Entity<CompCommType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CommType");

            entity.ToTable("CompCommType");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CompCustomerCall>(entity =>
        {
            entity.ToTable("CompCustomerCall", tb => tb.HasTrigger("ROLLBACKONDELETE"));

            entity.HasIndex(e => e.AccountId, "IX_CompCustomerCall_GRC_Accounts");

            entity.HasIndex(e => e.CompReference, "IX_CompReferenceUK").IsUnique();

            entity.Property(e => e.BreachExist).HasDefaultValue(false);
            entity.Property(e => e.CbjclassId).HasColumnName("CBJClassId");
            entity.Property(e => e.CompReference).HasMaxLength(255);
            entity.Property(e => e.ComplaintUser).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.GovernorateId).HasColumnName("GovernorateID");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RespondBy).HasColumnType("datetime");
            entity.Property(e => e.SlaextendFlag).HasColumnName("SLAExtendFlag");
            entity.Property(e => e.UserComplaintDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_CompCustomerCall_GRC_BRANCHESId");

            entity.HasOne(d => d.Cbjclass).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.CbjclassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_CBJClassification");

            entity.HasOne(d => d.CompReceived).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.CompReceivedId)
                .HasConstraintName("FK_CompCustomerCall_CompReceivedTypesId");

            entity.HasOne(d => d.CompTypes).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.CompTypesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_CompTypesId");

            entity.HasOne(d => d.CustomerDetail).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.CustomerDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_CompCustomerDetails");

            entity.HasOne(d => d.Department).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CompCustomerCall_GRC_Departments");

            entity.HasOne(d => d.Governorate).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.GovernorateId)
                .HasConstraintName("FK_Gove_CompCustomerCall");

            entity.HasOne(d => d.Priority).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.PriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_GRC_Priority");

            entity.HasOne(d => d.Status).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_CompStatus");

            entity.HasOne(d => d.SubProduct).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.SubProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompCustomerCall_SubProduct");

            entity.HasOne(d => d.User).WithMany(p => p.CompCustomerCalls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_CompCustomerCall_GRC_USERS");
        });

        modelBuilder.Entity<CompReceivedType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Table_ReceivedType");

            entity.HasIndex(e => e.AccountId, "IX_CompReceivedTypes");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ReceivedType).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.CompReceivedTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompReceivedTypes_GRC_Accounts");
        });

        modelBuilder.Entity<CompRecoveryMean>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_CompRecoveryMeans");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompRecoveryMeans)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRecoveryMeans_GRC_Accounts");
        });

        modelBuilder.Entity<CompRejectReason>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_CompRejectReasons");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompRejectReasons)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRejectReasons_GRC_Accounts");
        });

        modelBuilder.Entity<CompRootCause>(entity =>
        {
            entity.ToTable("CompRootCause");

            entity.HasIndex(e => e.AccountId, "IX_CompRootCause");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RecoveryAmount).HasColumnType("decimal(18, 3)");
            entity.Property(e => e.ResolvedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRootCause_GRC_Accounts");

            entity.HasOne(d => d.ComRootType).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.ComRootTypeId)
                .HasConstraintName("FK_Type_ComRootCauseTypes");

            entity.HasOne(d => d.Currency).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_CouseCurrancy");

            entity.HasOne(d => d.CustomerCall).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.CustomerCallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRootCause_CompActions");

            entity.HasOne(d => d.RecoveryMean).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.RecoveryMeanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRootCause_CompRecoveryMeans");

            entity.HasOne(d => d.RejectReason).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.RejectReasonId)
                .HasConstraintName("FK_CompRootCause_CompRejectReasons");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.CompRootCauses)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_CompRootCause_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<CompRootCauseAttachment>(entity =>
        {
            entity.ToTable("CompRootCauseAttachment");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CompRootCause).WithMany(p => p.CompRootCauseAttachments)
                .HasForeignKey(d => d.CompRootCauseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompRootCauseAttachment_CompRootCause");
        });

        modelBuilder.Entity<CompStatus>(entity =>
        {
            entity.ToTable("CompStatus");

            entity.HasIndex(e => e.AccountId, "IX_CompStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompStatus_GRC_Accounts");
        });

        modelBuilder.Entity<CompType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ComplaintTypes");

            entity.HasIndex(e => e.AccountId, "IX_CompTypes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ComplaintType).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CompTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CompTypes_GRC_Accounts");
        });

        modelBuilder.Entity<ConfigRullId>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("config_rull_id");

            entity.HasIndex(e => e.AccountId, "IX_config_rull_id_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_config_rull_id_GRC_Accounts");
        });

        modelBuilder.Entity<ContactChannel>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_ContactChannels");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.ContactChannels)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactChannels_GRC_Accounts");
        });

        modelBuilder.Entity<CorresAttachFile>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Letter).WithMany(p => p.CorresAttachFiles)
                .HasForeignKey(d => d.LetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresAttachFiles_CorresLetters");
        });

        modelBuilder.Entity<CorresCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CorresCa__3214EC071334C9D4");

            entity.ToTable("CorresCategory");

            entity.HasIndex(e => new { e.Id, e.AccountId, e.Code }, "CorresCategoryIndex");

            entity.HasIndex(e => e.Code, "UQ__CorresCa__A25C5AA73D86C316").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CorresCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_CorresCategory");
        });

        modelBuilder.Entity<CorresLetter>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Dispatch).HasDefaultValue(false);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LetterDate).HasColumnType("datetime");
            entity.Property(e => e.RespnseByDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetters_GRC_Accounts");

            entity.HasOne(d => d.Category).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CorresLet__Categ__2759D01A");

            entity.HasOne(d => d.Department).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__CorresLet__Depar__284DF453");

            entity.HasOne(d => d.Org).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetters_CorresOrganisation");

            entity.HasOne(d => d.OrgPerson).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.OrgPersonId)
                .HasConstraintName("FK_CorresLetters_CorresOrgPerson");

            entity.HasOne(d => d.Regulation).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_CorresLetters_GRC_Regulations");

            entity.HasOne(d => d.Status).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetters_CorresStatus");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_CorresLetters_GRC_Sub_Regulations");

            entity.HasOne(d => d.Type).WithMany(p => p.CorresLetters)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetters_CorresType");
        });

        modelBuilder.Entity<CorresLetterLink>(entity =>
        {
            entity.ToTable("CorresLetterLink");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Letter).WithMany(p => p.CorresLetterLinkLetters)
                .HasForeignKey(d => d.LetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetterLink_CorresLetters");

            entity.HasOne(d => d.LinkedLetter).WithMany(p => p.CorresLetterLinkLinkedLetters)
                .HasForeignKey(d => d.LinkedLetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetterLink_CorresLetters1");
        });

        modelBuilder.Entity<CorresLetterToPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CorresLetterPerson");

            entity.ToTable("CorresLetterToPerson");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentuserName).HasMaxLength(500);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.CorresLetterToPeople)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_CorresLetterToPerson_GRC_Departments");

            entity.HasOne(d => d.Letter).WithMany(p => p.CorresLetterToPeople)
                .HasForeignKey(d => d.LetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresLetterPerson_CorresLetters");

            entity.HasOne(d => d.Person).WithMany(p => p.CorresLetterToPeople)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_CorresLetterPerson_CorresOrgPerson");
        });

        modelBuilder.Entity<CorresLettersDep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CorresLe__3214EC075DEBF4A0");

            entity.ToTable("CorresLettersDep");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CorresLettersDeps)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_CorresLettersDep");

            entity.HasOne(d => d.Department).WithMany(p => p.CorresLettersDeps)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentId_CorresLettersDep");

            entity.HasOne(d => d.Letter).WithMany(p => p.CorresLettersDeps)
                .HasForeignKey(d => d.LetterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LetterId_CorresLettersDep");
        });

        modelBuilder.Entity<CorresOrgPerson>(entity =>
        {
            entity.ToTable("CorresOrgPerson");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(500);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Account).WithMany(p => p.CorresOrgPeople)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresOrgPerson_GRC_Accounts");

            entity.HasOne(d => d.Org).WithMany(p => p.CorresOrgPeople)
                .HasForeignKey(d => d.OrgId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresOrgPerson_CorresOrganization");
        });

        modelBuilder.Entity<CorresOrganization>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CorresOrganisation");

            entity.ToTable("CorresOrganization");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Organization).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.CorresOrganizations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresOrganisation_GRC_Accounts");
        });

        modelBuilder.Entity<CorresStatus>(entity =>
        {
            entity.ToTable("CorresStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CorresStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CorresStatus_GRC_Accounts");
        });

        modelBuilder.Entity<CorresType>(entity =>
        {
            entity.ToTable("CorresType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany(p => p.CorresTypes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_CorresType_GRC_Accounts");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.HasIndex(e => e.Code, "IX_Country").IsUnique();

            entity.Property(e => e.Code).HasMaxLength(25);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.ToTable("Currency");

            entity.HasIndex(e => e.AccountId, "IX_Currency_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BaseCurrency).HasDefaultValue(false);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Currencies)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Currency_GRC_Accounts");
        });

        modelBuilder.Entity<CustomerDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CompCustomerDetails");

            entity.HasIndex(e => e.AccountId, "IX_CustomerDetails_GRC_Accounts");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateofBirth).HasColumnType("datetime");
            entity.Property(e => e.FaxNumber).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            entity.Property(e => e.SocialSecurityNumber).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDetails_GRC_Accounts");

            entity.HasOne(d => d.ContactChannel).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.ContactChannelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDetails_ContactChannels");

            entity.HasOne(d => d.CustomerDisability).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.CustomerDisabilityId)
                .HasConstraintName("FK_CustomerDetails_CustomerDisabilityNeeds");

            entity.HasOne(d => d.CustomerType).WithMany(p => p.CustomerDetails)
                .HasForeignKey(d => d.CustomerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerDetails_CustomerType");
        });

        modelBuilder.Entity<CustomerDisabilityNeed>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerType>(entity =>
        {
            entity.ToTable("CustomerType");

            entity.HasIndex(e => e.Code, "CustomerTypeCode");

            entity.HasIndex(e => e.AccountId, "IX_CustomerType");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.CustomerTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CustomerType_GRC_Accounts");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.HasIndex(e => e.Code, "IX_Department").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_Department_GRC_Accounts");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.Departments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_GRC_Accounts");

            entity.HasOne(d => d.Institute).WithMany(p => p.Departments)
                .HasForeignKey(d => d.InstituteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Department_Institute");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_AuditDivision");

            entity.ToTable("Division");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditDivision_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditDivision_GRC_Departments");
        });

        modelBuilder.Entity<ExtractRegulation>(entity =>
        {
            entity.ToTable("Extract_Regulations");

            entity.HasIndex(e => e.AccountId, "IX_Extract_Regulations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .HasColumnName("Country_Name");
            entity.Property(e => e.IssuerName)
                .HasMaxLength(255)
                .HasColumnName("Issuer_Name");
            entity.Property(e => e.RegulationDescription).HasColumnName("Regulation_Description");
            entity.Property(e => e.RegulationEffectiveDate)
                .HasColumnType("datetime")
                .HasColumnName("Regulation_EffectiveDate");
            entity.Property(e => e.RegulationIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("Regulation_Issue_Date");
            entity.Property(e => e.RegulationReference).HasColumnName("Regulation_Reference");
            entity.Property(e => e.RegulationReferenceOtherLang).HasColumnName("Regulation_ReferenceOtherLang");
            entity.Property(e => e.RegulationSubjectOtherLang).HasColumnName("Regulation_SubjectOtherLang");
            entity.Property(e => e.RegulationType).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.ExtractRegulations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Extract_Regulations_GRC_Accounts");
        });

        modelBuilder.Entity<ExtractSubRegulation>(entity =>
        {
            entity.ToTable("Extract_SubRegulation");

            entity.HasIndex(e => e.AccountId, "IX_Extract_SubRegulation_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.RegReference).HasColumnName("Reg_Reference");
            entity.Property(e => e.SubRegulationDescription).HasColumnName("SubRegulation_Description");
            entity.Property(e => e.SubRegulationReference).HasColumnName("SubRegulation_Reference");

            entity.HasOne(d => d.Account).WithMany(p => p.ExtractSubRegulations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Extract_SubRegulation_GRC_Accounts");
        });

        modelBuilder.Entity<FinancialLossRecoverySource>(entity =>
        {
            entity.ToTable("FinancialLossRecoverySource");

            entity.HasIndex(e => e.AccountId, "IX_FinancialLossRecoverySource_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.FinancialLossRecoverySources)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_FinancialLossRecoverySource_GRC_Accounts");
        });

        modelBuilder.Entity<FinancialLossType>(entity =>
        {
            entity.ToTable("FinancialLossType");

            entity.HasIndex(e => e.AccountId, "IX_FinancialLossRecoverySource_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.FinancialLossTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FinancialLossType_GRC_Accounts");
        });

        modelBuilder.Entity<GrcAccount>(entity =>
        {
            entity.ToTable("GRC_Accounts");

            entity.Property(e => e.ActicateDate).HasColumnType("datetime");
            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.ComplaintNotification).HasDefaultValue(7);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DeactivateDate).HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Telephone).HasMaxLength(250);

            entity.HasOne(d => d.Industry).WithMany(p => p.GrcAccounts)
                .HasForeignKey(d => d.IndustryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Accounts_GRC_Industry");
        });

        modelBuilder.Entity<GrcApproveStatus>(entity =>
        {
            entity.ToTable("GRC_ApproveStatus");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ApproveStatus_GRC_Accounts");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcApproveStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ApproveStatus_GRC_Accounts");
        });

        modelBuilder.Entity<GrcArchivingPolicy>(entity =>
        {
            entity.ToTable("GRC_ArchivingPolicy");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ArchivingPolicy");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ArchiveTable).HasMaxLength(200);
            entity.Property(e => e.CrationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcArchivingPolicies)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ArchivingPolicy_GRC_Accounts");
        });

        modelBuilder.Entity<GrcAuditDepBranch>(entity =>
        {
            entity.HasKey(e => e.DepartmentAuditId);

            entity.ToTable("GRC_AUDIT_DEP_BRANCH");

            entity.Property(e => e.DepartmentAuditId).HasColumnName("Department_audit_id");
            entity.Property(e => e.AfiIssueId).HasColumnName("AFI_issue_id");
            entity.Property(e => e.BraBranchId).HasColumnName("Bra_branch_id");
            entity.Property(e => e.BreachFlag).HasColumnName("Breach_flag");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepDepartmentId).HasColumnName("DEP_department_Id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.AfiIssue).WithMany(p => p.GrcAuditDepBranches)
                .HasForeignKey(d => d.AfiIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_DEP_BRANCH_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.BraBranch).WithMany(p => p.GrcAuditDepBranches)
                .HasForeignKey(d => d.BraBranchId)
                .HasConstraintName("FK_GRC_AUDIT_DEP_BRANCH_GRC_BRANCHES");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcAuditDepBranches)
                .HasForeignKey(d => d.DepDepartmentId)
                .HasConstraintName("FK_GRC_AUDIT_DEP_BRANCH_GRC_Departments");
        });

        modelBuilder.Entity<GrcAuditEscalationAction>(entity =>
        {
            entity.HasKey(e => e.ActionId);

            entity.ToTable("GRC_AUDIT_ESCALATION_ACTION");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_ESCALATION_ACTION");

            entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");
            entity.Property(e => e.ActionTaken).HasColumnName("Action_Taken");
            entity.Property(e => e.AttachedFile)
                .HasMaxLength(200)
                .HasColumnName("Attached_File");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExpectedResolvedDate)
                .HasColumnType("datetime")
                .HasColumnName("Expected_Resolved_Date");
            entity.Property(e => e.FinIssueId).HasColumnName("Fin_Issue_Id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.LineNumber).HasColumnName("Line_number");
            entity.Property(e => e.UseActionUserId).HasColumnName("Use_action_user_id");
            entity.Property(e => e.UseApprovedBy).HasColumnName("Use_ApprovedBy");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditEscalationActions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ESCALATION_ACTION_GRC_Accounts");

            entity.HasOne(d => d.FinIssue).WithMany(p => p.GrcAuditEscalationActions)
                .HasForeignKey(d => d.FinIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ESCALATION_ACTION_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.Status).WithMany(p => p.GrcAuditEscalationActions)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_GRC_AUDIT_ESCALATION_ACTION_GRC_ESCALATION_STATUS");

            entity.HasOne(d => d.UseActionUser).WithMany(p => p.GrcAuditEscalationActionUseActionUsers)
                .HasForeignKey(d => d.UseActionUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ESCALATION_ACTION_GRC_USERS");

            entity.HasOne(d => d.UseApprovedByNavigation).WithMany(p => p.GrcAuditEscalationActionUseApprovedByNavigations)
                .HasForeignKey(d => d.UseApprovedBy)
                .HasConstraintName("FK_GRC_AUDIT_ESCALATION_ACTION_GRC_USERS1");
        });

        modelBuilder.Entity<GrcAuditFinding>(entity =>
        {
            entity.HasKey(e => e.IssueId);

            entity.ToTable("GRC_AUDIT_FINDINGS");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_FINDINGS_GRC_Accounts");

            entity.Property(e => e.IssueId).HasColumnName("Issue_id");
            entity.Property(e => e.AreAuditReportId).HasColumnName("are_audit_report_id");
            entity.Property(e => e.AscSeverityId).HasColumnName("Asc_severity_id");
            entity.Property(e => e.Comments).HasMaxLength(2000);
            entity.Property(e => e.CompletedBy).HasColumnName("Completed_By");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FindingDescription)
                .HasMaxLength(2000)
                .HasColumnName("Finding_Description");
            entity.Property(e => e.InitialEtaDate)
                .HasColumnType("datetime")
                .HasColumnName("Initial_eta_date");
            entity.Property(e => e.IssueReference)
                .HasMaxLength(200)
                .HasColumnName("Issue_reference");
            entity.Property(e => e.IssueSummary)
                .HasMaxLength(200)
                .HasColumnName("Issue_summary");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.OccuranceCount).HasColumnName("Occurance_count");
            entity.Property(e => e.Recommendations).HasMaxLength(2000);
            entity.Property(e => e.RegRegulationId).HasColumnName("Reg_regulation_id");
            entity.Property(e => e.ResolvedDate)
                .HasColumnType("datetime")
                .HasColumnName("Resolved_Date");
            entity.Property(e => e.ResponsibleParty).HasMaxLength(500);
            entity.Property(e => e.Risk).HasMaxLength(2000);
            entity.Property(e => e.RtRiskType).HasColumnName("RT_Risk_Type");
            entity.Property(e => e.SreRegulationId).HasColumnName("Sre_regulation_id");
            entity.Property(e => e.TdTestDetailId).HasColumnName("TD_TestDetailId");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_Accounts");

            entity.HasOne(d => d.AreAuditReport).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.AreAuditReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_AUDIT_REPORT");

            entity.HasOne(d => d.AscSeverity).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.AscSeverityId)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_AUDIT_SEVERITY_CLASS");

            entity.HasOne(d => d.AuditRiskRating).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.AuditRiskRatingId)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_AuditRiskRating");

            entity.HasOne(d => d.CompletedByNavigation).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.CompletedBy)
                .HasConstraintName("FK__GRC_AUDIT__Compl__43F60EC8");

            entity.HasOne(d => d.RegRegulation).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.RegRegulationId)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_Regulations");

            entity.HasOne(d => d.Riskclassification).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.Riskclassificationid)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_RISK_CLASSIFICATION");

            entity.HasOne(d => d.RtRiskTypeNavigation).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.RtRiskType)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_RiskType");

            entity.HasOne(d => d.SreRegulation).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.SreRegulationId)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_Sub_Regulations");

            entity.HasOne(d => d.Status).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__GRC_AUDIT__Statu__44EA3301");

            entity.HasOne(d => d.TdTestDetail).WithMany(p => p.GrcAuditFindings)
                .HasForeignKey(d => d.TdTestDetailId)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_GRC_Test_Details");
        });

        modelBuilder.Entity<GrcAuditFindingAttachment>(entity =>
        {
            entity.ToTable("GRC_Audit_Finding_Attachment");

            entity.HasIndex(e => e.IssueId, "IX_GRC_Audit_Finding_Attachment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Issue).WithMany(p => p.GrcAuditFindingAttachments)
                .HasForeignKey(d => d.IssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Audit_Finding_Attachment_GRC_AUDIT_FINDINGS");
        });

        modelBuilder.Entity<GrcAuditFindingSubRegulation>(entity =>
        {
            entity.ToTable("GRC_AuditFindingSubRegulation");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AuditFinding).WithMany(p => p.GrcAuditFindingSubRegulations)
                .HasForeignKey(d => d.AuditFindingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditFindingSubRegulation_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcAuditFindingSubRegulations)
                .HasForeignKey(d => d.RegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditFindingSubRegulation_GRC_Regulations");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcAuditFindingSubRegulations)
                .HasForeignKey(d => d.SubRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditFindingSubRegulation_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcAuditFindingsRisk>(entity =>
        {
            entity.HasKey(e => e.FinRiskId);

            entity.ToTable("GRC_AUDIT_FINDINGS_RISKS");

            entity.Property(e => e.FinRiskId).HasColumnName("Fin_Risk_Id");
            entity.Property(e => e.AfiIssueId).HasColumnName("AFI_issue_Id");
            entity.Property(e => e.RkRiskId).HasColumnName("RK_risk_Id");

            entity.HasOne(d => d.AfiIssue).WithMany(p => p.GrcAuditFindingsRisks)
                .HasForeignKey(d => d.AfiIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_RISKS_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.RkRisk).WithMany(p => p.GrcAuditFindingsRisks)
                .HasForeignKey(d => d.RkRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_FINDINGS_RISKS_GRC_Risks");
        });

        modelBuilder.Entity<GrcAuditIssueLink>(entity =>
        {
            entity.HasKey(e => e.IssueLinkId);

            entity.ToTable("GRC_AUDIT_ISSUE_LINK");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_ISSUE_LINK");

            entity.Property(e => e.IssueLinkId).HasColumnName("ISSUE_LINK_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.ParentAfiIssueId).HasColumnName("PARENT_AFI_ISSUE_ID");
            entity.Property(e => e.RelatedAfiIssueId).HasColumnName("RELATED_AFI_ISSUE_ID");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditIssueLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ISSUE_LINK_GRC_Accounts");

            entity.HasOne(d => d.ParentAfiIssue).WithMany(p => p.GrcAuditIssueLinkParentAfiIssues)
                .HasForeignKey(d => d.ParentAfiIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ISSUE_LINK_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.RelatedAfiIssue).WithMany(p => p.GrcAuditIssueLinkRelatedAfiIssues)
                .HasForeignKey(d => d.RelatedAfiIssueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_ISSUE_LINK_GRC_AUDIT_FINDINGS1");
        });

        modelBuilder.Entity<GrcAuditReport>(entity =>
        {
            entity.HasKey(e => e.AuditReportId);

            entity.ToTable("GRC_AUDIT_REPORT");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_REPORT");

            entity.Property(e => e.AuditReportId).HasColumnName("Audit_report_id");
            entity.Property(e => e.AsoAuditSourceId).HasColumnName("Aso_audit_source_id");
            entity.Property(e => e.AuditCoverageEnd)
                .HasColumnType("datetime")
                .HasColumnName("Audit_coverage_end");
            entity.Property(e => e.AuditCoverageStart)
                .HasColumnType("datetime")
                .HasColumnName("Audit_coverage_start");
            entity.Property(e => e.BraBranchId).HasColumnName("Bra_branch_id");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepAuditDept).HasColumnName("Dep_audit_dept");
            entity.Property(e => e.ExamNote)
                .HasMaxLength(200)
                .HasColumnName("Exam_Note");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.ReferenceNumber)
                .HasMaxLength(100)
                .HasColumnName("Reference_number");
            entity.Property(e => e.ReportIssueDate)
                .HasColumnType("datetime")
                .HasColumnName("Report_issue_date");
            entity.Property(e => e.ReviewerName)
                .HasMaxLength(200)
                .HasColumnName("Reviewer_name");
            entity.Property(e => e.Source).HasMaxLength(1);
            entity.Property(e => e.ThTestHeaderId).HasColumnName("TH_TestHeaderId");
            entity.Property(e => e.VisitEndDate)
                .HasColumnType("datetime")
                .HasColumnName("Visit_end_date");
            entity.Property(e => e.VisitStartDate)
                .HasColumnType("datetime")
                .HasColumnName("Visit_start_date");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_Accounts");

            entity.HasOne(d => d.AsoAuditSource).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.AsoAuditSourceId)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_AUDIT_SOURCE");

            entity.HasOne(d => d.BraBranch).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.BraBranchId)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_BRANCHES");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_Countries");

            entity.HasOne(d => d.DepAuditDeptNavigation).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.DepAuditDept)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_Departments");

            entity.HasOne(d => d.ThTestHeader).WithMany(p => p.GrcAuditReports)
                .HasForeignKey(d => d.ThTestHeaderId)
                .HasConstraintName("FK_GRC_AUDIT_REPORT_GRC_Test_Header");
        });

        modelBuilder.Entity<GrcAuditRiskRating>(entity =>
        {
            entity.ToTable("GRC_AuditRiskRating");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AuditRiskRating");

            entity.Property(e => e.Comments).HasMaxLength(500);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RiskRating).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditRiskRatings)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AuditRiskRating_GRC_Accounts");
        });

        modelBuilder.Entity<GrcAuditSeverityClass>(entity =>
        {
            entity.HasKey(e => e.SeverityId);

            entity.ToTable("GRC_AUDIT_SEVERITY_CLASS");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_SEVERITY_CLASS");

            entity.Property(e => e.SeverityId).HasColumnName("Severity_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.SeverityCode)
                .HasMaxLength(50)
                .HasColumnName("severity_CODE");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditSeverityClasses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_SEVERITY_CLASS_GRC_Accounts");
        });

        modelBuilder.Entity<GrcAuditSource>(entity =>
        {
            entity.HasKey(e => e.AuditSourceId);

            entity.ToTable("GRC_AUDIT_SOURCE");

            entity.HasIndex(e => e.AccountId, "IX_GRC_AUDIT_SOURCE");

            entity.Property(e => e.AuditSourceId).HasColumnName("Audit_source_id");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcAuditSources)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_SOURCE_CLASS_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcAuditSources)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_AUDIT_SOURCE_GRC_Countries");
        });

        modelBuilder.Entity<GrcBranch>(entity =>
        {
            entity.HasKey(e => e.BranchId);

            entity.ToTable("GRC_BRANCHES");

            entity.HasIndex(e => e.AccountId, "IX_GRC_BRANCHES");

            entity.Property(e => e.BranchId).HasColumnName("branch_ID");
            entity.Property(e => e.BranchCode)
                .HasMaxLength(50)
                .HasColumnName("Branch_Code");
            entity.Property(e => e.BranchEmail1)
                .HasMaxLength(200)
                .HasColumnName("Branch_Email1");
            entity.Property(e => e.BranchEmail2)
                .HasMaxLength(200)
                .HasColumnName("Branch_Email2");
            entity.Property(e => e.BranchName)
                .HasMaxLength(200)
                .HasColumnName("Branch_Name");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_country_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepDepartmentId).HasColumnName("Dep_Department_id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Pobox).HasColumnName("POBox");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcBranches)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BRANCHES_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcBranches)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BRANCHES_GRC_Countries");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcBranches)
                .HasForeignKey(d => d.DepDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BRANCHES_GRC_Departments");
        });

        modelBuilder.Entity<GrcBranchAttachFile>(entity =>
        {
            entity.ToTable("GRC_BranchAttachFile");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcBranchAttachFiles)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BranchAttachFile_GRC_BRANCHES");
        });

        modelBuilder.Entity<GrcBreach>(entity =>
        {
            entity.HasKey(e => e.BreachId);

            entity.ToTable("GRC_Breaches");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Breaches_GRC_Accounts");

            entity.Property(e => e.BreachId).HasColumnName("Breach_ID");
            entity.Property(e => e.AfiIssueId).HasColumnName("AFI_ISSUE_ID");
            entity.Property(e => e.BreachDate)
                .HasColumnType("datetime")
                .HasColumnName("Breach_Date");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.FCondition)
                .HasMaxLength(10)
                .HasColumnName("F_Condition");
            entity.Property(e => e.FPrecent)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("F_Precent");
            entity.Property(e => e.FRelation)
                .HasMaxLength(50)
                .HasColumnName("F_Relation");
            entity.Property(e => e.FVariable1)
                .HasMaxLength(30)
                .HasColumnName("F_Variable1");
            entity.Property(e => e.FVariable2)
                .HasMaxLength(50)
                .HasColumnName("F_Variable2");
            entity.Property(e => e.FirstValue)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("First_value");
            entity.Property(e => e.FirstValueCode)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("First_value_Code");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Lvl3Escl).HasColumnName("Lvl_3_Escl");
            entity.Property(e => e.NonFinId).HasColumnName("non_fin_id");
            entity.Property(e => e.RegRegulationId).HasColumnName("Reg_Regulation_id");
            entity.Property(e => e.RegRepId).HasColumnName("Reg_Rep_id");
            entity.Property(e => e.ResolutionDate)
                .HasColumnType("datetime")
                .HasColumnName("resolution_date");
            entity.Property(e => e.RiskLevel).HasColumnName("Risk_Level");
            entity.Property(e => e.SecondValue)
                .HasColumnType("decimal(18, 3)")
                .HasColumnName("Second_value");
            entity.Property(e => e.SecondValueCode)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("Second_value_code");
            entity.Property(e => e.SreSubRegulationId).HasColumnName("Sre_Sub_Regulation_id");
            entity.Property(e => e.SrrRuleId).HasColumnName("SRR_Rule_ID");
            entity.Property(e => e.UseResolvedByUserId).HasColumnName("Use_resolved_by_user_id");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Breaches_GRC_Accounts");

            entity.HasOne(d => d.AfiIssue).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.AfiIssueId)
                .HasConstraintName("FK_GRC_Breaches_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.CouCountryId)
                .HasConstraintName("FK_GRC_Breaches_Countries");

            entity.HasOne(d => d.CustomerCall).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.CustomerCallId)
                .HasConstraintName("FK_GRC_Breaches_CompCustomerCall");

            entity.HasOne(d => d.NonFin).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.NonFinId)
                .HasConstraintName("FK_GRC_Breaches_GRC_DATA_COLLECTION_NONFINANCIAL");

            entity.HasOne(d => d.RegRegulation).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.RegRegulationId)
                .HasConstraintName("FK_GRC_Breaches_GRC_Regulations");

            entity.HasOne(d => d.RegRep).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.RegRepId)
                .HasConstraintName("FK_GRC_Breaches_GRC_REGULATORY_REPORTING_TRACK");

            entity.HasOne(d => d.SreSubRegulation).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.SreSubRegulationId)
                .HasConstraintName("FK_GRC_Breaches_GRC_Sub_Regulations");

            entity.HasOne(d => d.SrrRule).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.SrrRuleId)
                .HasConstraintName("FK_GRC_Breaches_GRC_SUB_REGULATION_RULES");

            entity.HasOne(d => d.UseResolvedByUser).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.UseResolvedByUserId)
                .HasConstraintName("FK_GRC_Breaches_GRC_USERS");

            entity.HasOne(d => d.Wblower).WithMany(p => p.GrcBreaches)
                .HasForeignKey(d => d.WblowerId)
                .HasConstraintName("FK_GRC_Breaches_WblowerCases");
        });

        modelBuilder.Entity<GrcBusinessFunctionJobTitle>(entity =>
        {
            entity.ToTable("GRC_BusinessFunctionJobTitles");

            entity.HasIndex(e => e.AccountId, "IX_GRC_BusinessFunctionJobTitles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcBusinessFunctionJobTitles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessFunctionJobTitles_GRC_Accounts");

            entity.HasOne(d => d.Function).WithMany(p => p.GrcBusinessFunctionJobTitles)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessFunctionJobTitles_GRC_BusinessUnitFunction");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.GrcBusinessFunctionJobTitles)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessFunctionJobTitles_GRC_JobTitle");
        });

        modelBuilder.Entity<GrcBusinessUnitDepartment>(entity =>
        {
            entity.ToTable("GRC_BusinessUnitDepartments");

            entity.HasIndex(e => e.AccountId, "IX_GRC_BusinessUnitDepartments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcBusinessUnitDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessUnitDepartments_GRC_Accounts");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.GrcBusinessUnitDepartments)
                .HasForeignKey(d => d.BusinessUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessUnitDepartments_GRC_ControlBusinessUnit");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcBusinessUnitDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessUnitDepartments_GRC_Departments");
        });

        modelBuilder.Entity<GrcBusinessUnitFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_BussinessUnitFunctions");

            entity.ToTable("GRC_BusinessUnitFunction");

            entity.HasIndex(e => e.AccountId, "IX_GRC_BusinessUnitFunction");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcBusinessUnitFunctions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessUnitFunction_GRC_Accounts");

            entity.HasOne(d => d.BussinessUnit).WithMany(p => p.GrcBusinessUnitFunctions)
                .HasForeignKey(d => d.BussinessUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_BusinessUnitFunction_GRC_ControlBusinessUnit");
        });

        modelBuilder.Entity<GrcCalendarDepartment>(entity =>
        {
            entity.HasKey(e => e.CalendarId);

            entity.ToTable("GRC_CALENDAR_DEPARTMENT");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CALENDAR_DEPARTMENT");

            entity.Property(e => e.CalendarId).HasColumnName("Calendar_id");
            entity.Property(e => e.AfiIssueId).HasColumnName("AFI_Issue_Id");
            entity.Property(e => e.BrBranchId).HasColumnName("BR_Branch_Id");
            entity.Property(e => e.CalendarDate)
                .HasColumnType("datetime")
                .HasColumnName("Calendar_Date");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.DepDepartmentId).HasColumnName("DEP_DEPARTMENT_ID");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATE_DATE");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");
            entity.Property(e => e.RegRepId).HasColumnName("Reg_Rep_Id");
            entity.Property(e => e.SreSubRegulationId).HasColumnName("SRE_sub_regulation_Id");
            entity.Property(e => e.WeekDay)
                .HasMaxLength(50)
                .HasColumnName("Week_Day");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_Accounts");

            entity.HasOne(d => d.AfiIssue).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.AfiIssueId)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_AUDIT_FINDINGS");

            entity.HasOne(d => d.BrBranch).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.BrBranchId)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_BRANCHES");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.DepDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_Departments");

            entity.HasOne(d => d.RegRep).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.RegRepId)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_REGULATORY_REPORTING_TRACK");

            entity.HasOne(d => d.SreSubRegulation).WithMany(p => p.GrcCalendarDepartments)
                .HasForeignKey(d => d.SreSubRegulationId)
                .HasConstraintName("FK_GRC_CALENDAR_DEPARTMENT_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcCalendarHoliday>(entity =>
        {
            entity.HasKey(e => e.HolidayId);

            entity.ToTable("GRC_CALENDAR_HOLIDAY");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CALENDAR_HOLIDAY");

            entity.Property(e => e.HolidayId).HasColumnName("Holiday_id");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CREATION_DATE");
            entity.Property(e => e.Description).HasMaxLength(200);
            entity.Property(e => e.HolidayDays).HasColumnName("Holiday_days");
            entity.Property(e => e.HolidayEnd)
                .HasColumnType("datetime")
                .HasColumnName("Holiday_end");
            entity.Property(e => e.HolidayStart)
                .HasColumnType("datetime")
                .HasColumnName("Holiday_start");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("LAST_UPDATE_DATE");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("LAST_UPDATED_BY");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCalendarHolidays)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CALENDAR_HOLIDAY_GRC_Accounts");

            entity.HasOne(d => d.Country).WithMany(p => p.GrcCalendarHolidays)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_GRC_CALENDAR_HOLIDAY_GRC_Countries");
        });

        modelBuilder.Entity<GrcCalendarYear>(entity =>
        {
            entity.ToTable("GRC_CalendarYear");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CalendarYear");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCalendarYears)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CalendarYear_GRC_Accounts");
        });

        modelBuilder.Entity<GrcCollectionQuestionnaire>(entity =>
        {
            entity.ToTable("GRC_CollectionQuestionnaire");

            entity.HasIndex(e => e.QuestionnaireId, "IX_GRC_CollectionQuestionnaire");

            entity.HasIndex(e => e.DataCollectionId, "IX_GRC_CollectionQuestionnaire_1");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.SaqanswerId).HasColumnName("SAQAnswerId");
            entity.Property(e => e.TfSaqanswer).HasColumnName("TF_SAQANSWER");

            entity.HasOne(d => d.AnswerdByNavigation).WithMany(p => p.GrcCollectionQuestionnaires)
                .HasForeignKey(d => d.AnswerdBy)
                .HasConstraintName("FK_GRC_CollectionQuestionnaire_GRC_USERS");

            entity.HasOne(d => d.DataCollection).WithMany(p => p.GrcCollectionQuestionnaires)
                .HasForeignKey(d => d.DataCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CollectionQuestionnaire_GRC_DATA_COLLECTION_NONFINANCIAL");

            entity.HasOne(d => d.Questionnaire).WithMany(p => p.GrcCollectionQuestionnaires)
                .HasForeignKey(d => d.QuestionnaireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CollectionQuestionnaire_GRC_SelftAssessmentQuestionnaire");

            entity.HasOne(d => d.Saqanswer).WithMany(p => p.GrcCollectionQuestionnaires)
                .HasForeignKey(d => d.SaqanswerId)
                .HasConstraintName("FK_GRC_CollectionQuestionnaire_SAQAnswerId");
        });

        modelBuilder.Entity<GrcComplianceAdminDepartment>(entity =>
        {
            entity.ToTable("GRC_ComplianceAdminDepartment");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ComplianceUser).WithMany(p => p.GrcComplianceAdminDepartments)
                .HasForeignKey(d => d.ComplianceUserId)
                .HasConstraintName("FK_GRC_ComplianceAdminDepartment_GRC_USERS");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcComplianceAdminDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_ComplianceAdminDepartment_GRC_Departments");
        });

        modelBuilder.Entity<GrcComply>(entity =>
        {
            entity.ToTable("GRC_Comply");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Comply");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcComplies)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Comply_GRC_Accounts");
        });

        modelBuilder.Entity<GrcControl>(entity =>
        {
            entity.HasKey(e => e.ControlId);

            entity.ToTable("GRC_Controls");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Controls");

            entity.Property(e => e.ControlId).HasColumnName("Control_ID");
            entity.Property(e => e.ControlName)
                .HasMaxLength(200)
                .HasColumnName("Control_Name");
            entity.Property(e => e.ControlsWeight).HasColumnName("Controls_Weight");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Controls_GRC_Accounts");
        });

        modelBuilder.Entity<GrcControlBusinessUnit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_ControlBussinessUnit");

            entity.ToTable("GRC_ControlBusinessUnit");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ControlBusinessUnit");

            entity.Property(e => e.AttachedFile).HasMaxLength(500);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DescriptionIndex).HasMaxLength(255);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RiskId).HasColumnName("RiskID");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControlBusinessUnits)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKGRC_ControlBusinessUnit_GRC_Accounts");

            entity.HasOne(d => d.Control).WithMany(p => p.GrcControlBusinessUnits)
                .HasForeignKey(d => d.ControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlBusinessUnit_GRC_Controls1");

            entity.HasOne(d => d.ControlType).WithMany(p => p.GrcControlBusinessUnits)
                .HasForeignKey(d => d.ControlTypeId)
                .HasConstraintName("FK_GRC_ControlBusinessUnit_GRC_ControlType");

            entity.HasOne(d => d.RelatedPolicy).WithMany(p => p.InverseRelatedPolicy)
                .HasForeignKey(d => d.RelatedPolicyId)
                .HasConstraintName("FK_GRC_ControlBusinessUnit_GRC_ControlBusinessUnit1");
        });

        modelBuilder.Entity<GrcControlClassSubjective>(entity =>
        {
            entity.ToTable("GRC_ControlClassSubjective");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ControlClassSubjective");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControlClassSubjectives)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlClassSubjective_GRC_Accounts");

            entity.HasOne(d => d.Control).WithMany(p => p.GrcControlClassSubjectives)
                .HasForeignKey(d => d.ControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlClassSubjective_GRC_Controls");

            entity.HasOne(d => d.ControlProbability).WithMany(p => p.GrcControlClassSubjectives)
                .HasForeignKey(d => d.ControlProbabilityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlClassSubjective_GRC_CONTROL_PROPABILITY_CLASS");
        });

        modelBuilder.Entity<GrcControlPropabilityClass>(entity =>
        {
            entity.HasKey(e => e.CpProbabilityId);

            entity.ToTable("GRC_CONTROL_PROPABILITY_CLASS");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CONTROL_PROPABILITY_CLASS");

            entity.Property(e => e.CpProbabilityId).HasColumnName("CP_probability_id");
            entity.Property(e => e.ClassColor).HasMaxLength(200);
            entity.Property(e => e.CpDescription)
                .HasMaxLength(100)
                .HasColumnName("CP_Description");
            entity.Property(e => e.CpName)
                .HasMaxLength(10)
                .HasColumnName("CP_name");
            entity.Property(e => e.CpUpperValue).HasColumnName("CP_upper_value");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControlPropabilityClasses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CONTROL_PROPABILITY_CLASS_GRC_Accounts");
        });

        modelBuilder.Entity<GrcControlType>(entity =>
        {
            entity.ToTable("GRC_ControlType");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ControlType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControlTypes)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_GRC_ControlType_GRC_Accounts");
        });

        modelBuilder.Entity<GrcControlUserAccess>(entity =>
        {
            entity.ToTable("GRC_ControlUserAccess");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ControlUserAccess");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcControlUserAccesses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlUserAccess_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcControlUserAccesses)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlUserAccess_GRC_Departments");

            entity.HasOne(d => d.User).WithMany(p => p.GrcControlUserAccesses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ControlUserAccess_GRC_USERS");
        });

        modelBuilder.Entity<GrcCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK_Countries");

            entity.ToTable("GRC_Countries");

            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.BankAddressLine1)
                .HasMaxLength(200)
                .HasColumnName("Bank_Address_Line_1");
            entity.Property(e => e.BankAddressLine2)
                .HasMaxLength(200)
                .HasColumnName("Bank_Address_Line_2");
            entity.Property(e => e.BankName)
                .HasMaxLength(200)
                .HasColumnName("Bank_Name");
            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CountryName)
                .HasMaxLength(200)
                .HasColumnName("Country_Name");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RegionId).HasColumnName("Region_id");

            entity.HasOne(d => d.Region).WithMany(p => p.GrcCountries)
                .HasForeignKey(d => d.RegionId)
                .HasConstraintName("FK_Countries_Region");
        });

        modelBuilder.Entity<GrcCrimeAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_SituationAttachments");

            entity.ToTable("GRC_CrimeAttachments");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CrimeId).HasColumnName("CrimeID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcCrimeBusinessunit>(entity =>
        {
            entity.ToTable("GRC_Crime_Businessunit");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BranchId).HasColumnName("BranchID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcCrimeBusinessunits)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_GRC_Crime_Businessunit_GRC_BRANCHES");

            entity.HasOne(d => d.Crime).WithMany(p => p.GrcCrimeBusinessunits)
                .HasForeignKey(d => d.CrimeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Crime_Businessunit_GRC_CrimeSituation");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcCrimeBusinessunits)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_Crime_Businessunit_GRC_Departments");
        });

        modelBuilder.Entity<GrcCrimeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_SituationsDetials");

            entity.ToTable("GRC_CrimeDetails");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CrimeId).HasColumnName("CrimeID");
            entity.Property(e => e.ReportingDetialsId).HasColumnName("ReportingDetialsID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcCrimeNature>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SituationNature");

            entity.ToTable("GRC_CrimeNature");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CrimeNature");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Createddate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCrimeNatures)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CrimeNature_GRC_Accounts");
        });

        modelBuilder.Entity<GrcCrimeReporting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_ReportingDetials");

            entity.ToTable("GRC_CrimeReporting");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CrimeReporting");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCrimeReportings)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CrimeReporting_GRC_Accounts");
        });

        modelBuilder.Entity<GrcCrimeSituation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Situation_Situations");

            entity.ToTable("GRC_CrimeSituation");

            entity.HasIndex(e => e.AccountId, "IX_GRC_CrimeSituationGRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CrimeNatureId).HasColumnName("CrimeNatureID");
            entity.Property(e => e.DatetheCrimeOccurred).HasColumnType("datetime");
            entity.Property(e => e.DiscoveryDate).HasColumnType("datetime");
            entity.Property(e => e.EmployeeInChargeId).HasColumnName("EmployeeInChargeID");
            entity.Property(e => e.Reference).HasMaxLength(200);
            entity.Property(e => e.Reported).HasDefaultValue(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCrimeSituations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CrimeSituation_GRC_Accounts");

            entity.HasOne(d => d.CrimeNature).WithMany(p => p.GrcCrimeSituations)
                .HasForeignKey(d => d.CrimeNatureId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_CrimeSituation_GRC_CrimeNature");

            entity.HasOne(d => d.CrimeStatus).WithMany(p => p.GrcCrimeSituations)
                .HasForeignKey(d => d.CrimeStatusId)
                .HasConstraintName("FK_GRC_CrimeSituation_GRC_CrimeStatus");

            entity.HasOne(d => d.EmployeeInCharge).WithMany(p => p.GrcCrimeSituationEmployeeInCharges)
                .HasForeignKey(d => d.EmployeeInChargeId)
                .HasConstraintName("FK_GRC_CrimeSituations_GRC_USERS");

            entity.HasOne(d => d.InitiatedByNavigation).WithMany(p => p.GrcCrimeSituationInitiatedByNavigations)
                .HasForeignKey(d => d.InitiatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Situations_GRC_Situations");
        });

        modelBuilder.Entity<GrcCrimeStatus>(entity =>
        {
            entity.ToTable("GRC_CrimeStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcCriterion>(entity =>
        {
            entity.ToTable("GRC_criteria");

            entity.HasIndex(e => e.AccountId, "IX_GRC_criteria");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.CriteriaName).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcCriteria)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_criteria_GRC_Accounts");
        });

        modelBuilder.Entity<GrcDataCollectionAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_Data__3214EC07108C95B4");

            entity.ToTable("GRC_DataCollectionAnswers");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.AnsweredByNavigation).WithMany(p => p.GrcDataCollectionAnswers)
                .HasForeignKey(d => d.AnsweredBy)
                .HasConstraintName("FK__GRC_DataC__Answe__2023F191");

            entity.HasOne(d => d.Collection).WithMany(p => p.GrcDataCollectionAnswers)
                .HasForeignKey(d => d.CollectionId)
                .HasConstraintName("FK__GRC_DataC__Colle__211815CA");

            entity.HasOne(d => d.CompMakerAnswerNavigation).WithMany(p => p.GrcDataCollectionAnswerCompMakerAnswerNavigations)
                .HasForeignKey(d => d.CompMakerAnswer)
                .HasConstraintName("FK__GRC_DataC__CompM__220C3A03");

            entity.HasOne(d => d.DepCheckerAnswerNavigation).WithMany(p => p.GrcDataCollectionAnswerDepCheckerAnswerNavigations)
                .HasForeignKey(d => d.DepCheckerAnswer)
                .HasConstraintName("FK__GRC_DataC__DepCh__23005E3C");

            entity.HasOne(d => d.DepMakerAnswerNavigation).WithMany(p => p.GrcDataCollectionAnswers)
                .HasForeignKey(d => d.DepMakerAnswer)
                .HasConstraintName("FK__GRC_DataC__DepMa__24E8A6AE");
        });

        modelBuilder.Entity<GrcDataCollectionNonfinancial>(entity =>
        {
            entity.HasKey(e => e.CollectionId);

            entity.ToTable("GRC_DATA_COLLECTION_NONFINANCIAL");

            entity.HasIndex(e => e.AccountId, "IX_GRC_DATA_COLLECTION_NONFINANCIAL");

            entity.Property(e => e.CollectionId).HasColumnName("COLLECTION_ID");
            entity.Property(e => e.ComApprovedBy).HasColumnName("Com_ApprovedBy");
            entity.Property(e => e.ComplaintsEmail).HasColumnName("Complaints_Email");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepDepartmentId).HasColumnName("DEP_DEPARTMENT_ID");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due_Date");
            entity.Property(e => e.EntryDate)
                .HasColumnType("datetime")
                .HasColumnName("Entry_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RegRegulationId).HasColumnName("REG_REGULATION_ID");
            entity.Property(e => e.RegRepId).HasColumnName("Reg_Rep_Id");
            entity.Property(e => e.ReminderEmail1).HasColumnName("Reminder_Email_1");
            entity.Property(e => e.ReminderEmail2).HasColumnName("Reminder_Email_2");
            entity.Property(e => e.SreSubRegulationId).HasColumnName("SRE_SUB_regulation_id");
            entity.Property(e => e.UseApprovedBy).HasColumnName("Use_ApprovedBy");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Accounts");

            entity.HasOne(d => d.ComApprovedByNavigation).WithMany(p => p.GrcDataCollectionNonfinancialComApprovedByNavigations)
                .HasForeignKey(d => d.ComApprovedBy)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_USERS1");

            entity.HasOne(d => d.ComplyStatus).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.ComplyStatusId)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Comply");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.DepDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Departments");

            entity.HasOne(d => d.RegRegulation).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.RegRegulationId)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Regulations");

            entity.HasOne(d => d.RegRep).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.RegRepId)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_REGULATORY_REPORTING_TRACK");

            entity.HasOne(d => d.SreSubRegulation).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.SreSubRegulationId)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Sub_Regulations");

            entity.HasOne(d => d.StagingCompApprovedByNavigation).WithMany(p => p.GrcDataCollectionNonfinancialStagingCompApprovedByNavigations)
                .HasForeignKey(d => d.StagingCompApprovedBy)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_USERS3");

            entity.HasOne(d => d.TestHeader).WithMany(p => p.GrcDataCollectionNonfinancials)
                .HasForeignKey(d => d.TestHeaderId)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_Test_HeaderId");

            entity.HasOne(d => d.UseApprovedByNavigation).WithMany(p => p.GrcDataCollectionNonfinancialUseApprovedByNavigations)
                .HasForeignKey(d => d.UseApprovedBy)
                .HasConstraintName("FK_GRC_DATA_COLLECTION_NONFINANCIAL_GRC_USERS");
        });

        modelBuilder.Entity<GrcDataNonFinancialAttachFile>(entity =>
        {
            entity.ToTable("GRC_DataNonFinancialAttachFile");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.NonFinancialCollection).WithMany(p => p.GrcDataNonFinancialAttachFiles)
                .HasForeignKey(d => d.NonFinancialCollectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DataNonFinancialAttachFile_GRC_DATA_COLLECTION_NONFINANCIAL");
        });

        modelBuilder.Entity<GrcDepartment>(entity =>
        {
            entity.HasKey(e => e.DepartmentId);

            entity.ToTable("GRC_Departments");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Departments");

            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.CountryId).HasColumnName("Country_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepartmentCode).HasMaxLength(200);
            entity.Property(e => e.DepartmentEmail1)
                .HasMaxLength(200)
                .HasColumnName("Department_Email1");
            entity.Property(e => e.DepartmentEmail2)
                .HasMaxLength(200)
                .HasColumnName("Department_Email2");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(200)
                .HasColumnName("Department_Name");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Departments_GRC_Accounts");

            entity.HasOne(d => d.Country).WithMany(p => p.GrcDepartments)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_GRC_Departments_Countries");

            entity.HasOne(d => d.Sector).WithMany(p => p.GrcDepartments)
                .HasForeignKey(d => d.SectorId)
                .HasConstraintName("FK__GRC_Depar__Secto__15FA39EE");
        });

        modelBuilder.Entity<GrcDepartmentBreachRegulationMatrix>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_DepartmentRegulationMatrix");

            entity.ToTable("GRC_DepartmentBreachRegulationMatrix");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcDepartmentBreachsSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_Depa__3214EC0763411387");

            entity.ToTable("GRC_DepartmentBreachsSources");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcDepartmentBreachsSources)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DepartmentId");
        });

        modelBuilder.Entity<GrcDepartmentCriteriaRank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_DepartmentRank");

            entity.ToTable("GRC_DepartmentCriteriaRank");

            entity.HasIndex(e => e.AccountId, "IX_GRC_DepartmentCriteriaRank");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RunDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcDepartmentCriteriaRanks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentCriteriaRank_GRC_Accounts");

            entity.HasOne(d => d.Criteria).WithMany(p => p.GrcDepartmentCriteriaRanks)
                .HasForeignKey(d => d.CriteriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRank_GRC_criteria");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcDepartmentCriteriaRanks)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRank_GRC_Departments");
        });

        modelBuilder.Entity<GrcDepartmentRank>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_DepartmentRank_1");

            entity.ToTable("GRC_DepartmentRank");

            entity.HasIndex(e => e.AccountId, "IX_GRC_DepartmentRank");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.RunDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcDepartmentRanks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRank_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcDepartmentRanks)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRank_GRC_Departments1");
        });

        modelBuilder.Entity<GrcDepartmentRegulationsMatrix>(entity =>
        {
            entity.ToTable("GRC_DepartmentRegulationsMatrix");

            entity.HasIndex(e => e.AccountId, "IX_GRC_DepartmentRegulationsMatrix");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcDepartmentRegulationsMatrices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRegulationsMatrix_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcDepartmentRegulationsMatrices)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRegulationsMatrix_GRC_Departments");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcDepartmentRegulationsMatrices)
                .HasForeignKey(d => d.RegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DepartmentRegulationsMatrix_GRC_Regulations");
        });

        modelBuilder.Entity<GrcDepartmentSubRegulation>(entity =>
        {
            entity.HasKey(e => e.DepartmentSubRegulationId);

            entity.ToTable("GRC_Department_Sub_regulation");

            entity.Property(e => e.DepartmentSubRegulationId).HasColumnName("Department_sub_regulation_ID");
            entity.Property(e => e.BreachFlag).HasColumnName("Breach_Flag");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_ID");
            entity.Property(e => e.EmailSentFlag).HasDefaultValue(false);
            entity.Property(e => e.LastUpdateBy).HasColumnName("Last_Update_by");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.ResponsibilityLevel).HasColumnName("Responsibility_Level");
            entity.Property(e => e.SubRegulationId).HasColumnName("Sub_Regulation_ID");
            entity.Property(e => e.ThresholdFlag).HasColumnName("Threshold_Flag");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcDepartmentSubRegulations)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_Department_Sub_regulation_GRC_Departments");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcDepartmentSubRegulations)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_GRC_Department_Sub_regulation_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId);

            entity.ToTable("GRC_Emails", tb => tb.HasTrigger("AfterINSERTTrigger"));

            entity.HasIndex(e => e.AccountId, "IX_GRC_Emails_GRC_Accounts");

            entity.Property(e => e.EmailId).HasColumnName("Email_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailAddressCc).HasColumnName("Email_Address_CC");
            entity.Property(e => e.EmailAddressFrom)
                .HasMaxLength(50)
                .HasColumnName("Email_Address_From");
            entity.Property(e => e.EmailAddressTo).HasColumnName("Email_Address_To");
            entity.Property(e => e.EmailBody).HasColumnName("Email_Body");
            entity.Property(e => e.EmailSent).HasColumnName("Email_Sent");
            entity.Property(e => e.EmailSubject)
                .HasMaxLength(200)
                .HasColumnName("Email_Subject");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated_Date");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEmails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Emails_GRC_Accounts");
        });

        modelBuilder.Entity<GrcEmailControl>(entity =>
        {
            entity.ToTable("GRC_EmailControl");

            entity.HasIndex(e => e.AccountId, "IX_GRC_EmailControl_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Creationdate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEmailControls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_EmailControl_GRC_Accounts");
        });

        modelBuilder.Entity<GrcEntity>(entity =>
        {
            entity.ToTable("GRC_Entity");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Entity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("name");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEntities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Entity_GRC_Accounts");
        });

        modelBuilder.Entity<GrcEntityAssessmentDetail>(entity =>
        {
            entity.ToTable("GRC_EntityAssessmentDetails");

            entity.HasIndex(e => e.AccountId, "IX_GRC_EntityAssessmentDetails");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEntityAssessmentDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_EntityAssessmentDetails_GRC_Accounts");

            entity.HasOne(d => d.AssessorUser).WithMany(p => p.GrcEntityAssessmentDetails)
                .HasForeignKey(d => d.AssessorUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_EntityAssessmentDetails_GRC_USERS");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcEntityAssessmentDetails)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_GRC_EntityAssessmentDetails_GRC_BRANCHES");

            entity.HasOne(d => d.RiskRating).WithMany(p => p.GrcEntityAssessmentDetails)
                .HasForeignKey(d => d.RiskRatingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_EntityAssessmentDetails_GRC_AuditRiskRating");
        });

        modelBuilder.Entity<GrcEscalationAction>(entity =>
        {
            entity.HasKey(e => e.ActionId);

            entity.ToTable("GRC_ESCALATION_ACTION");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ESCALATION_ACTION");

            entity.Property(e => e.ActionId).HasColumnName("ACTION_ID");
            entity.Property(e => e.ActionTaken).HasColumnName("Action_Taken");
            entity.Property(e => e.AttachedFile).HasColumnName("Attached_File");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.EmoEscalationId).HasColumnName("Emo_escalation_id");
            entity.Property(e => e.EstStatusId).HasColumnName("Est_StatusId");
            entity.Property(e => e.ExpectedResolvedDate)
                .HasColumnType("datetime")
                .HasColumnName("Expected_Resolved_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_updated_by");
            entity.Property(e => e.LineNumber).HasColumnName("Line_number");
            entity.Property(e => e.ResolvedDate)
                .HasColumnType("datetime")
                .HasColumnName("resolved_date");
            entity.Property(e => e.UseActionUserId).HasColumnName("Use_action_user_id");
            entity.Property(e => e.UseApprovedBy).HasColumnName("Use_ApprovedBy");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEscalationActions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ESCALATION_ACTION_GRC_Accounts");

            entity.HasOne(d => d.EmoEscalation).WithMany(p => p.GrcEscalationActions)
                .HasForeignKey(d => d.EmoEscalationId)
                .HasConstraintName("FK_GRC_ESCALATION_ACTION_GRC_ESCALATION_MONITOR");

            entity.HasOne(d => d.EstStatus).WithMany(p => p.GrcEscalationActions)
                .HasForeignKey(d => d.EstStatusId)
                .HasConstraintName("FK_GRC_ESCALATION_ACTION_GRC_ESCALATION_STATUS");

            entity.HasOne(d => d.UseActionUser).WithMany(p => p.GrcEscalationActionUseActionUsers)
                .HasForeignKey(d => d.UseActionUserId)
                .HasConstraintName("FK_GRC_ESCALATION_ACTION_GRC_USERS");

            entity.HasOne(d => d.UseApprovedByNavigation).WithMany(p => p.GrcEscalationActionUseApprovedByNavigations)
                .HasForeignKey(d => d.UseApprovedBy)
                .HasConstraintName("FK_GRC_ESCALATION_ACTION_GRC_USERS1");
        });

        modelBuilder.Entity<GrcEscalationMonitor>(entity =>
        {
            entity.HasKey(e => e.EscalationId).HasName("PK_GRC_ESCALATION_MONITOR1");

            entity.ToTable("GRC_ESCALATION_MONITOR");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ESCALATION_MONITOR");

            entity.Property(e => e.EscalationId).HasColumnName("Escalation_ID");
            entity.Property(e => e.BreBreachId).HasColumnName("Bre_breach_id");
            entity.Property(e => e.CeoEscalationFlag).HasColumnName("CEO_Escalation_Flag");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.EscalationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("escalation_Date");
            entity.Property(e => e.EscalationRef).HasColumnName("Escalation_ref");
            entity.Property(e => e.EstStatusId).HasColumnName("Est_StatusId");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_updated_by");
            entity.Property(e => e.PriPriorityId).HasColumnName("Pri_PriorityId");
            entity.Property(e => e.ResolvedDate)
                .HasColumnType("datetime")
                .HasColumnName("resolved_date");
            entity.Property(e => e.UseCompletedBy).HasColumnName("Use_completed_by");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEscalationMonitors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ESCALATION_MONITOR_GRC_Accounts");

            entity.HasOne(d => d.BreBreach).WithMany(p => p.GrcEscalationMonitors)
                .HasForeignKey(d => d.BreBreachId)
                .HasConstraintName("FK_GRC_ESCALATION_MONITOR_GRC_Breaches");

            entity.HasOne(d => d.EstStatus).WithMany(p => p.GrcEscalationMonitors)
                .HasForeignKey(d => d.EstStatusId)
                .HasConstraintName("FK_GRC_ESCALATION_MONITOR_GRC_ESCALATION_STATUS");

            entity.HasOne(d => d.PriPriority).WithMany(p => p.GrcEscalationMonitors)
                .HasForeignKey(d => d.PriPriorityId)
                .HasConstraintName("FK_GRC_ESCALATION_MONITOR_ErmPriority");

            entity.HasOne(d => d.UseCompletedByNavigation).WithMany(p => p.GrcEscalationMonitors)
                .HasForeignKey(d => d.UseCompletedBy)
                .HasConstraintName("FK_GRC_ESCALATION_MONITOR_GRC_USERS");
        });

        modelBuilder.Entity<GrcEscalationStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("GRC_ESCALATION_STATUS");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ESCALATION_STATUS_GRC_Accounts");

            entity.Property(e => e.StatusId).HasColumnName("Status_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_updated_by");
            entity.Property(e => e.StatusCode)
                .HasMaxLength(50)
                .HasColumnName("Status_Code");
            entity.Property(e => e.StatusLevel).HasColumnName("Status_Level");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcEscalationStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ESCALATION_STATUS_GRC_Accounts");
        });

        modelBuilder.Entity<GrcExtention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRCExtentions");

            entity.ToTable("GRC_Extentions");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcExternalUserAccess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_Exte__3214EC07DD639405");

            entity.ToTable("GRC_ExternalUserAccess");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcExternalUserAccesses)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_ExternalUserAccess_GRC_Departments");
        });

        modelBuilder.Entity<GrcFinancialCollection>(entity =>
        {
            entity.ToTable("GRC_FINANCIAL_COLLECTION");

            entity.HasIndex(e => e.AccountId, "IX_GRC_FINANCIAL_COLLECTION");

            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FinancialDate)
                .HasColumnType("datetime")
                .HasColumnName("Financial_date");
            entity.Property(e => e.FreValueId).HasColumnName("FRE_value_id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Value).HasColumnName("VALUE");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialCollections)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FINANCIAL_COLLECTION_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcFinancialCollections)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FINANCIAL_COLLECTION_GRC_Countries");

            entity.HasOne(d => d.FreValue).WithMany(p => p.GrcFinancialCollections)
                .HasForeignKey(d => d.FreValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FINANCIAL_COLLECTION_GRC_FINANCIAL_REF");
        });

        modelBuilder.Entity<GrcFinancialCollectionLevel2>(entity =>
        {
            entity.HasKey(e => new { e.FinancialDate, e.FrlValueId, e.CouCountryId });

            entity.ToTable("GRC_Financial_Collection_Level2");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Financial_Collection_Level2");

            entity.Property(e => e.FinancialDate)
                .HasColumnType("datetime")
                .HasColumnName("Financial_Date");
            entity.Property(e => e.FrlValueId).HasColumnName("FRL_Value_ID");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialCollectionLevel2s)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_Collection_Level2_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcFinancialCollectionLevel2s)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_Collection_Level2_GRC_Countries");

            entity.HasOne(d => d.FrlValue).WithMany(p => p.GrcFinancialCollectionLevel2s)
                .HasForeignKey(d => d.FrlValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_Collection_Level2_GRC_Financial_REF_Level2");
        });

        modelBuilder.Entity<GrcFinancialRef>(entity =>
        {
            entity.HasKey(e => e.ValueId);

            entity.ToTable("GRC_FINANCIAL_REF");

            entity.HasIndex(e => e.AccountId, "IX_GRC_FINANCIAL_REF");

            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Level2Flag).HasColumnName("Level2_Flag");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialRefs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FINANCIAL_REF_GRC_Accounts");
        });

        modelBuilder.Entity<GrcFinancialRefLevel2>(entity =>
        {
            entity.HasKey(e => e.ValueId);

            entity.ToTable("GRC_Financial_REF_Level2");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Financial_REF_Level2_GRC_Accountsref");

            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Name).HasMaxLength(200);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialRefLevel2s)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_Level2_GRC_Accounts");
        });

        modelBuilder.Entity<GrcFinancialRefLevelLink>(entity =>
        {
            entity.HasKey(e => e.ValueId);

            entity.ToTable("GRC_Financial_REF_Level_Link");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Financial_REF_Level_Link_GRC_Accounts12");

            entity.Property(e => e.ValueId).HasColumnName("value_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FreValueId).HasColumnName("FRE_value_id");
            entity.Property(e => e.FrlValueId).HasColumnName("FRL_value_id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialRefLevelLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_Level_Link_GRC_Accounts");

            entity.HasOne(d => d.FreValue).WithMany(p => p.GrcFinancialRefLevelLinks)
                .HasForeignKey(d => d.FreValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_Level_Link_GRC_Financial_REF_Level_Link1");

            entity.HasOne(d => d.FrlValue).WithMany(p => p.GrcFinancialRefLevelLinks)
                .HasForeignKey(d => d.FrlValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_Level_Link_GRC_Financial_REF_Level_Link");
        });

        modelBuilder.Entity<GrcFinancialRefReg>(entity =>
        {
            entity.HasKey(e => e.FinancialReferenceReg);

            entity.ToTable("GRC_Financial_REF_REG");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Financial_REF_REG");

            entity.Property(e => e.FinancialReferenceReg).HasColumnName("Financial_reference_reg");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FreValueId).HasColumnName("FRE_VALUE_ID");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_updated_by");
            entity.Property(e => e.RegRegulationId).HasColumnName("REG_regulation_id");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcFinancialRefRegs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_REG_GRC_Accounts");

            entity.HasOne(d => d.FreValue).WithMany(p => p.GrcFinancialRefRegs)
                .HasForeignKey(d => d.FreValueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_REG_GRC_FINANCIAL_REF");

            entity.HasOne(d => d.RegRegulation).WithMany(p => p.GrcFinancialRefRegs)
                .HasForeignKey(d => d.RegRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Financial_REF_REG_GRC_Regulations");
        });

        modelBuilder.Entity<GrcFinancialRegulationsUser>(entity =>
        {
            entity.ToTable("GRC_FinancialRegulationsUsers");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcFinancialRegulationsUsers)
                .HasForeignKey(d => d.RegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FinancialRegulationsUsers_GRC_Regulations");

            entity.HasOne(d => d.User).WithMany(p => p.GrcFinancialRegulationsUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FinancialRegulationsUsers_GRC_USERS");
        });

        modelBuilder.Entity<GrcFinancialXmlattachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_FinantialXMLAttachment");

            entity.ToTable("GRC_FinancialXMLAttachment");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.FinancialDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasColumnName("updatedBy");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcFunctionDetail>(entity =>
        {
            entity.ToTable("GRC_FunctionDetails");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Function).WithMany(p => p.GrcFunctionDetails)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_FunctionDetails_GRC_BusinessUnitFunction");
        });

        modelBuilder.Entity<GrcGoal>(entity =>
        {
            entity.ToTable("GRC_Goals");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.GrcGoals)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Goals_GRC_GoalsCategory");
        });

        modelBuilder.Entity<GrcGoalDetailsBu>(entity =>
        {
            entity.ToTable("GRC_GoalDetailsBU");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcGoalDetailsBus)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_GRC_GoalDetailsBU_Branch");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcGoalDetailsBus)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_GoalDetailsBU_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.GrcGoalDetailsBus)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_GRC_GoalDetailsBU_Division");

            entity.HasOne(d => d.GoalDetails).WithMany(p => p.GrcGoalDetailsBus)
                .HasForeignKey(d => d.GoalDetailsId)
                .HasConstraintName("FK_GRC_GoalDetailsBU_GRC_GoalsDetails");
        });

        modelBuilder.Entity<GrcGoalsBu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_GoalsBL");

            entity.ToTable("GRC_GoalsBU");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcGoalsBus)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_GRC_GoalsBL_GRC_Breaches");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcGoalsBus)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_GoalsBL_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.GrcGoalsBus)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_GRC_GoalsBL_Division");

            entity.HasOne(d => d.Goal).WithMany(p => p.GrcGoalsBus)
                .HasForeignKey(d => d.GoalId)
                .HasConstraintName("FK_GRC_GoalsBL_GRC_Goals");
        });

        modelBuilder.Entity<GrcGoalsCategory>(entity =>
        {
            entity.ToTable("GRC_GoalsCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcGoalsDetail>(entity =>
        {
            entity.ToTable("GRC_GoalsDetails");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Goal).WithMany(p => p.GrcGoalsDetails)
                .HasForeignKey(d => d.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_GoalsDetails_GRC_Goals");
        });

        modelBuilder.Entity<GrcGovernorate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grc_Gove__3213E83FCEA14550");

            entity.ToTable("Grc_Governorate");

            entity.HasIndex(e => e.Description, "UQ_Description").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasDefaultValueSql("(NEXT VALUE FOR [GovernorateCodeSequence])");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcIndustry>(entity =>
        {
            entity.ToTable("GRC_Industry");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Industry).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcIntegrationApiCode>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_IntegrationSmsCodes");

            entity.ToTable("GRC_IntegrationApiCodes");

            entity.HasIndex(e => e.AccountId, "IX_GRC_IntegrationApiCodes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIntegrationApiCodes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationApiCodes_GRC_Accounts");

            entity.HasOne(d => d.IntegrationType).WithMany(p => p.GrcIntegrationApiCodes)
                .HasForeignKey(d => d.IntegrationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationApiCodes_GRC_IntegrationTypes");

            entity.HasOne(d => d.Status).WithMany(p => p.GrcIntegrationApiCodes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationApiCodes_GRC_IntegrationStatus");
        });

        modelBuilder.Entity<GrcIntegrationEntity>(entity =>
        {
            entity.ToTable("GRC_IntegrationEntities");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.IntegrationEntityServiceId)
                .HasMaxLength(50)
                .HasColumnName("IntegrationEntityServiceID");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Smsmessage).HasColumnName("SMSMessage");

            entity.HasOne(d => d.Entity).WithMany(p => p.GrcIntegrationEntities)
                .HasForeignKey(d => d.EntityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationEntities_GRC_Entity");

            entity.HasOne(d => d.IntegrationService).WithMany(p => p.GrcIntegrationEntities)
                .HasForeignKey(d => d.IntegrationServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationEntities_GRC_IntegrationService");

            entity.HasOne(d => d.IntegrationType).WithMany(p => p.GrcIntegrationEntities)
                .HasForeignKey(d => d.IntegrationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationEntities_GRC_IntegrationTypes");
        });

        modelBuilder.Entity<GrcIntegrationMonitor>(entity =>
        {
            entity.ToTable("GRC_IntegrationMonitor");

            entity.HasIndex(e => e.AccountId, "IX_GRC_IntegrationMonitor");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIntegrationMonitors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationMonitor_GRC_Accounts");

            entity.HasOne(d => d.CompCustomerCall).WithMany(p => p.GrcIntegrationMonitors)
                .HasForeignKey(d => d.CompCustomerCallId)
                .HasConstraintName("FK_GRC_IntegrationLog_CompCustomerCall");

            entity.HasOne(d => d.IntegratioApiCodes).WithMany(p => p.GrcIntegrationMonitors)
                .HasForeignKey(d => d.IntegratioApiCodesId)
                .HasConstraintName("FK_GRC_IntegrationMonitor_GRC_IntegrationApiCodes");

            entity.HasOne(d => d.IntegrationEntities).WithMany(p => p.GrcIntegrationMonitors)
                .HasForeignKey(d => d.IntegrationEntitiesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationMonitor_GRC_IntegrationEntities");

            entity.HasOne(d => d.IntegrationStatus).WithMany(p => p.GrcIntegrationMonitors)
                .HasForeignKey(d => d.IntegrationStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationMonitor_GRC_IntegrationStatus");
        });

        modelBuilder.Entity<GrcIntegrationService>(entity =>
        {
            entity.ToTable("GRC_IntegrationService");

            entity.HasIndex(e => e.AccountId, "IX_GRC_IntegrationService");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ServiceCode).HasMaxLength(10);
            entity.Property(e => e.Url).HasColumnName("URL");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIntegrationServices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationService_GRC_Accounts");
        });

        modelBuilder.Entity<GrcIntegrationStatus>(entity =>
        {
            entity.ToTable("GRC_IntegrationStatus");

            entity.HasIndex(e => e.AccountId, "IX_GRC_IntegrationStatus");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIntegrationStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationStatus_GRC_Accounts");
        });

        modelBuilder.Entity<GrcIntegrationType>(entity =>
        {
            entity.ToTable("GRC_IntegrationTypes");

            entity.HasIndex(e => e.AccountId, "IX_GRC_IntegrationTypes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TypeCode).HasMaxLength(10);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIntegrationTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_IntegrationTypes_GRC_Accounts");
        });

        modelBuilder.Entity<GrcIssuer>(entity =>
        {
            entity.HasKey(e => e.IssuerId);

            entity.ToTable("GRC_ISSUER");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ISSUER");

            entity.Property(e => e.IssuerId).HasColumnName("issuer_id");
            entity.Property(e => e.CouCountryId).HasColumnName("COU_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_date");
            entity.Property(e => e.IssuerName).HasColumnName("issuer_name");
            entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("last_update_date");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcIssuers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ISSUER_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcIssuers)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ISSUER_GRC_Countries");
        });

        modelBuilder.Entity<GrcJobTitle>(entity =>
        {
            entity.ToTable("GRC_JobTitle");

            entity.HasIndex(e => e.AccountId, "IX_GRC_JobTitle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcJobTitles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_JobTitle_GRC_Accounts");
        });

        modelBuilder.Entity<GrcLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_Languages_1");

            entity.ToTable("GRC_Languages");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Languages");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Culture).HasMaxLength(50);
            entity.Property(e => e.LanguageCode).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Orientation).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcLanguages)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Languages_GRC_Accounts");
        });

        modelBuilder.Entity<GrcMapAuditTable>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_GrcMapAuditTables_GRC_Accounts");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BusinessTableName).HasMaxLength(255);
            entity.Property(e => e.TableName).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcMapAuditTables)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcMapAuditTables_GRC_Accounts");
        });

        modelBuilder.Entity<GrcMatrix>(entity =>
        {
            entity.HasKey(e => new { e.CouCountryId, e.DepDepartmentId, e.RclRisClassificationId }).HasName("PK_GRC_MATRIX_1");

            entity.ToTable("GRC_MATRIX");

            entity.HasIndex(e => e.AccountId, "IX_GRC_MATRIX");

            entity.Property(e => e.CouCountryId).HasColumnName("COU_COUNTRY_ID");
            entity.Property(e => e.DepDepartmentId).HasColumnName("DEP_DEPARTMENT_ID");
            entity.Property(e => e.RclRisClassificationId)
                .HasMaxLength(50)
                .HasColumnName("RCL_RIS_CLASSIFICATION_ID");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.RiskLevelCount).HasColumnName("RISK_LEVEL_COUNT");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcMatrices)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MATRIX_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcMatrices)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MATRIX_Countries");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcMatrices)
                .HasForeignKey(d => d.DepDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MATRIX_GRC_Departments");
        });

        modelBuilder.Entity<GrcMenu>(entity =>
        {
            entity.ToTable("GRC_Menu");
        });

        modelBuilder.Entity<GrcMenuDetailsRole>(entity =>
        {
            entity.ToTable("GRC_MenuDetailsRole");

            entity.HasOne(d => d.MenuDetail).WithMany(p => p.GrcMenuDetailsRoles)
                .HasForeignKey(d => d.MenuDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MenuDetailsRole_GRC_MenuItemDetails");
        });

        modelBuilder.Entity<GrcMenuItem>(entity =>
        {
            entity.ToTable("GRC_MenuItem");
        });

        modelBuilder.Entity<GrcMenuItemDetail>(entity =>
        {
            entity.ToTable("GRC_MenuItemDetails");
        });

        modelBuilder.Entity<GrcMenuItemRole>(entity =>
        {
            entity.ToTable("GRC_MenuItemRole");

            entity.HasOne(d => d.MenuItem).WithMany(p => p.GrcMenuItemRoles)
                .HasForeignKey(d => d.MenuItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MenuItemRole_GRC_MenuItem");
        });

        modelBuilder.Entity<GrcMenuRole>(entity =>
        {
            entity.ToTable("GRC_MenuRole");

            entity.HasOne(d => d.Menu).WithMany(p => p.GrcMenuRoles)
                .HasForeignKey(d => d.MenuId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_MenuRole_GRC_Menu");
        });

        modelBuilder.Entity<GrcPage>(entity =>
        {
            entity.HasKey(e => e.PageId);

            entity.ToTable("GRC_Pages");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Pages");

            entity.Property(e => e.PageId).HasColumnName("page_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated_Date");
            entity.Property(e => e.PageUrl)
                .HasMaxLength(2000)
                .HasColumnName("Page_URL");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcPages)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Pages_GRC_Accounts");
        });

        modelBuilder.Entity<GrcPasswordHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_Pass__3214EC0795F3D8E2");

            entity.ToTable("GRC_PasswordHistory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcPriority>(entity =>
        {
            entity.HasKey(e => e.PriorityId).HasName("PK_ErmPriority");

            entity.ToTable("GRC_Priority");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Priority");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcPriorities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Priority_GRC_Accounts");
        });

        modelBuilder.Entity<GrcProjectDepartment>(entity =>
        {
            entity.ToTable("GRC_ProjectDepartments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcProjectDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ProjectDepartments_GRC_Departments");

            entity.HasOne(d => d.StrategicProgramProject).WithMany(p => p.GrcProjectDepartments)
                .HasForeignKey(d => d.StrategicProgramProjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ProjectDepartments_StrategicProgramProjects");
        });

        modelBuilder.Entity<GrcRegulation>(entity =>
        {
            entity.HasKey(e => e.RegulationId);

            entity.ToTable("GRC_Regulations");

            entity.HasIndex(e => e.Refrence, "IX_GRC_Regulations_1").IsUnique();

            entity.Property(e => e.RegulationId).HasColumnName("Regulation_ID");
            entity.Property(e => e.AiscanOtherReference).HasColumnName("AIScanOtherReference");
            entity.Property(e => e.AiscanOtherSubject).HasColumnName("AIScanOtherSubject");
            entity.Property(e => e.AiscanReference).HasColumnName("AIScanReference");
            entity.Property(e => e.AiscanReferenceDescription).HasColumnName("AIScanReferenceDescription");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDate)
                .HasColumnType("datetime")
                .HasColumnName("Issue_Date");
            entity.Property(e => e.IssueYear).HasColumnName("Issue_Year");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.Processed).HasMaxLength(10);
            entity.Property(e => e.ReferenceOtherLang).HasMaxLength(50);
            entity.Property(e => e.Refrence)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegulationSeq).HasColumnName("Regulation_Seq");
            entity.Property(e => e.StagingEditEffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.StagingEditExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.StagingEditIssueDate).HasColumnType("datetime");
            entity.Property(e => e.StagingHeditOtherLangSubject).HasColumnName("StagingHEditOtherLangSubject");
            entity.Property(e => e.Subject).IsUnicode(false);
            entity.Property(e => e.SubjectOtherLang).IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("CONSGRC_RegulationsAccountId");

            entity.HasOne(d => d.ApprovedBy).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.ApprovedById)
                .HasConstraintName("FK_GRC_Regulations_GRC_USERS");

            entity.HasOne(d => d.Category).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("CONSGRC_RegulationCategory");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.CouCountryId)
                .HasConstraintName("FK_GRC_Regulations_Countries");

            entity.HasOne(d => d.IssuerNavigation).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.Issuer)
                .HasConstraintName("FK_GRC_Regulations_GRC_ISSUER");

            entity.HasOne(d => d.RegulationType).WithMany(p => p.GrcRegulations)
                .HasForeignKey(d => d.RegulationTypeId)
                .HasConstraintName("FK_GRC_Regulations_GRC_RegulationType");
        });

        modelBuilder.Entity<GrcRegulationCategory>(entity =>
        {
            entity.ToTable("GRC_RegulationCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcRegulationControl>(entity =>
        {
            entity.HasKey(e => e.RegulationControlId);

            entity.ToTable("GRC_Regulation_Control");

            entity.Property(e => e.RegulationControlId).HasColumnName("Regulation_Control_ID");
            entity.Property(e => e.ControlId).HasColumnName("Control_ID");
            entity.Property(e => e.ControlValue).HasColumnName("Control_Value");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.SubRegulationId).HasColumnName("Sub_Regulation_ID");

            entity.HasOne(d => d.Control).WithMany(p => p.GrcRegulationControls)
                .HasForeignKey(d => d.ControlId)
                .HasConstraintName("FK_GRC_Regulation_Control_GRC_Controls1");

            entity.HasOne(d => d.ControlProbClass).WithMany(p => p.GrcRegulationControls)
                .HasForeignKey(d => d.ControlProbClassId)
                .HasConstraintName("FK_GRC_Regulation_Control_GRC_CONTROL_PROPABILITY_CLASS");

            entity.HasOne(d => d.ControlSubjective).WithMany(p => p.GrcRegulationControls)
                .HasForeignKey(d => d.ControlSubjectiveId)
                .HasConstraintName("FK_GRC_Regulation_Control_GRC_Controls");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcRegulationControls)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_GRC_Regulation_Control_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcRegulationLanguage>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("GRC_RegulationLanguage");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RegulationLanguage_GRC_Accounts");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Orientation).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRegulationLanguages)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationLanguage_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRegulationLink>(entity =>
        {
            entity.ToTable("GRC_RegulationLink");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RegulationLink");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRegulationLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationLink_GRC_Accounts");

            entity.HasOne(d => d.LinkRegulation).WithMany(p => p.GrcRegulationLinkLinkRegulations)
                .HasForeignKey(d => d.LinkRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationLink_GRC_Regulations1");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcRegulationLinkRegulations)
                .HasForeignKey(d => d.RegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationLink_GRC_Regulations");
        });

        modelBuilder.Entity<GrcRegulationRisk>(entity =>
        {
            entity.HasKey(e => e.RegulationRiskId);

            entity.ToTable("GRC_Regulation_Risk");

            entity.Property(e => e.RegulationRiskId).HasColumnName("Regulation_Risk_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.RiskId).HasColumnName("Risk_ID");
            entity.Property(e => e.RiskValue).HasColumnName("Risk_Value");
            entity.Property(e => e.SubRegulationId).HasColumnName("Sub_Regulation_id");

            entity.HasOne(d => d.RiskClass).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.RiskClassId)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_RISK_CLASSIFICATION");

            entity.HasOne(d => d.RiskFinancial).WithMany(p => p.GrcRegulationRiskRiskFinancials)
                .HasForeignKey(d => d.RiskFinancialId)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_RiskFinAppetite");

            entity.HasOne(d => d.RiskFinancialStep1).WithMany(p => p.GrcRegulationRiskRiskFinancialStep1s)
                .HasForeignKey(d => d.RiskFinancialStep1Id)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_RiskFinAppetite1");

            entity.HasOne(d => d.Risk).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.RiskId)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_Risks");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.RiskImpactId)
                .HasConstraintName("GRC_Regulation_RiskRiskImpactId");

            entity.HasOne(d => d.RiskOccurrence).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.RiskOccurrenceId)
                .HasConstraintName("GRC_Regulation_GRC_Regulation_Risk");

            entity.HasOne(d => d.RiskSubjective).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.RiskSubjectiveId)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_RiskSubjective");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcRegulationRisks)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_GRC_Regulation_Risk_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcRegulationType>(entity =>
        {
            entity.ToTable("GRC_RegulationType");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RegulationType");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRegulationTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationType_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRegulationUserAccess>(entity =>
        {
            entity.ToTable("GRC_RegulationUserAccess");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcRegulationUserAccesses)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_GRC_RegulationUserAccess_GRC_Regulations");

            entity.HasOne(d => d.StagingRegulation).WithMany(p => p.GrcRegulationUserAccesses)
                .HasForeignKey(d => d.StagingRegulationId)
                .HasConstraintName("FK_GRC_RegulationUserAccess_GRC_StagingRegulation");

            entity.HasOne(d => d.User).WithMany(p => p.GrcRegulationUserAccesses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulationUserAccess_GRC_USERS");
        });

        modelBuilder.Entity<GrcRegulationsAttachment>(entity =>
        {
            entity.ToTable("GRC_RegulationsAttachments");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcRegulationsAttachments)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_GRC_RegulationsAttachments_GRC_Regulations");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcRegulationsAttachments)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_GRC_RegulationsAttachments_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcRegulationsStagingAttachment>(entity =>
        {
            entity.ToTable("GRC_RegulationsStagingAttachments");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcRegulationsStagingAttachments)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_GRC_RegulationsStagingAttachments_GRC_StagingRegulation");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcRegulationsStagingAttachments)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_GRC_RegulationsStagingAttachments_GRC_StagingSubRegulation");
        });

        modelBuilder.Entity<GrcRegulatoryReportingAttachment>(entity =>
        {
            entity.ToTable("GRC_RegulatoryReportingAttachments");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Reporting).WithMany(p => p.GrcRegulatoryReportingAttachments)
                .HasForeignKey(d => d.ReportingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RegulatoryReportingAttachments_GRC_REGULATORY_REPORTING_TRACK");
        });

        modelBuilder.Entity<GrcRegulatoryReportingTrack>(entity =>
        {
            entity.HasKey(e => e.ReportingId);

            entity.ToTable("GRC_REGULATORY_REPORTING_TRACK");

            entity.HasIndex(e => e.AccountId, "IX_GRC_REGULATORY_REPORTING_TRACK_GRC_Accounts");

            entity.Property(e => e.ReportingId).HasColumnName("Reporting_id");
            entity.Property(e => e.BreachFlag).HasColumnName("Breach_flag");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepDepartmentId).HasColumnName("Dep_department_id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.ManualStartingDate).HasColumnType("datetime");
            entity.Property(e => e.Periodic).HasMaxLength(50);
            entity.Property(e => e.ReportName)
                .HasMaxLength(200)
                .HasColumnName("REPORT_NAME");
            entity.Property(e => e.SelfAssessmentFlag).HasDefaultValue(true);
            entity.Property(e => e.SreSubRegulationId).HasColumnName("SRE_Sub_Regulation_Id");
            entity.Property(e => e.Weekday).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRegulatoryReportingTracks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_REGULATORY_REPORTING_TRACK_GRC_Accounts");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcRegulatoryReportingTracks)
                .HasForeignKey(d => d.DepDepartmentId)
                .HasConstraintName("FK_GRC_REGULATORY_REPORTING_TRACK_GRC_Departments");

            entity.HasOne(d => d.Issuer).WithMany(p => p.GrcRegulatoryReportingTracks)
                .HasForeignKey(d => d.IssuerId)
                .HasConstraintName("FK_GRC_REGULATORY_REPORTING_TRACK_GRC_ISSUER");

            entity.HasOne(d => d.SreSubRegulation).WithMany(p => p.GrcRegulatoryReportingTracks)
                .HasForeignKey(d => d.SreSubRegulationId)
                .HasConstraintName("FK_GRC_REGULATORY_REPORTING_TRACK_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcResponsibilityType>(entity =>
        {
            entity.ToTable("GRC_ResponsibilityType");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ResponsibilityType_GRC_Accounts");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcResponsibilityTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ResponsibilityType_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRisk>(entity =>
        {
            entity.HasKey(e => e.RiskId);

            entity.ToTable("GRC_Risks");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Risks_GRC_Accounts");

            entity.Property(e => e.RiskId).HasColumnName("Risk_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.RiskName)
                .HasMaxLength(200)
                .HasColumnName("Risk_Name");
            entity.Property(e => e.RiskWeight).HasColumnName("Risk_Weight");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRisks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Risks_GRC_Accounts");

            entity.HasOne(d => d.RiskNatureRule).WithMany(p => p.GrcRisks)
                .HasForeignKey(d => d.RiskNatureRuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Risks_GRC_RiskNatureRule");
        });

        modelBuilder.Entity<GrcRiskClassification>(entity =>
        {
            entity.HasKey(e => e.RiskClassificationId).HasName("PK_GRC_RISK_CLASSIFICATON");

            entity.ToTable("GRC_RISK_CLASSIFICATION");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RISK_CLASSIFICATION_GRC_Accounts");

            entity.Property(e => e.RiskClassificationId).HasColumnName("Risk_classification_id");
            entity.Property(e => e.ClassColor).HasMaxLength(200);
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExamPeriod).HasDefaultValue(0);
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RiskDescription)
                .HasMaxLength(100)
                .HasColumnName("Risk_Description");
            entity.Property(e => e.RiskName)
                .HasMaxLength(10)
                .HasColumnName("Risk_Name");
            entity.Property(e => e.RiskUpperValue).HasColumnName("Risk_Upper_value");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskClassifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RISK_CLASSIFICATION_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRiskFinAppetite>(entity =>
        {
            entity.ToTable("GRC_RiskFinAppetite");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskFinAppetite_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskFinAppetites)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskFinAppetite_GRC_Accounts");

            entity.HasOne(d => d.RiskClassification).WithMany(p => p.GrcRiskFinAppetites)
                .HasForeignKey(d => d.RiskClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_GRC_RISK_CLASSIFICATIONId");

            entity.HasOne(d => d.Risk).WithMany(p => p.GrcRiskFinAppetites)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskFinAppetite_GRC_Risks");
        });

        modelBuilder.Entity<GrcRiskNatureRule>(entity =>
        {
            entity.ToTable("GRC_RiskNatureRule");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskNatureRule_GRC_Accounts");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskNatureRules)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskNatureRule_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRiskProfile>(entity =>
        {
            entity.ToTable("GRC_RiskProfile");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskProfile_GRC_Accounts");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ExminedArticles).HasMaxLength(50);
            entity.Property(e => e.LastRunDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Month).HasMaxLength(50);
            entity.Property(e => e.RiskProfileYearId).HasColumnName("RiskProfileYearID");
            entity.Property(e => e.RiskType).HasMaxLength(50);
            entity.Property(e => e.SaansweredArticles).HasColumnName("SAAnsweredArticles");
            entity.Property(e => e.SaproceedsArticle).HasColumnName("SAProceedsArticle");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskProfiles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskProfile_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcRiskProfiles)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskProfile_Department");

            entity.HasOne(d => d.RiskProfileYear).WithMany(p => p.GrcRiskProfiles)
                .HasForeignKey(d => d.RiskProfileYearId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskProfile_GRC_CalendarYear");
        });

        modelBuilder.Entity<GrcRiskProfileEoy>(entity =>
        {
            entity.ToTable("GRC_RiskProfileEOY");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskProfileEOY_GRC_Accounts");

            entity.Property(e => e.CalendarYearId).HasColumnName("CalendarYearID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.SubRegulationId).HasColumnName("SubRegulationID");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskProfileEoys)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskProfileEOY_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcRiskProfileEoys)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_RiskProfileEOY_GRC_Department");
        });

        modelBuilder.Entity<GrcRiskSubjective>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_RiskNarrative");

            entity.ToTable("GRC_RiskSubjective");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskSubjective_GRC_Accounts");

            entity.Property(e => e.Creationdate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskSubjectives)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskSubjective_GRC_Accounts");

            entity.HasOne(d => d.RiskClassification).WithMany(p => p.GrcRiskSubjectives)
                .HasForeignKey(d => d.RiskClassificationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskNarrative_GRC_RISK_CLASSIFICATION");

            entity.HasOne(d => d.Risk).WithMany(p => p.GrcRiskSubjectives)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskNarrative_GRC_Risks");
        });

        modelBuilder.Entity<GrcRiskType>(entity =>
        {
            entity.HasKey(e => e.RiskTypeId);

            entity.ToTable("GRC_RiskType");

            entity.HasIndex(e => e.AccountId, "IX_GRC_RiskType_GRC_Accounts");

            entity.Property(e => e.RiskTypeId).HasColumnName("Risk_Type_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.RiskTypeName)
                .HasMaxLength(200)
                .HasColumnName("Risk_Type_Name");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRiskTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_RiskType_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRole>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("GRC_ROLES");

            entity.HasIndex(e => e.AccountId, "IX_GRC_ROLES_GRC_Accounts");

            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.SecurityLevel).HasColumnName("Security_Level");
            entity.Property(e => e.ViewAll).HasColumnName("View_all");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ROLES_GRC_Accounts");
        });

        modelBuilder.Entity<GrcRolePage>(entity =>
        {
            entity.HasKey(e => e.RolePageId);

            entity.ToTable("GRC_Role_Page");

            entity.Property(e => e.RolePageId).HasColumnName("Role_page_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated_Date");
            entity.Property(e => e.PagPageId).HasColumnName("Pag_page_id");
            entity.Property(e => e.RoleRoleCode).HasColumnName("Role_role_code");
            entity.Property(e => e.UpdateAllowed).HasColumnName("Update_Allowed");

            entity.HasOne(d => d.PagPage).WithMany(p => p.GrcRolePages)
                .HasForeignKey(d => d.PagPageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Role_Page_GRC_Pages");

            entity.HasOne(d => d.RoleRoleCodeNavigation).WithMany(p => p.GrcRolePages)
                .HasForeignKey(d => d.RoleRoleCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Role_Page_GRC_ROLES");
        });

        modelBuilder.Entity<GrcSaqanswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_SAQA__3213E83FD03E6405");

            entity.ToTable("GRC_SAQAnswers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Questionnaire).WithMany(p => p.GrcSaqanswers)
                .HasForeignKey(d => d.QuestionnaireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SAQAnswers_QuestionnaireId");
        });

        modelBuilder.Entity<GrcSector>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GRC_Sect__3214EC071F2AD30E");

            entity.ToTable("GRC_Sectors");

            entity.HasIndex(e => new { e.Id, e.Code, e.AccountId }, "GRC_SectorsIndex");

            entity.HasIndex(e => e.Code, "UQ__GRC_Sect__A25C5AA79BBC0126").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcSectors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_Sectors");
        });

        modelBuilder.Entity<GrcSelfAssessmentQuestionnaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_SelftAssessmentQuestionnaire");

            entity.ToTable("GRC_SelfAssessmentQuestionnaire");

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcSelfAssessmentStatus>(entity =>
        {
            entity.ToTable("GRC_SelfAssessmentStatus");

            entity.HasIndex(e => e.AccountId, "IX_GRC_SelfAssessmentStatus_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcSelfAssessmentStatuses)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_GRC_SelfAssessmentStatus_GRC_Accounts");
        });

        modelBuilder.Entity<GrcSource>(entity =>
        {
            entity.ToTable("GRC_Sources");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcStagingRegulation>(entity =>
        {
            entity.ToTable("GRC_StagingRegulation");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AiscanOtherReference).HasColumnName("AIScanOtherReference");
            entity.Property(e => e.AiscanOtherSubject).HasColumnName("AIScanOtherSubject");
            entity.Property(e => e.AiscanReference).HasColumnName("AIScanReference");
            entity.Property(e => e.AiscanReferenceDescription).HasColumnName("AIScanReferenceDescription");
            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.ReferenceOtherLang).HasMaxLength(50);
            entity.Property(e => e.ReleaseNumber).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(50);
            entity.Property(e => e.UploadFileName).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("CONSGRC_StagingRegulationAccountId");

            entity.HasOne(d => d.ApprovedBy).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.ApprovedById)
                .HasConstraintName("FK_GRC_StagingRegulation_GRC_USERS");

            entity.HasOne(d => d.Country).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingRegulation_GRC_Countries");

            entity.HasOne(d => d.Issuer).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.IssuerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingRegulation_GRC_ISSUER");

            entity.HasOne(d => d.RegulationType).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.RegulationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingRegulation_GRC_RegulationType");

            entity.HasOne(d => d.StagingStatus).WithMany(p => p.GrcStagingRegulations)
                .HasForeignKey(d => d.StagingStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingRegulation_GRC_StagingStatus");
        });

        modelBuilder.Entity<GrcStagingStatus>(entity =>
        {
            entity.ToTable("GRC_StagingStatus");

            entity.HasIndex(e => e.AccountId, "IX_GRC_StagingStatus_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcStagingStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingStatus_GRC_Accounts");
        });

        modelBuilder.Entity<GrcStagingSubRegulation>(entity =>
        {
            entity.ToTable("GRC_StagingSubRegulation");

            entity.HasIndex(e => e.AccountId, "IX_GRC_StagingSubRegulation_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AiscanOtherReference).HasColumnName("AIScanOtherReference");
            entity.Property(e => e.AiscanOtherSubject).HasColumnName("AIScanOtherSubject");
            entity.Property(e => e.AiscanReference).HasColumnName("AIScanReference");
            entity.Property(e => e.AiscanReferenceDescription).HasColumnName("AIScanReferenceDescription");
            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.CalendarOccurance).HasMaxLength(20);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ReferenceOtherLang).HasMaxLength(50);
            entity.Property(e => e.Source).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcStagingSubRegulations)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingSubRegulation_GRC_Accounts");

            entity.HasOne(d => d.ApprovedBy).WithMany(p => p.GrcStagingSubRegulations)
                .HasForeignKey(d => d.ApprovedById)
                .HasConstraintName("FK_GRC_StagingSubRegulation_GRC_USERS");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcStagingSubRegulations)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_GRC_StagingSubRegulation_GRC_StagingRegulation");

            entity.HasOne(d => d.RegulationType).WithMany(p => p.GrcStagingSubRegulations)
                .HasForeignKey(d => d.RegulationTypeId)
                .HasConstraintName("FK_GRC_StagingSubRegulation_GRC_RegulationType");

            entity.HasOne(d => d.StagingStatus).WithMany(p => p.GrcStagingSubRegulations)
                .HasForeignKey(d => d.StagingStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_StagingSubRegulation_GRC_StagingStatus");
        });

        modelBuilder.Entity<GrcSubProductsDepartment>(entity =>
        {
            entity.ToTable("GRC_SubProductsDepartments");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcSubProductsDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SubProductsDepartments_GRC_Departments");

            entity.HasOne(d => d.SubProduct).WithMany(p => p.GrcSubProductsDepartments)
                .HasForeignKey(d => d.SubProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SubProductsDepartments_SubProduct");
        });

        modelBuilder.Entity<GrcSubRegulation>(entity =>
        {
            entity.HasKey(e => e.SubRegulationId).HasName("PK_GRC_Sub_Relations");

            entity.ToTable("GRC_Sub_Regulations");

            entity.Property(e => e.SubRegulationId).HasColumnName("Sub_Regulation_ID");
            entity.Property(e => e.AiscanOtherReference).HasColumnName("AIScanOtherReference");
            entity.Property(e => e.AiscanOtherSubject).HasColumnName("AIScanOtherSubject");
            entity.Property(e => e.AiscanReference).HasColumnName("AIScanReference");
            entity.Property(e => e.AiscanReferenceDescription).HasColumnName("AIScanReferenceDescription");
            entity.Property(e => e.ArticleSeq).HasColumnName("Article_Seq");
            entity.Property(e => e.BreachCount).HasDefaultValue(0);
            entity.Property(e => e.CalenderDay).HasColumnName("Calender_Day");
            entity.Property(e => e.CalenderMonth).HasColumnName("Calender_Month");
            entity.Property(e => e.CalenderOccurance)
                .HasMaxLength(20)
                .HasColumnName("Calender_occurance");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_by");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("End_Date");
            entity.Property(e => e.ExamReq).HasColumnName("Exam_Req");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.IssueYear).HasColumnName("Issue_year");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.ManualStartingDate).HasColumnType("datetime");
            entity.Property(e => e.Processed).HasMaxLength(10);
            entity.Property(e => e.ReferenceDescription)
                .IsUnicode(false)
                .HasColumnName("Reference_description");
            entity.Property(e => e.ReferenceOtherLang).HasMaxLength(50);
            entity.Property(e => e.RegRegulationId).HasColumnName("Reg_Regulation_ID");
            entity.Property(e => e.RiskLevel).HasColumnName("Risk_level");
            entity.Property(e => e.StagingEditIssueDate).HasColumnType("datetime");
            entity.Property(e => e.SubRegulationRef).HasColumnName("Sub_regulation_ref");
            entity.Property(e => e.ThresholdWarning).HasDefaultValue(-1);
            entity.Property(e => e.WeekDay)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("week_day");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcSubRegulations)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("CONSGRC_Sub_RegulationsAccountId");

            entity.HasOne(d => d.ApprovedBy).WithMany(p => p.GrcSubRegulations)
                .HasForeignKey(d => d.ApprovedById)
                .HasConstraintName("FK_GRC_Sub_Regulations_GRC_USERS");

            entity.HasOne(d => d.RegRegulation).WithMany(p => p.GrcSubRegulations)
                .HasForeignKey(d => d.RegRegulationId)
                .HasConstraintName("FK_GRC_Sub_Regulations_GRC_Regulations");

            entity.HasOne(d => d.RegulationType).WithMany(p => p.GrcSubRegulations)
                .HasForeignKey(d => d.RegulationTypeId)
                .HasConstraintName("FK_GRC_Sub_Regulations_GRC_RegulationType");
        });

        modelBuilder.Entity<GrcSubRegulationDepartmentActivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_SubProductsDepartments_SubRegulation");

            entity.ToTable("GRC_SubRegulationDepartmentActivities");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.SubProductDepartmentId).HasColumnName("SubProductDepartmentID");
            entity.Property(e => e.SubRegulationId).HasColumnName("SubRegulationID");

            entity.HasOne(d => d.ProjectDepartment).WithMany(p => p.GrcSubRegulationDepartmentActivities)
                .HasForeignKey(d => d.ProjectDepartmentId)
                .HasConstraintName("FK_GRC_SubRegulationDepartmentActivities_GRC_ProjectDepartments");

            entity.HasOne(d => d.SubProductDepartment).WithMany(p => p.GrcSubRegulationDepartmentActivities)
                .HasForeignKey(d => d.SubProductDepartmentId)
                .HasConstraintName("FK_GRC_SubRegulationDepartmentActivities_GRC_SubProductsDepartments");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcSubRegulationDepartmentActivities)
                .HasForeignKey(d => d.SubRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SubRegulationDepartmentActivities_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcSubRegulationFunction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_RegulationFunctions");

            entity.ToTable("GRC_SubRegulationFunctions");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Function).WithMany(p => p.GrcSubRegulationFunctions)
                .HasForeignKey(d => d.FunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SubRegulationFunctions_GRC_BusinessUnitFunction");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.GrcSubRegulationFunctions)
                .HasForeignKey(d => d.SubRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_SubRegulationFunctions_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<GrcSubRegulationRule>(entity =>
        {
            entity.HasKey(e => e.RuleId);

            entity.ToTable("GRC_SUB_REGULATION_RULES");

            entity.Property(e => e.RuleId).HasColumnName("Rule_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FCondition)
                .HasMaxLength(10)
                .HasColumnName("F_Condition");
            entity.Property(e => e.FPercent)
                .HasColumnType("decimal(10, 3)")
                .HasColumnName("F_Percent");
            entity.Property(e => e.FRelation)
                .HasMaxLength(10)
                .HasColumnName("F_relation");
            entity.Property(e => e.FVariable1)
                .HasMaxLength(30)
                .HasColumnName("F_variable1");
            entity.Property(e => e.FVariable2)
                .HasMaxLength(30)
                .HasColumnName("F_Variable2");
            entity.Property(e => e.FreFirstValueId).HasColumnName("FRE_FIRST_VALUE_ID");
            entity.Property(e => e.FreSecondValueId).HasColumnName("FRE_SECOND_VALUE_ID");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RuleSeq).HasColumnName("Rule_Seq");
            entity.Property(e => e.SreSubRegulationId).HasColumnName("SRE_Sub_Regulation_id");
            entity.Property(e => e.SrrRuleId).HasColumnName("SRR_RULE_ID");

            entity.HasOne(d => d.FreFirstValue).WithMany(p => p.GrcSubRegulationRuleFreFirstValues)
                .HasForeignKey(d => d.FreFirstValueId)
                .HasConstraintName("FK_GRC_SUB_REGULATION_RULES_GRC_FINANCIAL_REF");

            entity.HasOne(d => d.FreSecondValue).WithMany(p => p.GrcSubRegulationRuleFreSecondValues)
                .HasForeignKey(d => d.FreSecondValueId)
                .HasConstraintName("FK_GRC_SUB_REGULATION_RULES_GRC_FINANCIAL_REF1");

            entity.HasOne(d => d.SreSubRegulation).WithMany(p => p.GrcSubRegulationRules)
                .HasForeignKey(d => d.SreSubRegulationId)
                .HasConstraintName("FK_GRC_SUB_REGULATION_RULES_GRC_Sub_Regulations");

            entity.HasOne(d => d.SrrRule).WithMany(p => p.InverseSrrRule)
                .HasForeignKey(d => d.SrrRuleId)
                .HasConstraintName("FK_GRC_SUB_REGULATION_RULES_GRC_SUB_REGULATION_RULES");
        });

        modelBuilder.Entity<GrcTestAttachment>(entity =>
        {
            entity.ToTable("GRC_TestAttachment");

            entity.Property(e => e.AttachedBy).HasMaxLength(50);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Test).WithMany(p => p.GrcTestAttachments)
                .HasForeignKey(d => d.TestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_TestAttachment_GRC_Test_Details");
        });

        modelBuilder.Entity<GrcTestDetail>(entity =>
        {
            entity.HasKey(e => e.TestDetailsId);

            entity.ToTable("GRC_Test_Details");

            entity.Property(e => e.TestDetailsId).HasColumnName("Test_Details_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due_Date");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.ExamFollowupDueDate).HasColumnType("datetime");
            entity.Property(e => e.Finding).HasMaxLength(500);
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.Recommendation).HasMaxLength(200);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.SubSubRegulationId).HasColumnName("Sub_SubRegulation_Id");
            entity.Property(e => e.ThTestHeaderId).HasColumnName("TH_Test_Header_Id");

            entity.HasOne(d => d.ComplianceApprove).WithMany(p => p.GrcTestDetailComplianceApproves)
                .HasForeignKey(d => d.ComplianceApproveId)
                .HasConstraintName("FK_GRC_Test_Details_GRC_USERSId");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcTestDetails)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_GRC_Test_Details_GRC_DepartmentsID");

            entity.HasOne(d => d.ManagerApprove).WithMany(p => p.GrcTestDetailManagerApproves)
                .HasForeignKey(d => d.ManagerApproveId)
                .HasConstraintName("FK_GRC_Test_Details_GRC_USERID");

            entity.HasOne(d => d.StagingComplianceApprove).WithMany(p => p.GrcTestDetailStagingComplianceApproves)
                .HasForeignKey(d => d.StagingComplianceApproveId)
                .HasConstraintName("FK_GRC_Test_Details_GRC_USERS1");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.GrcTestDetails)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_GRC_Test_Details_StatusId");

            entity.HasOne(d => d.SubSubRegulation).WithMany(p => p.GrcTestDetails)
                .HasForeignKey(d => d.SubSubRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Test_Details_GRC_Sub_Regulations");

            entity.HasOne(d => d.ThTestHeader).WithMany(p => p.GrcTestDetails)
                .HasForeignKey(d => d.ThTestHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Test_Details_GRC_Test_Details");
        });

        modelBuilder.Entity<GrcTestDetailAction>(entity =>
        {
            entity.ToTable("GRC_TestDetailActions");

            entity.HasIndex(e => e.TestDetailId, "IX_GRC_TestDetailActions");

            entity.HasIndex(e => e.ActionedBy, "IX_GRC_TestDetailActions_1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.ActionDueDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TestDueDate).HasColumnType("datetime");

            entity.HasOne(d => d.ActionedByNavigation).WithMany(p => p.GrcTestDetailActions)
                .HasForeignKey(d => d.ActionedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_TestDetailActions_GRC_USERS");

            entity.HasOne(d => d.TestDetail).WithMany(p => p.GrcTestDetailActions)
                .HasForeignKey(d => d.TestDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_TestDetailActions_GRC_Test_Details");
        });

        modelBuilder.Entity<GrcTestDetailControl>(entity =>
        {
            entity.ToTable("GRC_TestDetailControls");

            entity.HasIndex(e => e.ControlId, "IX_GRC_TestDetailControls");

            entity.HasIndex(e => e.ControlProbClassId, "IX_GRC_TestDetailControls_1");

            entity.HasIndex(e => e.ControlSubjectiveId, "IX_GRC_TestDetailControls_2");

            entity.HasIndex(e => e.TestDetailId, "IX_GRC_TestDetailControls_3");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ControlId).HasColumnName("Control_ID");
            entity.Property(e => e.ControlValue).HasColumnName("Control_Value");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Control).WithMany(p => p.GrcTestDetailControls)
                .HasForeignKey(d => d.ControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_TestDetailControls_GRC_Controls");

            entity.HasOne(d => d.ControlProbClass).WithMany(p => p.GrcTestDetailControls)
                .HasForeignKey(d => d.ControlProbClassId)
                .HasConstraintName("FK_GRC_TestDetailControls_GRC_CONTROL_PROPABILITY_CLASS");

            entity.HasOne(d => d.ControlSubjective).WithMany(p => p.GrcTestDetailControls)
                .HasForeignKey(d => d.ControlSubjectiveId)
                .HasConstraintName("FK_GRC_TestDetailControls_GRC_ControlClassSubjective");

            entity.HasOne(d => d.TestDetail).WithMany(p => p.GrcTestDetailControls)
                .HasForeignKey(d => d.TestDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_TestDetailControls_GRC_Test_Details");
        });

        modelBuilder.Entity<GrcTestHeader>(entity =>
        {
            entity.HasKey(e => e.TestHeaderId);

            entity.ToTable("GRC_Test_Header");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Test_Header_GRC_Accounts");

            entity.HasIndex(e => e.TestReference, "UQ__GRC_Test__E582C1587C50241E").IsUnique();

            entity.Property(e => e.TestHeaderId).HasColumnName("Test_Header_Id");
            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepDepartmentId).HasColumnName("Dep_Department_Id");
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.OfficerName)
                .HasMaxLength(500)
                .HasColumnName("Officer_Name");
            entity.Property(e => e.TestDate)
                .HasColumnType("datetime")
                .HasColumnName("Test_Date");
            entity.Property(e => e.TestReference)
                .HasMaxLength(50)
                .HasColumnName("Test_Reference");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Test_Header_GRC_Accounts");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.CouCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Test_Header_GRC_Countries");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.DepDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Test_Header_GRC_Test_Header");

            entity.HasOne(d => d.Product).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_GRC_Test_Header_Product");

            entity.HasOne(d => d.Regulation).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_GRC_Test_Header_GRC_Regulations");

            entity.HasOne(d => d.User).WithMany(p => p.GrcTestHeaders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_GRC_Test_Header_GRC_USERS");
        });

        modelBuilder.Entity<GrcTheme>(entity =>
        {
            entity.ToTable("GRC_Themes");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcThemes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Themes_GRC_Accounts");
        });

        modelBuilder.Entity<GrcThemeDetail>(entity =>
        {
            entity.ToTable("GRC_ThemeDetails");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Theme).WithMany(p => p.GrcThemeDetails)
                .HasForeignKey(d => d.ThemeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_ThemeDetails_GRC_Themes");
        });

        modelBuilder.Entity<GrcUser>(entity =>
        {
            entity.HasKey(e => e.UserId);

            entity.ToTable("GRC_USERS", tb => tb.HasTrigger("EncrypteData"));

            entity.HasIndex(e => e.AccountId, "IX_GRC_USERS_GRC_Accounts");

            entity.Property(e => e.UserId).HasColumnName("USER_ID");
            entity.Property(e => e.AddRegFlag).HasDefaultValue(false);
            entity.Property(e => e.BreachManagementFlag).HasDefaultValue(false);
            entity.Property(e => e.CouCountryId).HasColumnName("COU_COUNTRY_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.Deactivate).HasDefaultValue(false);
            entity.Property(e => e.DefaultActionUser).HasColumnName("default_action_user");
            entity.Property(e => e.DefaultRegLanguage).HasMaxLength(50);
            entity.Property(e => e.DepDepartmentId).HasColumnName("DEP_DEPARTMENT_ID");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(200)
                .HasColumnName("Email_address");
            entity.Property(e => e.Extention).HasMaxLength(200);
            entity.Property(e => e.LanguageCode).HasColumnName("Language_Code");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Mobile).HasMaxLength(200);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.OrmDeactivate).HasDefaultValue(false);
            entity.Property(e => e.OrmLock).HasDefaultValue(false);
            entity.Property(e => e.PasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.Phone).HasMaxLength(200);
            entity.Property(e => e.UserLogin)
                .HasMaxLength(100)
                .HasColumnName("User_Login");
            entity.Property(e => e.UserPassword)
                .HasMaxLength(100)
                .HasColumnName("User_Password");
            entity.Property(e => e.WhistleManagementFlag).HasDefaultValue(false);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_GRC_USERS_GRC_BRANCHES");

            entity.HasOne(d => d.CouCountry).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.CouCountryId)
                .HasConstraintName("FK_GRC_USERS_GRC_Countries");

            entity.HasOne(d => d.DefaultRegLanguageNavigation).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.DefaultRegLanguage)
                .HasConstraintName("FK_GRC_USERS_GRC_RegulationLanguage");

            entity.HasOne(d => d.DepDepartment).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.DepDepartmentId)
                .HasConstraintName("FK_GRC_USERS_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("GRC_Users_DivisionId");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.JobTitleId)
                .HasConstraintName("FK_GRC_USERS_GRC_JobTitle");

            entity.HasOne(d => d.LanguageCodeNavigation).WithMany(p => p.GrcUsers)
                .HasForeignKey(d => d.LanguageCode)
                .HasConstraintName("FK_GRC_USERS_GRC_Languages");
        });

        modelBuilder.Entity<GrcUserActivitiesLog>(entity =>
        {
            entity.ToTable("GrcUserActivitiesLog");

            entity.HasIndex(e => e.AccountId, "IX_GrcUserActivitiesLog_GRC_Accounts");

            entity.Property(e => e.Activity).HasMaxLength(255);
            entity.Property(e => e.ActivityDatetime).HasColumnType("datetime");
            entity.Property(e => e.BusinessName).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcUserActivitiesLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserActivitiesLog_GRC_Accounts");

            entity.HasOne(d => d.User).WithMany(p => p.GrcUserActivitiesLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserActivitiesLog_GRC_USERS");
        });

        modelBuilder.Entity<GrcUserAuditLog>(entity =>
        {
            entity.ToTable("GrcUserAuditLog");

            entity.HasIndex(e => e.AccountId, "IX_GrcUserAuditLog_GRC_Accounts");

            entity.Property(e => e.LogDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogInId).HasColumnName("LogInID");
            entity.Property(e => e.SessionId).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcUserAuditLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserAuditLog_GRC_Accounts");

            entity.HasOne(d => d.User).WithMany(p => p.GrcUserAuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserAuditLog_GRC_USERS");
        });

        modelBuilder.Entity<GrcUserDepartment>(entity =>
        {
            entity.HasKey(e => e.UserDepartmentId).HasName("PK_User_DepartmenTDepId");

            entity.ToTable("GRC_User_Department");

            entity.HasIndex(e => e.AccountId, "IX_GRC_User_Department_GRC_Accounts");

            entity.Property(e => e.UserDepartmentId).HasColumnName("User_Department_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.UserId).HasColumnName("User_Id");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcUserDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_User_Department_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.GrcUserDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Department_GRC_Departments");

            entity.HasOne(d => d.User).WithMany(p => p.GrcUserDepartments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Department_GRC_USERS");
        });

        modelBuilder.Entity<GrcUserManagementLog>(entity =>
        {
            entity.ToTable("GrcUserManagementLog");

            entity.HasIndex(e => e.AccountId, "IX_GrcUserManagementLog_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BranchNameNew).HasMaxLength(250);
            entity.Property(e => e.BranchNameOld).HasMaxLength(250);
            entity.Property(e => e.CbChangeRequestAdminFlagOld).HasColumnName("cbChangeRequestAdminFlagOld");
            entity.Property(e => e.CbChangeRequestAdminFlagnew).HasColumnName("cbChangeRequestAdminFlagnew");
            entity.Property(e => e.DefaultActionUserNew).HasColumnName("default_action_userNew");
            entity.Property(e => e.DefaultActionUserOld).HasColumnName("default_action_userOld");
            entity.Property(e => e.DeparmentNameNew).HasMaxLength(250);
            entity.Property(e => e.DeparmentNameOld).HasMaxLength(250);
            entity.Property(e => e.JobTitleNew).HasMaxLength(250);
            entity.Property(e => e.JobTitleOld).HasMaxLength(250);
            entity.Property(e => e.RoleNameNew).HasMaxLength(250);
            entity.Property(e => e.RoleNameOld).HasMaxLength(250);
            entity.Property(e => e.UserNameNew).HasMaxLength(250);
            entity.Property(e => e.UserNameOld).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.GrcUserManagementLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserManagementLog_GRC_Accounts");

            entity.HasOne(d => d.ActivityLog).WithMany(p => p.GrcUserManagementLogs)
                .HasForeignKey(d => d.ActivityLogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GrcUserManagementLog_GrcUserActivitiesLog");
        });

        modelBuilder.Entity<GrcUserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId);

            entity.ToTable("GRC_USER_ROLES");

            entity.Property(e => e.UserRoleId).HasColumnName("User_role_id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RolCode).HasColumnName("ROL_CODE");
            entity.Property(e => e.UseUserId).HasColumnName("USE_USER_ID");

            entity.HasOne(d => d.RolCodeNavigation).WithMany(p => p.GrcUserRoles)
                .HasForeignKey(d => d.RolCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USER_ROLES_GRC_ROLES");

            entity.HasOne(d => d.UseUser).WithMany(p => p.GrcUserRoles)
                .HasForeignKey(d => d.UseUserId)
                .HasConstraintName("FK_GRC_USER_ROLES_GRC_USERS");
        });

        modelBuilder.Entity<GrcVariable>(entity =>
        {
            entity.HasKey(e => e.VariableId);

            entity.ToTable("GRC_Variables");

            entity.HasIndex(e => e.AccountId, "IX_GRC_Variables_GRC_Accounts");

            entity.Property(e => e.VariableId).HasColumnName("Variable_id");
            entity.Property(e => e.AuditEmail1)
                .HasMaxLength(100)
                .HasColumnName("Audit_Email_1");
            entity.Property(e => e.AuditEmail2)
                .HasMaxLength(100)
                .HasColumnName("Audit_Email_2");
            entity.Property(e => e.AuditFlag).HasColumnName("Audit_Flag");
            entity.Property(e => e.CalendarNotficiation).HasColumnName("CALENDAR_NOTFICIATION");
            entity.Property(e => e.ComplaintsEmail1)
                .HasMaxLength(100)
                .HasColumnName("Complaints_Email_1");
            entity.Property(e => e.ComplaintsEmail2)
                .HasMaxLength(100)
                .HasColumnName("Complaints_Email_2");
            entity.Property(e => e.ControlProbabilityFlag)
                .HasMaxLength(1)
                .HasColumnName("Control_probability_flag");
            entity.Property(e => e.CountryId).HasColumnName("Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.ExamDuePeriod).HasDefaultValue(1);
            entity.Property(e => e.GracePeriod).HasColumnName("GRACE_PERIOD");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.MailAddress).HasColumnName("mailAddress");
            entity.Property(e => e.MailAddressEnableSsl)
                .HasDefaultValue(true)
                .HasColumnName("mailAddressEnableSSL");
            entity.Property(e => e.MailAddressPass).HasColumnName("mailAddressPass");
            entity.Property(e => e.MailAddressPort).HasColumnName("mailAddressPort");
            entity.Property(e => e.MailAddressSmtpserver).HasColumnName("mailAddressSMTPServer");
            entity.Property(e => e.MailSupport).HasColumnName("mailSupport");
            entity.Property(e => e.Rcmm)
                .HasMaxLength(50)
                .HasColumnName("RCMM");
            entity.Property(e => e.SumFormulaFlag)
                .HasMaxLength(1)
                .HasColumnName("Sum_formula_flag");
            entity.Property(e => e.Taken).HasMaxLength(50);
            entity.Property(e => e.UserAccessFlag).HasDefaultValue(true);
            entity.Property(e => e.WBlowerPolicy).HasColumnName("wBlowerPolicy");
            entity.Property(e => e.WblowerDepartment).HasDefaultValue(true);
            entity.Property(e => e.WeekendDays).HasColumnName("WEEKEND_DAYS");
            entity.Property(e => e.WeekendStart)
                .HasMaxLength(50)
                .HasColumnName("WEEKEND_START");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcVariables)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Variables_GRC_Accounts");

            entity.HasOne(d => d.Country).WithMany(p => p.GrcVariables)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_Variables_GRC_Countries");
        });

        modelBuilder.Entity<GrcWblowerCaseBranch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_GRC_WblowerBranches");

            entity.ToTable("GRC_WblowerCaseBranches");

            entity.HasIndex(e => e.AccountId, "IX_GRC_WblowerCaseBranches_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.GrcWblowerCaseBranches)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_WblowerCaseBranches_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.GrcWblowerCaseBranches)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_WblowerBranches_GRC_BRANCHES");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.GrcWblowerCaseBranches)
                .HasForeignKey(d => d.WblowerCaseId)
                .HasConstraintName("FK_GRC_WblowerBranches_WblowerCases");
        });

        modelBuilder.Entity<GrcWhistleblowerProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WBProcess");

            entity.ToTable("GRC_Whistleblower_Process");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GrcWhistleblowerRisk>(entity =>
        {
            entity.ToTable("GRC_Whistleblower_Risk");

            entity.HasIndex(e => e.Code, "IX_GRC_Whistleblower_Risk");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Field }).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Field).HasMaxLength(100);
        });

        modelBuilder.Entity<Institute>(entity =>
        {
            entity.ToTable("Institute");

            entity.HasIndex(e => e.Code, "IX_Institute").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_Institute_GRC_Accounts");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.Institutes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Institute_GRC_Accounts");

            entity.HasOne(d => d.Country).WithMany(p => p.Institutes)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Institute_Country");
        });

        modelBuilder.Entity<IntegrationApiMonitor>(entity =>
        {
            entity.ToTable("IntegrationApiMonitor");

            entity.Property(e => e.Apiname).HasColumnName("APIName");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.IntegrationApiMonitors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IntegrationApiMonitor_IntegrationApiStatus");
        });

        modelBuilder.Entity<IntegrationApiStatus>(entity =>
        {
            entity.ToTable("IntegrationApiStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName").HasFilter("([StateName] IS NOT NULL)");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Name }).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.Property(e => e.Name).HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => new { e.Queue, e.Id }).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.Property(e => e.Queue).HasMaxLength(50);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<License>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_licenses");

            entity.HasIndex(e => e.AccountId, "IX_LicensesDetails_GRC_Accounts");

            entity.HasIndex(e => e.AccountId, "IX_Licenses_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Licenses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Licenses_GRC_Accounts");
        });

        modelBuilder.Entity<LicensesDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_licenses1");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Installationdate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.LicensesDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LicensesDetails_GRC_Accounts");

            entity.HasOne(d => d.Install).WithMany(p => p.LicensesDetails)
                .HasForeignKey(d => d.InstallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LicensesD__Insta__1E5A75C5");
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Id }).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<MapCountry>(entity =>
        {
            entity.HasKey(e => e.CountryCode);

            entity.ToTable("MapCountry");

            entity.HasIndex(e => e.AccountId, "IX_MapCountry_GRC_Accounts");

            entity.Property(e => e.CountryCode).HasMaxLength(10);
            entity.Property(e => e.CountryName).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.MapCountries)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MapCountry_GRC_Accounts");
        });

        modelBuilder.Entity<OldgrcFinancialCollection>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("OLDGRC_FINANCIAL_COLLECTION");

            entity.Property(e => e.CouCountryId).HasColumnName("Cou_Country_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.FinancialDate)
                .HasColumnType("datetime")
                .HasColumnName("Financial_date");
            entity.Property(e => e.FreValueId).HasColumnName("FRE_value_id");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.Value).HasColumnName("VALUE");
        });

        modelBuilder.Entity<OrmActionMonitor>(entity =>
        {
            entity.ToTable("OrmActionMonitor");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Rcsaid).HasColumnName("RCSAId");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitor_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmActionMonitor_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmActionMonitor_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmActionMonitor_Division");

            entity.HasOne(d => d.EventLoss).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.EventLossId)
                .HasConstraintName("FK_OrmActionMonitor_OrmLossEvents");

            entity.HasOne(d => d.KriEntry).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.KriEntryId)
                .HasConstraintName("FK_OrmActionMonitor_OrmKriEntry");

            entity.HasOne(d => d.PlanSchedule).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.PlanScheduleId)
                .HasConstraintName("FK_OrmActionMonitor_PlanSchedule");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.ProcessDetailId)
                .HasConstraintName("FK_OrmActionMonitor_OrmProcessDetails");

            entity.HasOne(d => d.Rcsa).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.Rcsaid)
                .HasConstraintName("FK_OrmActionMonitor_OrmRcsaTasks");

            entity.HasOne(d => d.Source).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.SourceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitor_OrmSoure");

            entity.HasOne(d => d.Status).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitor_OrmActionStatus");

            entity.HasOne(d => d.User).WithMany(p => p.OrmActionMonitors)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmActionMonitor_GRC_USERS");
        });

        modelBuilder.Entity<OrmActionMonitorDetail>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedResolvedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmActionMonitorDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitorDetails_GRC_Accounts");

            entity.HasOne(d => d.ActionMonitor).WithMany(p => p.OrmActionMonitorDetails)
                .HasForeignKey(d => d.ActionMonitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitorDetails_OrmActionMonitor");

            entity.HasOne(d => d.ActionStatus).WithMany(p => p.OrmActionMonitorDetails)
                .HasForeignKey(d => d.ActionStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitorDetails_OrmActionStatus");

            entity.HasOne(d => d.ActionUser).WithMany(p => p.OrmActionMonitorDetailActionUsers)
                .HasForeignKey(d => d.ActionUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionMonitorDetails_GRC_USERS");

            entity.HasOne(d => d.AprovedByNavigation).WithMany(p => p.OrmActionMonitorDetailAprovedByNavigations)
                .HasForeignKey(d => d.AprovedBy)
                .HasConstraintName("FK_OrmActionMonitorDetails_GRC_USERS1");
        });

        modelBuilder.Entity<OrmActionStatus>(entity =>
        {
            entity.ToTable("OrmActionStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmActionStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmActionStatus_GRC_Accounts");
        });

        modelBuilder.Entity<OrmAssessmentStatus>(entity =>
        {
            entity.ToTable("OrmAssessmentStatus");

            entity.Property(e => e.LastUpdateDate).HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmAssessmentStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmAssessmentStatus_GRC_Accounts");
        });

        modelBuilder.Entity<OrmCategory>(entity =>
        {
            entity.ToTable("OrmCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmCategory_GRC_Accounts");
        });

        modelBuilder.Entity<OrmControlCategory>(entity =>
        {
            entity.ToTable("OrmControlCategory");

            entity.Property(e => e.Code).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmControlCategories)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_OrmControlCategory_GRC_Accounts");
        });

        modelBuilder.Entity<OrmControlCategoryElement>(entity =>
        {
            entity.ToTable("OrmControlCategoryElement");

            entity.Property(e => e.Code).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmControlCategoryElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmControlCategoryElement_GRC_Accounts");

            entity.HasOne(d => d.ControlCategory).WithMany(p => p.OrmControlCategoryElements)
                .HasForeignKey(d => d.ControlCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmControlCategoryElement_OrmControlCategory");
        });

        modelBuilder.Entity<OrmControlDesignEffective>(entity =>
        {
            entity.ToTable("OrmControlDesignEffective");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmControlDesignEffectives)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmControlDesignEffective_GRC_Accounts");
        });

        modelBuilder.Entity<OrmControlEffectScore>(entity =>
        {
            entity.ToTable("OrmControlEffectScore");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmControlEffectScores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmControlEffectScore_GRC_Accounts");
        });

        modelBuilder.Entity<OrmEmail>(entity =>
        {
            entity.HasKey(e => e.EmailId);

            entity.Property(e => e.EmailId).HasColumnName("Email_Id");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailAddressCc).HasColumnName("Email_Address_CC");
            entity.Property(e => e.EmailAddressFrom)
                .HasMaxLength(50)
                .HasColumnName("Email_Address_From");
            entity.Property(e => e.EmailAddressTo).HasColumnName("Email_Address_To");
            entity.Property(e => e.EmailBody).HasColumnName("Email_Body");
            entity.Property(e => e.EmailSent).HasColumnName("Email_Sent");
            entity.Property(e => e.EmailSubject)
                .HasMaxLength(200)
                .HasColumnName("Email_Subject");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_By");
            entity.Property(e => e.LastUpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Updated_Date");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmEmails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmEmails_GRC_Accounts");
        });

        modelBuilder.Entity<OrmEmailsControl>(entity =>
        {
            entity.ToTable("OrmEmailsControl");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrmInherentRiskScore>(entity =>
        {
            entity.ToTable("OrmInherentRiskScore");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmInherentRiskScores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmInherentRiskScore_OrmInherentRiskScore");
        });

        modelBuilder.Entity<OrmKri>(entity =>
        {
            entity.ToTable("OrmKri");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");
            entity.Property(e => e.PeriodDate).HasColumnType("datetime");
            entity.Property(e => e.PeriodWeekDay).HasMaxLength(20);

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKris)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKri_GRC_Accounts");

            entity.HasOne(d => d.Currency).WithMany(p => p.OrmKris)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_OrmKri_Currency");

            entity.HasOne(d => d.Direction).WithMany(p => p.OrmKris)
                .HasForeignKey(d => d.DirectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKri_OrmKriDirection");

            entity.HasOne(d => d.Period).WithMany(p => p.OrmKris)
                .HasForeignKey(d => d.PeriodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKri_OrmKriPeriod");

            entity.HasOne(d => d.Type).WithMany(p => p.OrmKris)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKri_OrmKriType");
        });

        modelBuilder.Entity<OrmKriDirection>(entity =>
        {
            entity.ToTable("OrmKriDirection");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriDirections)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriDirection_AccountId");
        });

        modelBuilder.Entity<OrmKriEntry>(entity =>
        {
            entity.ToTable("OrmKriEntry");

            entity.Property(e => e.AssessmentDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EntryDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriEntry_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmKriEntry_GRC_BRANCHES");

            entity.HasOne(d => d.Currency).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.CurrencyId)
                .HasConstraintName("FK_OrmKriEntry_Currency");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmKriEntry_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmKriEntry_Division");

            entity.HasOne(d => d.Kri).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.KriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriEntry_OrmKri");

            entity.HasOne(d => d.User).WithMany(p => p.OrmKriEntries)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmKriEntry_GRC_USERS");
        });

        modelBuilder.Entity<OrmKriPeriod>(entity =>
        {
            entity.ToTable("OrmKriPeriod");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriPeriods)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriPeriod_GRC_Accounts");
        });

        modelBuilder.Entity<OrmKriProccessBl>(entity =>
        {
            entity.ToTable("OrmKriProccessBL");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriProccessBL_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmKriProccessBL_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmKriProccessBL_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmKriProccessBL_Division");

            entity.HasOne(d => d.Kri).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.KriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriProccessBL_OrmKri");

            entity.HasOne(d => d.KriProcessDetail).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.KriProcessDetailId)
                .HasConstraintName("FK_OrmKriProccessBL_OrmProcessDetails");

            entity.HasOne(d => d.User).WithMany(p => p.OrmKriProccessBls)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmKriProccessBL_GRC_USERS");
        });

        modelBuilder.Entity<OrmKriProcess>(entity =>
        {
            entity.ToTable("OrmKriProcess");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriProcesses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriProcess_GRC_Accounts");

            entity.HasOne(d => d.Kri).WithMany(p => p.OrmKriProcesses)
                .HasForeignKey(d => d.KriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriProcess_OrmKri");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmKriProcesses)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriProcess_OrmProcessDetails");
        });

        modelBuilder.Entity<OrmKriType>(entity =>
        {
            entity.ToTable("OrmKriType");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmKriTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmKriType_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEvent>(entity =>
        {
            entity.Property(e => e.BaseAmmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DetectionDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.InvestigationClosedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.LossAmmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RecoveryAmmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RecoveryDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEvents_GRC_Accounts");

            entity.HasOne(d => d.Category).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventCategory");

            entity.HasOne(d => d.CauseOfLoss).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.CauseOfLossId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventCauseOfLoss");

            entity.HasOne(d => d.CurrencyBase).WithMany(p => p.OrmLossEventCurrencyBases)
                .HasForeignKey(d => d.CurrencyBaseId)
                .HasConstraintName("FK_OrmLossEvents_Currency");

            entity.HasOne(d => d.CurrencyLoss).WithMany(p => p.OrmLossEventCurrencyLosses)
                .HasForeignKey(d => d.CurrencyLossId)
                .HasConstraintName("FK_OrmLossEvents_Currency1");

            entity.HasOne(d => d.CurrencyRecovery).WithMany(p => p.OrmLossEventCurrencyRecoveries)
                .HasForeignKey(d => d.CurrencyRecoveryId)
                .HasConstraintName("FK_OrmLossEvents_Currency2");

            entity.HasOne(d => d.Product).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventProducts");

            entity.HasOne(d => d.RecoverySource).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.RecoverySourceId)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventRecoverySource");

            entity.HasOne(d => d.Status).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventStatus");

            entity.HasOne(d => d.Type).WithMany(p => p.OrmLossEvents)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEvents_OrmLossEventType");
        });

        modelBuilder.Entity<OrmLossEventCategory>(entity =>
        {
            entity.ToTable("OrmLossEventCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventCategory_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEventCauseOfLoss>(entity =>
        {
            entity.ToTable("OrmLossEventCauseOfLoss");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventCauseOfLosses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventCauseOfLoss_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEventControl>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventControls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventControls_GRC_Accounts");

            entity.HasOne(d => d.Control).WithMany(p => p.OrmLossEventControls)
                .HasForeignKey(d => d.ControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventControls_OrmRiskControlCategory");

            entity.HasOne(d => d.LossEvent).WithMany(p => p.OrmLossEventControls)
                .HasForeignKey(d => d.LossEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventControls_OrmLossEvents");
        });

        modelBuilder.Entity<OrmLossEventKri>(entity =>
        {
            entity.ToTable("OrmLossEventKri");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventKris)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventKri_GRC_Accounts");

            entity.HasOne(d => d.Kri).WithMany(p => p.OrmLossEventKris)
                .HasForeignKey(d => d.KriId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventKri_OrmKri");

            entity.HasOne(d => d.LossEvent).WithMany(p => p.OrmLossEventKris)
                .HasForeignKey(d => d.LossEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventKri_OrmLossEvents");
        });

        modelBuilder.Entity<OrmLossEventProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_LossEventProcess");

            entity.ToTable("OrmLossEventProcess");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.LossEvent).WithMany(p => p.OrmLossEventProcesses)
                .HasForeignKey(d => d.LossEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LossEventProcess_OrmLossEvents");

            entity.HasOne(d => d.ProcessBusinessLine).WithMany(p => p.OrmLossEventProcesses)
                .HasForeignKey(d => d.ProcessBusinessLineId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventProcess_OrmLossEventProcessBusinessLines");

            entity.HasOne(d => d.ProcessDetailes).WithMany(p => p.OrmLossEventProcesses)
                .HasForeignKey(d => d.ProcessDetailesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LossEventProcess_OrmProcessDetails");
        });

        modelBuilder.Entity<OrmLossEventProcessBusinessLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrmLossEventBusinessLines");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventBusinessLines_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmLossEventBusinessLines_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmLossEventBusinessLines_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmLossEventBusinessLines_Division");

            entity.HasOne(d => d.LossEvent).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.LossEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventBusinessLines_OrmLossEvents");

            entity.HasOne(d => d.User).WithMany(p => p.OrmLossEventProcessBusinessLines)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmLossEventBusinessLines_GRC_USERS");
        });

        modelBuilder.Entity<OrmLossEventProduct>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventProducts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventProducts_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEventRecoverySource>(entity =>
        {
            entity.ToTable("OrmLossEventRecoverySource");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventRecoverySources)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventRecoverySource_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEventRisk>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventRisks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventRisks_GRC_Accounts");

            entity.HasOne(d => d.LossEvent).WithMany(p => p.OrmLossEventRisks)
                .HasForeignKey(d => d.LossEventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventRisks_OrmLossEvents");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmLossEventRisks)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventRisks_OrmRiskCategory");
        });

        modelBuilder.Entity<OrmLossEventStatus>(entity =>
        {
            entity.ToTable("OrmLossEventStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventStatus_GRC_Accounts");
        });

        modelBuilder.Entity<OrmLossEventType>(entity =>
        {
            entity.ToTable("OrmLossEventType");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmLossEventTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmLossEventType_GRC_Accounts");
        });

        modelBuilder.Entity<OrmProcess>(entity =>
        {
            entity.ToTable("OrmProcess");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcesses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcess_GRC_Accounts");

            entity.HasOne(d => d.ProcessType).WithMany(p => p.OrmProcesses)
                .HasForeignKey(d => d.ProcessTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcess_OrmProcessTypes");
        });

        modelBuilder.Entity<OrmProcessBlLink>(entity =>
        {
            entity.ToTable("OrmProcessBlLink");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessBlLink_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmProcessBlLink_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmProcessBlLink_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmProcessBlLink_Division");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.ProcessDetailId)
                .HasConstraintName("FK_OrmProcessBlLink_OrmProcessDetails");

            entity.HasOne(d => d.User).WithMany(p => p.OrmProcessBlLinks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmProcessBlLink_GRC_USERS");
        });

        modelBuilder.Entity<OrmProcessControlLink>(entity =>
        {
            entity.ToTable("OrmProcessControlLink");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessControlLink_GRC_Accounts");

            entity.HasOne(d => d.ControlDesignEffect).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.ControlDesignEffectId)
                .HasConstraintName("FK_OrmProcessControlLink_OrmControlDesignEffective");

            entity.HasOne(d => d.ControlElement).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.ControlElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessControlLink_OrmControlCategoryElement");

            entity.HasOne(d => d.ProcessRiskLink).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.ProcessRiskLinkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessControlLink_OrmProcessRiskLink");

            entity.HasOne(d => d.ResidualRiskExposureNavigation).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.ResidualRiskExposure)
                .HasConstraintName("FK_OrmProcessControlLink_OrmResidualRiskExposure");

            entity.HasOne(d => d.ResidualRiskQuadrant).WithMany(p => p.OrmProcessControlLinks)
                .HasForeignKey(d => d.ResidualRiskQuadrantId)
                .HasConstraintName("FK_OrmProcessControlLink_OrmResidualRiskQuadrant");
        });

        modelBuilder.Entity<OrmProcessDetail>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetails_GRC_Accounts");

            entity.HasOne(d => d.Subject).WithMany(p => p.OrmProcessDetails)
                .HasForeignKey(d => d.SubjectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetails_OrmProcessSubject");
        });

        modelBuilder.Entity<OrmProcessDetailBlwork>(entity =>
        {
            entity.ToTable("OrmProcessDetailBLWork");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessDetailBlid).HasColumnName("ProcessDetailBLId");

            entity.HasOne(d => d.InherentRiskScoreNavigation).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.InherentRiskScore)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmInherentRiskScore");

            entity.HasOne(d => d.ProcessDetailBl).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.ProcessDetailBlid)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmProcessBlLink");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmProcessDetails");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.RiskElementId)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmRiskElements");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.RiskImpactId)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmRiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.OrmProcessDetailBlworks)
                .HasForeignKey(d => d.RiskOccurenceId)
                .HasConstraintName("FK_OrmProcessDetailBLWork_OrmRiskOccurence");
        });

        modelBuilder.Entity<OrmProcessDetailBlworkDetail>(entity =>
        {
            entity.ToTable("OrmProcessDetailBLWorkDetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DetailScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ElementScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AsesmntElementDetail).WithMany(p => p.OrmProcessDetailBlworkDetails)
                .HasForeignKey(d => d.AsesmntElementDetailId)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetails_ORMRaElementDetails");

            entity.HasOne(d => d.AsesmntElement).WithMany(p => p.OrmProcessDetailBlworkDetails)
                .HasForeignKey(d => d.AsesmntElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetails_ORMRaElements");

            entity.HasOne(d => d.ElementRange).WithMany(p => p.OrmProcessDetailBlworkDetails)
                .HasForeignKey(d => d.ElementRangeId)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetails_ORMRaElementRanges");

            entity.HasOne(d => d.ProcessLinkWork).WithMany(p => p.OrmProcessDetailBlworkDetails)
                .HasForeignKey(d => d.ProcessLinkWorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetails_OrmProcessLinkWork");
        });

        modelBuilder.Entity<OrmProcessDetailBlworkDetailsRange>(entity =>
        {
            entity.ToTable("OrmProcessDetailBLWorkDetailsRange");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.OrmProcessDetailBlworkDetailsId).HasColumnName("OrmProcessDetailBLWorkDetailsId");

            entity.HasOne(d => d.DetailsRange).WithMany(p => p.OrmProcessDetailBlworkDetailsRanges)
                .HasForeignKey(d => d.DetailsRangeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetailsRange_ORMRaElementDetailRanges");

            entity.HasOne(d => d.OrmProcessDetailBlworkDetails).WithMany(p => p.OrmProcessDetailBlworkDetailsRanges)
                .HasForeignKey(d => d.OrmProcessDetailBlworkDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessDetailBLWorkDetailsRange_OrmProcessDetailBLWorkDetails");
        });

        modelBuilder.Entity<OrmProcessRiskLink>(entity =>
        {
            entity.ToTable("OrmProcessRiskLink");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessRiskLink_GRC_Accounts");

            entity.HasOne(d => d.InherentRiskScoreNavigation).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.InherentRiskScore)
                .HasConstraintName("FK_OrmProcessRiskLink_OrmInherentRiskScore");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessRiskLink_OrmProcessDetails");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessRiskLink_OrmRiskCategory");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.RiskImpactId)
                .HasConstraintName("FK_OrmProcessRiskLink_OrmRiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.OrmProcessRiskLinks)
                .HasForeignKey(d => d.RiskOccurenceId)
                .HasConstraintName("FK_OrmProcessRiskLink_OrmRiskOccurence");
        });

        modelBuilder.Entity<OrmProcessSubject>(entity =>
        {
            entity.ToTable("OrmProcessSubject");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessSubjects)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessSubject_GRC_Accounts");

            entity.HasOne(d => d.Process).WithMany(p => p.OrmProcessSubjects)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessSubject_OrmProcess");
        });

        modelBuilder.Entity<OrmProcessType>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmProcessTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmProcessTypes_GRC_Accounts");
        });

        modelBuilder.Entity<OrmQuadrantValue>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmQuadrantValues)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmQuadrantValues_GRC_Accounts");

            entity.HasOne(d => d.ResidualQuadrant).WithMany(p => p.OrmQuadrantValues)
                .HasForeignKey(d => d.ResidualQuadrantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmQuadrantValues_OrmResidualRiskQuadrant");
        });

        modelBuilder.Entity<OrmQuestionnaireAnswer>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Questionnaire).WithMany(p => p.OrmQuestionnaireAnswers)
                .HasForeignKey(d => d.QuestionnaireId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmQuestionnaireAnswers_OrmQuestionnnaire");
        });

        modelBuilder.Entity<OrmQuestionnnaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_OrmQuestionier");

            entity.ToTable("OrmQuestionnnaire");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmQuestionnnaires)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmQuestionnnaire_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRbaControlAsesmnt>(entity =>
        {
            entity.ToTable("OrmRbaControlAsesmnt");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_GRC_Accounts");

            entity.HasOne(d => d.ControlDesignEffect).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.ControlDesignEffectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmControlDesignEffective");

            entity.HasOne(d => d.ControlProccessRisk).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.ControlProccessRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmProcessControlLink");

            entity.HasOne(d => d.InherentRiskScoreNavigation).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.InherentRiskScore)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmInherentRiskScore");

            entity.HasOne(d => d.ResidualRiskExposureNavigation).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.ResidualRiskExposure)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmResidualRiskExposure");

            entity.HasOne(d => d.ResidualRiskQuadrant).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.ResidualRiskQuadrantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmResidualRiskQuadrant");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.RiskElementId)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmRiskElements");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.RiskImpactId)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmRiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.OrmRbaControlAsesmnts)
                .HasForeignKey(d => d.RiskOccurenceId)
                .HasConstraintName("FK_OrmRbaControlAsesmnt_OrmRiskOccurence");
        });

        modelBuilder.Entity<OrmRbaControlProcessControl>(entity =>
        {
            entity.ToTable("OrmRbaControlProcessControl");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRbaControlProcessControls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlProcessControl_GRC_Accounts");

            entity.HasOne(d => d.ControlDesignEffect).WithMany(p => p.OrmRbaControlProcessControls)
                .HasForeignKey(d => d.ControlDesignEffectId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlProcessControl_OrmControlDesignEffective");

            entity.HasOne(d => d.ControlProccessRisk).WithMany(p => p.OrmRbaControlProcessControls)
                .HasForeignKey(d => d.ControlProccessRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlProcessControl_OrmProcessControlLink");

            entity.HasOne(d => d.ResidualRiskExposureNavigation).WithMany(p => p.OrmRbaControlProcessControls)
                .HasForeignKey(d => d.ResidualRiskExposure)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlProcessControl_OrmResidualRiskExposure");

            entity.HasOne(d => d.ResidualRiskQuadrant).WithMany(p => p.OrmRbaControlProcessControls)
                .HasForeignKey(d => d.ResidualRiskQuadrantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaControlProcessControl_OrmResidualRiskQuadrant");
        });

        modelBuilder.Entity<OrmRbaProcessRiskAsesmnt>(entity =>
        {
            entity.ToTable("OrmRbaProcessRiskAsesmnt");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_GRC_Accounts");

            entity.HasOne(d => d.InherentRiskScoreNavigation).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.InherentRiskScore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmInherentRiskScore");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.ProcessDetailId)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmProcessDetails");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmRiskCategory");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.RiskElementId)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmRiskElements");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.RiskImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmRiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.RiskOccurenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmRiskOccurence");

            entity.HasOne(d => d.RiskProcessLink).WithMany(p => p.OrmRbaProcessRiskAsesmnts)
                .HasForeignKey(d => d.RiskProcessLinkId)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmnt_OrmProcessRiskLink");
        });

        modelBuilder.Entity<OrmRbaProcessRiskAsesmntDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DetailScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ElementScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AsesmntElementDetail).WithMany(p => p.OrmRbaProcessRiskAsesmntDetails)
                .HasForeignKey(d => d.AsesmntElementDetailId)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetails_ORMRaElementDetails");

            entity.HasOne(d => d.AsesmntElement).WithMany(p => p.OrmRbaProcessRiskAsesmntDetails)
                .HasForeignKey(d => d.AsesmntElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetails_ORMRaElements");

            entity.HasOne(d => d.AsesmntWork).WithMany(p => p.OrmRbaProcessRiskAsesmntDetails)
                .HasForeignKey(d => d.AsesmntWorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetails_OrmRbaProcessRiskAsesmntWork");

            entity.HasOne(d => d.ElementRange).WithMany(p => p.OrmRbaProcessRiskAsesmntDetails)
                .HasForeignKey(d => d.ElementRangeId)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetails_ORMRaElementRanges");
        });

        modelBuilder.Entity<OrmRbaProcessRiskAsesmntDetailsRange>(entity =>
        {
            entity.ToTable("OrmRbaProcessRiskAsesmntDetailsRange");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.DetailsRange).WithMany(p => p.OrmRbaProcessRiskAsesmntDetailsRanges)
                .HasForeignKey(d => d.DetailsRangeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetailsRange_ORMRaElementDetailRanges");

            entity.HasOne(d => d.ProcessRiskAsesmntDetails).WithMany(p => p.OrmRbaProcessRiskAsesmntDetailsRanges)
                .HasForeignKey(d => d.ProcessRiskAsesmntDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntDetailsRange_OrmRbaProcessRiskAsesmntDetails");
        });

        modelBuilder.Entity<OrmRbaProcessRiskAsesmntWork>(entity =>
        {
            entity.ToTable("OrmRbaProcessRiskAsesmntWork");

            entity.Property(e => e.AsesmntDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Asesmnt).WithMany(p => p.OrmRbaProcessRiskAsesmntWorks)
                .HasForeignKey(d => d.AsesmntId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaProcessRiskAsesmntWork_OrmRbaProcessRiskAsesmnt");
        });

        modelBuilder.Entity<OrmRbaRisk>(entity =>
        {
            entity.ToTable("OrmRbaRisk");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_GRC_Accounts");

            entity.HasOne(d => d.InherentRiskScoreNavigation).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.InherentRiskScore)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_OrmInherentRiskScore");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_OrmRiskCategory");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.RiskElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_OrmRiskElements");

            entity.HasOne(d => d.RiskImpact).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.RiskImpactId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_OrmRiskImpact");

            entity.HasOne(d => d.RiskOccurence).WithMany(p => p.OrmRbaRisks)
                .HasForeignKey(d => d.RiskOccurenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRbaRisk_OrmRiskOccurence");
        });

        modelBuilder.Entity<OrmRbacontrolQuestAnswer>(entity =>
        {
            entity.ToTable("OrmRBAControlQuestAnswers");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.QuestionniareId).HasColumnName("questionniareId");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRbacontrolQuestAnswers)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_OrmRBAControlQuestAnswers_GRC_Accounts");

            entity.HasOne(d => d.Answer).WithMany(p => p.OrmRbacontrolQuestAnswers)
                .HasForeignKey(d => d.AnswerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRBAControlQuestAnswers_OrmQuestionnaireAnswers");

            entity.HasOne(d => d.Questionniare).WithMany(p => p.OrmRbacontrolQuestAnswers)
                .HasForeignKey(d => d.QuestionniareId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRBAControlQuestAnswers_OrmQuestionnnaire");

            entity.HasOne(d => d.RiskControl).WithMany(p => p.OrmRbacontrolQuestAnswers)
                .HasForeignKey(d => d.RiskControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRBAControlQuestAnswers_OrmProcessControlLink");
        });

        modelBuilder.Entity<OrmRcsaDueAsesmnt>(entity =>
        {
            entity.ToTable("OrmRcsaDueAsesmnt");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_Division");

            entity.HasOne(d => d.Status).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_OrmTaskStatus");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_OrmRcsaTasks");

            entity.HasOne(d => d.User).WithMany(p => p.OrmRcsaDueAsesmnts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmRcsaDueAsesmnt_GRC_USERS");
        });

        modelBuilder.Entity<OrmRcsaDueAsesmntDetail>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_GRC_Accounts");

            entity.HasOne(d => d.AssessmentStatus).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.AssessmentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmAssessmentStatus");

            entity.HasOne(d => d.ControlEffec).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.ControlEffecId)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmControlDesignEffective");

            entity.HasOne(d => d.DueAsesmnt).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.DueAsesmntId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmRcsaDueAsesmnt");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmProcessDetails");

            entity.HasOne(d => d.ResidualRiskExposure).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.ResidualRiskExposureId)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmResidualRiskExposure");

            entity.HasOne(d => d.RiskOfficerStatus).WithMany(p => p.OrmRcsaDueAsesmntDetails)
                .HasForeignKey(d => d.RiskOfficerStatusId)
                .HasConstraintName("FK_OrmRcsaDueAsesmntDetails_OrmRCSAOfficerStatus");
        });

        modelBuilder.Entity<OrmRcsaDueAsesmntRisk>(entity =>
        {
            entity.ToTable("OrmRcsaDueAsesmntRisk");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaDueAsesmntRisks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntRisk_GRC_Accounts");

            entity.HasOne(d => d.DueAsesmntDetail).WithMany(p => p.OrmRcsaDueAsesmntRisks)
                .HasForeignKey(d => d.DueAsesmntDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntRisk_OrmRcsaDueAsesmntDetails");

            entity.HasOne(d => d.InherentRisk).WithMany(p => p.OrmRcsaDueAsesmntRisks)
                .HasForeignKey(d => d.InherentRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntRisk_OrmInherentRiskScore");

            entity.HasOne(d => d.RiskElement).WithMany(p => p.OrmRcsaDueAsesmntRisks)
                .HasForeignKey(d => d.RiskElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueAsesmntRisk_OrmRiskElements");
        });

        modelBuilder.Entity<OrmRcsaDueTaskRiskControl>(entity =>
        {
            entity.ToTable("OrmRcsaDueTaskRiskControl");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_GRC_Accounts");

            entity.HasOne(d => d.CompChecker).WithMany(p => p.OrmRcsaDueTaskRiskControlCompCheckers)
                .HasForeignKey(d => d.CompCheckerId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_CompCheckerId");

            entity.HasOne(d => d.CompMaker).WithMany(p => p.OrmRcsaDueTaskRiskControlCompMakers)
                .HasForeignKey(d => d.CompMakerId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_CompMaKer");

            entity.HasOne(d => d.ControlDesign).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.ControlDesignId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmControlDesignEffective");

            entity.HasOne(d => d.ControlEffectScoreNavigation).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.ControlEffectScore)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmControlEffectScore");

            entity.HasOne(d => d.DepMaker).WithMany(p => p.OrmRcsaDueTaskRiskControlDepMakers)
                .HasForeignKey(d => d.DepMakerId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_DepMaker");

            entity.HasOne(d => d.Depchecker).WithMany(p => p.OrmRcsaDueTaskRiskControlDepcheckers)
                .HasForeignKey(d => d.DepcheckerId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_Depchecker");

            entity.HasOne(d => d.DueAsesmntRisk).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.DueAsesmntRiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmRcsaDueAsesmntRisk");

            entity.HasOne(d => d.InherentRiskScore).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.InherentRiskScoreId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmInherentRiskScore");

            entity.HasOne(d => d.ResidualRiskScore).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.ResidualRiskScoreId)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmResidualRiskExposure");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmRiskCategory");

            entity.HasOne(d => d.RiskControlElement).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.RiskControlElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaDueTaskRiskControl_OrmRiskControlElements");

            entity.HasOne(d => d.RiskOfficerStatus).WithMany(p => p.OrmRcsaDueTaskRiskControls)
                .HasForeignKey(d => d.RiskOfficerStatusId)
                .HasConstraintName("FK_RiskOfficerStatusId");
        });

        modelBuilder.Entity<OrmRcsaTask>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EffectiveDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.FutureAssessment).HasDefaultValue(true);
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaTasks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTasks_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRcsaTaskBusinessLine>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_GRC_Departments");

            entity.HasOne(d => d.Division).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.DivisionId)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_Division");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_OrmRcsaTasks");

            entity.HasOne(d => d.User).WithMany(p => p.OrmRcsaTaskBusinessLines)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_OrmRcsaTaskBusinessLines_GRC_USERS");
        });

        modelBuilder.Entity<OrmRcsaTaskOfficer>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaTaskOfficers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskOfficers_GRC_Accounts");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmRcsaTaskOfficers)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskOfficers_OrmRcsaTasks");

            entity.HasOne(d => d.User).WithMany(p => p.OrmRcsaTaskOfficers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskOfficers_GRC_USERS");
        });

        modelBuilder.Entity<OrmRcsaTaskTemplate>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaTaskTemplates)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskTemplates_GRC_Accounts");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmRcsaTaskTemplates)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskTemplates_OrmRcsaTasks");

            entity.HasOne(d => d.Template).WithMany(p => p.OrmRcsaTaskTemplates)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRcsaTaskTemplates_OrmTemplates");
        });

        modelBuilder.Entity<OrmRcsaofficerStatus>(entity =>
        {
            entity.ToTable("OrmRCSAOfficerStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsaofficerStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRCSAOfficerStatus_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRcsaquestioniareAnswer>(entity =>
        {
            entity.ToTable("OrmRCSAQuestioniareAnswer");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Answer).WithMany(p => p.OrmRcsaquestioniareAnswers)
                .HasForeignKey(d => d.AnswerId)
                .HasConstraintName("FK_OrmRCSAQuestioniareAnswer_OrmQuestionnaireAnswers");

            entity.HasOne(d => d.DueTaskRiskControl).WithMany(p => p.OrmRcsaquestioniareAnswers)
                .HasForeignKey(d => d.DueTaskRiskControlId)
                .HasConstraintName("FK_DueTaskRiskControlId");

            entity.HasOne(d => d.Question).WithMany(p => p.OrmRcsaquestioniareAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRCSAQuestioniareAnswer_OrmQuestionnnaire");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmRcsaquestioniareAnswers)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_OrmRCSAQuestioniareAnswer_OrmRcsaTasks");
        });

        modelBuilder.Entity<OrmRcsataskRiskControlAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrmRCSAT__3214EC07B7A3C311");

            entity.ToTable("OrmRCSATaskRiskControlAttachment");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRcsataskRiskControlAttachments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_OrmRCSATaskRiskControlAttachment");

            entity.HasOne(d => d.TaskRiskControl).WithMany(p => p.OrmRcsataskRiskControlAttachments)
                .HasForeignKey(d => d.TaskRiskControlId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TaskRiskControlId_OrmRcsaDueTaskRiskControl");
        });

        modelBuilder.Entity<OrmResidualRiskExposure>(entity =>
        {
            entity.ToTable("OrmResidualRiskExposure");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmResidualRiskExposures)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmResidualRiskExposure_OrmResidualRiskExposure");
        });

        modelBuilder.Entity<OrmResidualRiskQuadrant>(entity =>
        {
            entity.ToTable("OrmResidualRiskQuadrant");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmResidualRiskQuadrants)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmResidualRiskQuadrant_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRiskCategory>(entity =>
        {
            entity.ToTable("OrmRiskCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskCategory_GRC_Accounts");

            entity.HasOne(d => d.Category).WithMany(p => p.OrmRiskCategories)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskCategory_OrmCategory");
        });

        modelBuilder.Entity<OrmRiskClassification>(entity =>
        {
            entity.ToTable("OrmRiskClassification");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Acconut).WithMany(p => p.OrmRiskClassifications)
                .HasForeignKey(d => d.AcconutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskClassification_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRiskControlCategory>(entity =>
        {
            entity.ToTable("OrmRiskControlCategory");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskControlCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskControlCategory_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRiskControlElement>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskControlElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskControlElements_GRC_Accounts");

            entity.HasOne(d => d.ControlCategory).WithMany(p => p.OrmRiskControlElements)
                .HasForeignKey(d => d.ControlCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskControlElements_OrmRiskControlCategory");
        });

        modelBuilder.Entity<OrmRiskElement>(entity =>
        {
            entity.Property(e => e.Code).HasMaxLength(20);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskElements_GRC_Accounts");

            entity.HasOne(d => d.OperationalGoals).WithMany(p => p.OrmRiskElements)
                .HasForeignKey(d => d.OperationalGoalsId)
                .HasConstraintName("FK_OrmRiskElements_StrategicPrograms");

            entity.HasOne(d => d.RiskCategory).WithMany(p => p.OrmRiskElements)
                .HasForeignKey(d => d.RiskCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskElements_OrmRiskCategory");
        });

        modelBuilder.Entity<OrmRiskImpact>(entity =>
        {
            entity.ToTable("OrmRiskImpact");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskImpacts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskImpact_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRiskOccurence>(entity =>
        {
            entity.ToTable("OrmRiskOccurence");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRiskOccurences)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRiskOccurence_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRole>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRoles_GRC_Accounts");
        });

        modelBuilder.Entity<OrmRoleUser>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.OrmRoleUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRoleUsers_OrmRoles");

            entity.HasOne(d => d.User).WithMany(p => p.OrmRoleUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmRoleUsers_GRC_USERS");
        });

        modelBuilder.Entity<OrmSource>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrmSourc__3214EC079FEB34A9");

            entity.ToTable("OrmSource");

            entity.HasIndex(e => e.Code, "UQ__OrmSourc__A25C5AA779F87809").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmSources)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_OrmSoure");
        });

        modelBuilder.Entity<OrmTaskStatus>(entity =>
        {
            entity.ToTable("OrmTaskStatus");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmTaskStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmTaskStatus_GRC_Accounts");
        });

        modelBuilder.Entity<OrmTasksCalendar>(entity =>
        {
            entity.ToTable("OrmTasksCalendar");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Kri).WithMany(p => p.OrmTasksCalendars)
                .HasForeignKey(d => d.KriId)
                .HasConstraintName("FK_OrmTasksCalendar_OrmKri");

            entity.HasOne(d => d.Task).WithMany(p => p.OrmTasksCalendars)
                .HasForeignKey(d => d.TaskId)
                .HasConstraintName("FK_OrmTasksCalendar_OrmRcsaTasks");
        });

        modelBuilder.Entity<OrmTemplate>(entity =>
        {
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmTemplates)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmTemplates_GRC_Accounts");
        });

        modelBuilder.Entity<OrmTemplateProcess>(entity =>
        {
            entity.ToTable("OrmTemplateProcess");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmTemplateProcesses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmTemplateProcess_GRC_Accounts");

            entity.HasOne(d => d.ProcessDetail).WithMany(p => p.OrmTemplateProcesses)
                .HasForeignKey(d => d.ProcessDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmTemplateProcess_OrmProcessDetails");

            entity.HasOne(d => d.Template).WithMany(p => p.OrmTemplateProcesses)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrmTemplateProcess_OrmTemplates");
        });

        modelBuilder.Entity<OrmmapTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ORMMapAuditTables");

            entity.ToTable("ORMMapTables");

            entity.Property(e => e.BusinessTableName).HasMaxLength(255);
            entity.Property(e => e.TableName).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.OrmmapTables)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditMapAuditTables_GRC_Accounts");
        });

        modelBuilder.Entity<OrmraCategory>(entity =>
        {
            entity.ToTable("ORMRaCategory");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<OrmraClassification>(entity =>
        {
            entity.ToTable("ORMRaClassification");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
        });

        modelBuilder.Entity<OrmraElement>(entity =>
        {
            entity.ToTable("ORMRaElements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.RaCategory).WithMany(p => p.OrmraElements)
                .HasForeignKey(d => d.RaCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRaElements_ORMRaCategory");
        });

        modelBuilder.Entity<OrmraElementDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RaElementDetails");

            entity.ToTable("ORMRaElementDetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsFixedLength();

            entity.HasOne(d => d.RaElement).WithMany(p => p.OrmraElementDetails)
                .HasForeignKey(d => d.RaElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRaElementDetails_ORMRaElements");
        });

        modelBuilder.Entity<OrmraElementDetailRange>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ORMRaDetailRanges");

            entity.ToTable("ORMRaElementDetailRanges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<OrmraElementRange>(entity =>
        {
            entity.ToTable("ORMRaElementRanges");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CeationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.RaElement).WithMany(p => p.OrmraElementRanges)
                .HasForeignKey(d => d.RaElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRaElementRangesORMRaElements");
        });

        modelBuilder.Entity<OrmrbaRiskDetail>(entity =>
        {
            entity.ToTable("ORMRbaRiskDetails");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DetailScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ElementScore).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AsesmntElementDetail).WithMany(p => p.OrmrbaRiskDetails)
                .HasForeignKey(d => d.AsesmntElementDetailId)
                .HasConstraintName("FK_ORMRbaRiskDetails_ORMRaElementDetails");

            entity.HasOne(d => d.AsesmntElement).WithMany(p => p.OrmrbaRiskDetails)
                .HasForeignKey(d => d.AsesmntElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRbaRiskDetails_ORMRaElements");

            entity.HasOne(d => d.AsesmntWork).WithMany(p => p.OrmrbaRiskDetails)
                .HasForeignKey(d => d.AsesmntWorkId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRbaRiskDetails_ORMRbaRiskWork");

            entity.HasOne(d => d.ElementRange).WithMany(p => p.OrmrbaRiskDetails)
                .HasForeignKey(d => d.ElementRangeId)
                .HasConstraintName("FK_ORMRbaRiskDetails_ORMRaElementRanges");
        });

        modelBuilder.Entity<OrmrbaRiskDetailsRange>(entity =>
        {
            entity.ToTable("ORMRbaRiskDetailsRange");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.OrmrbaRiskDetailsId).HasColumnName("ORMRbaRiskDetailsId");

            entity.HasOne(d => d.DetailsRange).WithMany(p => p.OrmrbaRiskDetailsRanges)
                .HasForeignKey(d => d.DetailsRangeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRbaRiskDetailsRange_ORMRaElementDetailRanges");

            entity.HasOne(d => d.OrmrbaRiskDetails).WithMany(p => p.OrmrbaRiskDetailsRanges)
                .HasForeignKey(d => d.OrmrbaRiskDetailsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRbaRiskDetailsRange_ORMRbaRiskDetails");
        });

        modelBuilder.Entity<OrmrbaRiskWork>(entity =>
        {
            entity.ToTable("ORMRbaRiskWork");

            entity.Property(e => e.AsesmntDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("lastUpdateDate");

            entity.HasOne(d => d.Risk).WithMany(p => p.OrmrbaRiskWorks)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMRbaRiskWork_OrmRbaRisk");
        });

        modelBuilder.Entity<OrmriskGoal>(entity =>
        {
            entity.ToTable("ORMRiskGoals");

            entity.Property(e => e.CreationDate)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<OrmuserActivitiesLog>(entity =>
        {
            entity.ToTable("ORMUserActivitiesLog");

            entity.Property(e => e.ActivityDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.OrmuserActivitiesLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORmUserActivitiesLog_GRC_Accounts");

            entity.HasOne(d => d.User).WithMany(p => p.OrmuserActivitiesLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMUserActivitiesLog_GRC_USERS");
        });

        modelBuilder.Entity<OrmuserAuditLog>(entity =>
        {
            entity.ToTable("ORMUserAuditLog");

            entity.Property(e => e.LogDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LogInId).HasColumnName("LogInID");
            entity.Property(e => e.SessionId).HasMaxLength(255);

            entity.HasOne(d => d.Account).WithMany(p => p.OrmuserAuditLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMUserAuditLog_GRC_Accounts");

            entity.HasOne(d => d.User).WithMany(p => p.OrmuserAuditLogs)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ORMUserAuditLog_GRC_USERS");
        });

        modelBuilder.Entity<OrmuserManagementLog>(entity =>
        {
            entity.ToTable("ORMUserManagementLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorityNew).HasMaxLength(250);
            entity.Property(e => e.AuthorityOld).HasMaxLength(250);
            entity.Property(e => e.DefaultActionUserNew).HasColumnName("default_action_userNew");
            entity.Property(e => e.DefaultActionUserOld).HasColumnName("default_action_userOld");
            entity.Property(e => e.RoleNameNew).HasMaxLength(250);
            entity.Property(e => e.RoleNameOld).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.OrmuserManagementLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditUserManagementLog_GRC_Accounts");

            entity.HasOne(d => d.ActivityLog).WithMany(p => p.OrmuserManagementLogs)
                .HasForeignKey(d => d.ActivityLogId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuditUserManagementLog_AuditUserActivitiesLog");
        });

        modelBuilder.Entity<PasswordPolicy>(entity =>
        {
            entity.ToTable("PasswordPolicy");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.HasOne(d => d.Account).WithMany(p => p.PasswordPolicies)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_PasswordPolicy_GRC_Accounts");
        });

        modelBuilder.Entity<Policy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Policy__3214EC07929FAF08");

            entity.ToTable("Policy");

            entity.HasIndex(e => e.AccountId, "PolicyAccountIdIndex");

            entity.HasIndex(e => e.PolicyOwnerId, "PolicyPolicyOwnerIdIndex");

            entity.HasIndex(e => e.PolicyStatusId, "PolicyPolicyStatusIdIndex");

            entity.HasIndex(e => e.InitiatedUserId, "PolicyReviewInitiatedUserIdIndex");

            entity.HasIndex(e => e.Id, "PolicydIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Policies)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_Policy");

            entity.HasOne(d => d.InitiatedUser).WithMany(p => p.PolicyInitiatedUsers)
                .HasForeignKey(d => d.InitiatedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_Policy");

            entity.HasOne(d => d.PolicyOwner).WithMany(p => p.PolicyPolicyOwners)
                .HasForeignKey(d => d.PolicyOwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS__Owner_Policy");

            entity.HasOne(d => d.PolicyStatus).WithMany(p => p.Policies)
                .HasForeignKey(d => d.PolicyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyStatus_Policy");
        });

        modelBuilder.Entity<PolicyApprovalStage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyAp__3214EC0700DF8031");

            entity.HasIndex(e => e.AccountId, "PolicyApprovalStagesAccountIdIndex");

            entity.HasIndex(e => e.Id, "PolicyApprovalStagesIdIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyApprovalStagesPolicyIdIndex");

            entity.HasIndex(e => e.UserId, "PolicyApprovalStagesUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyApprovalStages)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyApprovalStages");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyApprovalStages)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyApprovalStages_Policy");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyApprovalStages)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_PolicyApprovalStages");
        });

        modelBuilder.Entity<PolicyDeveloper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyDe__3214EC07230F44D2");

            entity.HasIndex(e => e.AccountId, "PolicyDevelopersAccountIdIndex");

            entity.HasIndex(e => e.Id, "PolicyDevelopersIDIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyDevelopersPolicyIdIndex");

            entity.HasIndex(e => e.UserId, "PolicyDevelopersUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyDevelopers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyDeveloper");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyDevelopers)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_PolicyId");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyDevelopers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_PolicyDevelopers");
        });

        modelBuilder.Entity<PolicyFile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyFi__3214EC078DE5E366");

            entity.ToTable("PolicyFile");

            entity.HasIndex(e => e.Id, "PolicyFileIdIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyFilePolicyIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyFiles)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_PolicyFile");
        });

        modelBuilder.Entity<PolicyFollowUpReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyFo__3214EC07AC802DEA");

            entity.HasIndex(e => e.PolicyReviewId, "PPolicyFollowUpReviewsPolicyreviewIdIndex");

            entity.HasIndex(e => e.Id, "PolicyFollowUpReviewsIdIndex");

            entity.HasIndex(e => e.ReviewUserId, "PolicyFollowUpReviewsReviewUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.PolicyReview).WithMany(p => p.PolicyFollowUpReviews)
                .HasForeignKey(d => d.PolicyReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyFollowUpReviews_PolicyReview");

            entity.HasOne(d => d.ReviewUser).WithMany(p => p.PolicyFollowUpReviews)
                .HasForeignKey(d => d.ReviewUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyFollowUpReviews_grc_users");
        });

        modelBuilder.Entity<PolicyMgmRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyMg__3214EC07314D10A6");

            entity.ToTable("PolicyMgmRole");

            entity.HasIndex(e => e.AccountId, "PolicyMgmRoleAccountIdIndex");

            entity.HasIndex(e => e.Code, "PolicyMgmRoleCodeIndex");

            entity.HasIndex(e => e.Id, "PolicyMgmRoleIdIndex");

            entity.HasIndex(e => new { e.Id, e.AccountId, e.Code }, "PolicyMgmRoleIndex");

            entity.HasIndex(e => e.Code, "UQ__PolicyMg__A25C5AA71D3C527B").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__PolicyMg__A25C5AA7EB7341A7").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyMgmRoles)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId");
        });

        modelBuilder.Entity<PolicyMgmtUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyMg__3214EC0728028D66");

            entity.HasIndex(e => e.AccountId, "PolicyMgmtUsersAccountIdIndex");

            entity.HasIndex(e => e.Id, "PolicyMgmtUsersIdIndex");

            entity.HasIndex(e => e.InitiatedUserId, "PolicyMgmtUsersInitiatedUserIdIndex");

            entity.HasIndex(e => e.RoleId, "PolicyMgmtUsersRoleIdIndex");

            entity.HasIndex(e => e.UserId, "PolicyMgmtUsersUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyMgmtUsers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyMgmtUsers");

            entity.HasOne(d => d.InitiatedUser).WithMany(p => p.PolicyMgmtUserInitiatedUsers)
                .HasForeignKey(d => d.InitiatedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS2");

            entity.HasOne(d => d.Role).WithMany(p => p.PolicyMgmtUsers)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyMgmtRole");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyMgmtUserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS");
        });

        modelBuilder.Entity<PolicyReader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyRe__3214EC07BBA13694");

            entity.HasIndex(e => e.AccountId, "PolicyReadersAccountIdIndex");

            entity.HasIndex(e => e.DepartmentId, "PolicyReadersDepartmentIdIndex");

            entity.HasIndex(e => e.Id, "PolicyReadersIdIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyReadersPolicyIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyReaders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyReaders");

            entity.HasOne(d => d.Department).WithMany(p => p.PolicyReaders)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_DEPARTMENTS_PolicyReaders");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyReaders)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_Readers");
        });

        modelBuilder.Entity<PolicyRejectReasonLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyRe__3214EC0701378ABD");

            entity.ToTable("PolicyRejectReasonLog");

            entity.HasIndex(e => e.Id, "PolicyRejectReasonLogIdIndex");

            entity.HasIndex(e => e.PolicyReviewId, "PolicyRejectReasonLogPolicyreviewIdIndex");

            entity.HasIndex(e => e.RejectUserId, "PolicyRejectReasonLogRejectUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.PolicyReview).WithMany(p => p.PolicyRejectReasonLogs)
                .HasForeignKey(d => d.PolicyReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyReview_Rejectreason");

            entity.HasOne(d => d.RejectUser).WithMany(p => p.PolicyRejectReasonLogs)
                .HasForeignKey(d => d.RejectUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_grc_users_Rejectreason");
        });

        modelBuilder.Entity<PolicyReview>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyRe__3214EC07F0CA3B2A");

            entity.ToTable("PolicyReview");

            entity.HasIndex(e => e.AccountId, "PolicyReviewAccountIdIndex");

            entity.HasIndex(e => e.Id, "PolicyReviewIdIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyReviewPolicyIdIndex");

            entity.HasIndex(e => e.PolicyStatusId, "PolicyReviewPolicyStatusIdIndex");

            entity.HasIndex(e => e.UserId, "PolicyReviewUserIdIndex");

            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.PolicyVersion).HasMaxLength(500);
            entity.Property(e => e.PublishDate).HasColumnType("datetime");
            entity.Property(e => e.RetireDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyReviews)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyReview");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyReviews)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyReview_Policy");

            entity.HasOne(d => d.PolicyStatus).WithMany(p => p.PolicyReviews)
                .HasForeignKey(d => d.PolicyStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PolicyStatus_PolicyReview");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_PolicyReview");
        });

        modelBuilder.Entity<PolicyReviewer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyRe__3214EC0772DD7E1D");

            entity.HasIndex(e => e.AccountId, "PolicyReviewersAccountIdIndex");

            entity.HasIndex(e => e.Id, "PolicyReviewersIdIndex");

            entity.HasIndex(e => e.PolicyId, "PolicyReviewersPolicyIdIndex");

            entity.HasIndex(e => e.UserId, "PolicyReviewersUserIdIndex");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyReviewers)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyReviewers");

            entity.HasOne(d => d.Policy).WithMany(p => p.PolicyReviewers)
                .HasForeignKey(d => d.PolicyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Policy_Reviewers");

            entity.HasOne(d => d.User).WithMany(p => p.PolicyReviewers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GRC_USERS_PolicyReviewers");
        });

        modelBuilder.Entity<PolicyStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicySt__3214EC0799470607");

            entity.ToTable("PolicyStatus");

            entity.HasIndex(e => e.AccountId, "PolicyStatusAccountIdIndex");

            entity.HasIndex(e => e.Code, "PolicyStatusCodeIndex");

            entity.HasIndex(e => e.Id, "PolicyStatusIdIndex");

            entity.HasIndex(e => new { e.Id, e.AccountId, e.Code }, "PolicyStatusIndex");

            entity.HasIndex(e => e.Code, "UQ__PolicySt__A25C5AA7826C6760").IsUnique();

            entity.HasIndex(e => e.Code, "UQ__PolicySt__A25C5AA7C20C26A2").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_AccountId_PolicyStatus");
        });

        modelBuilder.Entity<PolicyType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PolicyTy__3214EC07C1CC6373");

            entity.ToTable("PolicyType");

            entity.HasIndex(e => new { e.Id, e.AccountId, e.Code }, "PolicyTypeIndex");

            entity.HasIndex(e => e.Code, "UQ__PolicyTy__A25C5AA72271A5B3").IsUnique();

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.PolicyTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AccountId_PolicyType");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.HasIndex(e => e.Id, "IX_Product").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_Product_GRC_Accounts");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Products)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_GRC_Accounts");
        });

        modelBuilder.Entity<ProductAssessmentDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.IndicatorReference).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssessmentHeader).WithMany(p => p.ProductAssessmentDetails)
                .HasForeignKey(d => d.AssessmentHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentDetails_ProductAssessmentHeader");

            entity.HasOne(d => d.Evaluation).WithMany(p => p.ProductAssessmentDetails)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentDetails_ProductClassification");

            entity.HasOne(d => d.Indicator).WithMany(p => p.ProductAssessmentDetails)
                .HasForeignKey(d => d.IndicatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentDetails_ProductCategoryIndicator");
        });

        modelBuilder.Entity<ProductAssessmentHeader>(entity =>
        {
            entity.ToTable("ProductAssessmentHeader");

            entity.HasIndex(e => e.AccountId, "IX_ProductAssessmentHeader_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentDate).HasColumnType("datetime");
            entity.Property(e => e.ChanceOfDefect).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ProductRiskAssessment).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.ProductAssessmentHeaders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentHeader_GRC_Accounts");

            entity.HasOne(d => d.DamageSeverity).WithMany(p => p.ProductAssessmentHeaderDamageSeverities)
                .HasForeignKey(d => d.DamageSeverityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentHeader_ProductDamageSeverity");

            entity.HasOne(d => d.FreqOfUse).WithMany(p => p.ProductAssessmentHeaderFreqOfUses)
                .HasForeignKey(d => d.FreqOfUseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentHeader_ProductFrequencyOfUse");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAssessmentHeaders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductAssessmentHeader_Product");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.ToTable("ProductCategory");

            entity.HasIndex(e => e.AccountId, "IX_ProductCategory_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.ProductCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategory_GRC_Accounts");
        });

        modelBuilder.Entity<ProductCategoryIndicator>(entity =>
        {
            entity.ToTable("ProductCategoryIndicator");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.ProductCategoryIndicators)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductCategoryIndicator_ProductCategory");
        });

        modelBuilder.Entity<ProductClassification>(entity =>
        {
            entity.ToTable("ProductClassification");

            entity.HasIndex(e => e.AccountId, "IX_ProductClassification_GRC_Accounts");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ShortDesc).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.ProductClassifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductClassification_GRC_Accounts");
        });

        modelBuilder.Entity<ProductIndicatorLink>(entity =>
        {
            entity.ToTable("ProductIndicatorLink");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Indicator).WithMany(p => p.ProductIndicatorLinks)
                .HasForeignKey(d => d.IndicatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductIndicatorLink_ProductCategoryIndicator");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductIndicatorLinks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductIndicatorLink_Product");
        });

        modelBuilder.Entity<RcamAdvisoryActionAttachment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AdvisoryAction).WithMany(p => p.RcamAdvisoryActionAttachments)
                .HasForeignKey(d => d.AdvisoryActionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryActionAttachments_RcamAdvisoryRequestAction");
        });

        modelBuilder.Entity<RcamAdvisoryCategory>(entity =>
        {
            entity.ToTable("RcamAdvisoryCategory");

            entity.HasIndex(e => e.Code, "IX_RcamAdvisoryCategory").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_RcamAdvisoryCategory_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Sla).HasColumnName("SLA");

            entity.HasOne(d => d.Account).WithMany(p => p.RcamAdvisoryCategories)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryCategory_GRC_Accounts");
        });

        modelBuilder.Entity<RcamAdvisoryPriority>(entity =>
        {
            entity.ToTable("RcamAdvisoryPriority");

            entity.HasIndex(e => e.Code, "IX_RcamAdvisoryPriority").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_RcamAdvisoryPriority_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcamAdvisoryPriorities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryPriority_GRC_Accounts");
        });

        modelBuilder.Entity<RcamAdvisoryRequest>(entity =>
        {
            entity.ToTable("RcamAdvisoryRequest");

            entity.HasIndex(e => e.AccountId, "IX_RcamAdvisoryRequest_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ResolveDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequest_GRC_Accounts");

            entity.HasOne(d => d.AdvisoryCategory).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.AdvisoryCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequest_RcamAdvisoryCategory");

            entity.HasOne(d => d.AdvisoryPriority).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.AdvisoryPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequest_RcamAdvisoryPriority");

            entity.HasOne(d => d.AdvisoryStatus).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.AdvisoryStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequest_RcamAdvisoryStatus");

            entity.HasOne(d => d.AdvisoryType).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.AdvisoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequest_RcamAdvisoryType");

            entity.HasOne(d => d.ExternalInitiatedByNavigation).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.ExternalInitiatedBy)
                .HasConstraintName("FK__RcamAdvis__Exter__4850AF91");

            entity.HasOne(d => d.InitiatedByUser).WithMany(p => p.RcamAdvisoryRequests)
                .HasForeignKey(d => d.InitiatedByUserId)
                .HasConstraintName("FK_RcamAdvisoryRequest_GRC_USERS");
        });

        modelBuilder.Entity<RcamAdvisoryRequestAction>(entity =>
        {
            entity.ToTable("RcamAdvisoryRequestAction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AdvisoryRequest).WithMany(p => p.RcamAdvisoryRequestActions)
                .HasForeignKey(d => d.AdvisoryRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestAction_RcamAdvisoryRequest");

            entity.HasOne(d => d.AdvisoryStatus).WithMany(p => p.RcamAdvisoryRequestActions)
                .HasForeignKey(d => d.AdvisoryStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestAction_RcamAdvisoryStatus");

            entity.HasOne(d => d.User).WithMany(p => p.RcamAdvisoryRequestActions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestAction_GRC_USERS");
        });

        modelBuilder.Entity<RcamAdvisoryRequestAttachment>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AdvisoryRequest).WithMany(p => p.RcamAdvisoryRequestAttachments)
                .HasForeignKey(d => d.AdvisoryRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestAttachments_RcamAdvisoryRequest");
        });

        modelBuilder.Entity<RcamAdvisoryRequestSubRequlation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RcamAdvisoryRequestArticles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AdvisoryRequest).WithMany(p => p.RcamAdvisoryRequestSubRequlations)
                .HasForeignKey(d => d.AdvisoryRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestArticles_RcamAdvisoryRequest");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.RcamAdvisoryRequestSubRequlations)
                .HasForeignKey(d => d.SubRegulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestArticles_GRC_Sub_Regulations");
        });

        modelBuilder.Entity<RcamAdvisoryRequestUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RcamAdvisoryRequestPosition");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDatw).HasColumnType("datetime");

            entity.HasOne(d => d.AdvisoryRequest).WithMany(p => p.RcamAdvisoryRequestUsers)
                .HasForeignKey(d => d.AdvisoryRequestId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestUsers_RcamAdvisoryRequest");

            entity.HasOne(d => d.User).WithMany(p => p.RcamAdvisoryRequestUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryRequestUsers_GRC_USERS");
        });

        modelBuilder.Entity<RcamAdvisoryStatus>(entity =>
        {
            entity.ToTable("RcamAdvisoryStatus");

            entity.HasIndex(e => e.Code, "IX_RcamAdvisoryStatus").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_RcamAdvisoryStatus_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcamAdvisoryStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryStatus_GRC_Accounts");
        });

        modelBuilder.Entity<RcamAdvisoryType>(entity =>
        {
            entity.ToTable("RcamAdvisoryType");

            entity.HasIndex(e => e.AccountId, "IX_RcamAdvisoryType");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcamAdvisoryTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcamAdvisoryType_GRC_Accounts");
        });

        modelBuilder.Entity<RccmAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_rccmAttacments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");
        });

        modelBuilder.Entity<RccmChangeManagement>(entity =>
        {
            entity.ToTable("RccmChangeManagement");

            entity.HasIndex(e => e.AccountId, "IX_RccmChangeManagement_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CmReference).HasMaxLength(50);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DateClosed).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Others).HasMaxLength(400);

            entity.HasOne(d => d.Account).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmChangeManagement_GRC_Accounts");

            entity.HasOne(d => d.BusinessUnit).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.BusinessUnitId)
                .HasConstraintName("FK_RccmChangeManagement_GRC_ControlBusinessUnit");

            entity.HasOne(d => d.CmPriority).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.CmPriorityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmChangeManagement_RccmCmPriority");

            entity.HasOne(d => d.CmStatus).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.CmStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmChangeManagement_RccmCmStatus");

            entity.HasOne(d => d.CmType).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.CmTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmChangeManagement_RccmCmType");

            entity.HasOne(d => d.InitiatedByUser).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.InitiatedByUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmChangeManagement_GRC_USERS");

            entity.HasOne(d => d.Letter).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.LetterId)
                .HasConstraintName("FK_RccmChangeManagement_CorresLetters");

            entity.HasOne(d => d.Product).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_RccmChangeManagement_Product");

            entity.HasOne(d => d.Regulation).WithMany(p => p.RccmChangeManagements)
                .HasForeignKey(d => d.RegulationId)
                .HasConstraintName("FK_RccmChangeManagement_GRC_Regulations");
        });

        modelBuilder.Entity<RccmCmPriority>(entity =>
        {
            entity.ToTable("RccmCmPriority");

            entity.HasIndex(e => e.AccountId, "IX_RccmCmPriority_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.LastUpdateDatre).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RccmCmPriorities)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmPriority_GRC_Accounts");
        });

        modelBuilder.Entity<RccmCmStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RccmChangeManagementStatus");

            entity.ToTable("RccmCmStatus");

            entity.HasIndex(e => e.AccountId, "IX_RccmCmStatus_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RccmCmStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmStatus_GRC_Accounts");
        });

        modelBuilder.Entity<RccmCmTask>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_RccmCmTasks_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.DueDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TaskRef).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.RccmCmTasks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmTasks_GRC_Accounts");

            entity.HasOne(d => d.ChangeManagemenr).WithMany(p => p.RccmCmTasks)
                .HasForeignKey(d => d.ChangeManagemenrId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmTasks_RccmChangeManagement");

            entity.HasOne(d => d.Status).WithMany(p => p.RccmCmTasks)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__RccmCmTas__Statu__392477BB");
        });

        modelBuilder.Entity<RccmCmTaskDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RccmCmTaskSubject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Function).WithMany(p => p.RccmCmTaskDetails)
                .HasForeignKey(d => d.FunctionId)
                .HasConstraintName("FK_RccmCmTaskSubject_GRC_BusinessUnitFunction");

            entity.HasOne(d => d.SubProduct).WithMany(p => p.RccmCmTaskDetails)
                .HasForeignKey(d => d.SubProductId)
                .HasConstraintName("FK_RccmCmTaskSubject_SubProduct");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.RccmCmTaskDetails)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_RccmCmTaskSubject_GRC_Sub_Regulations");

            entity.HasOne(d => d.Task).WithMany(p => p.RccmCmTaskDetails)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmTaskSubject_RccmCmTasks");
        });

        modelBuilder.Entity<RccmCmTaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RccmTaskStatus");

            entity.ToTable("RccmCmTaskStatus");

            entity.HasIndex(e => e.AccountId, "IX_RccmCmTaskStatus_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RccmCmTaskStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmTaskStatus_GRC_Accounts");
        });

        modelBuilder.Entity<RccmCmType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RccmChangeType");

            entity.ToTable("RccmCmType");

            entity.HasIndex(e => e.AccountId, "IX_RccmCmType_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TypeCode).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.RccmCmTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmCmType_GRC_Accounts");
        });

        modelBuilder.Entity<RccmTaskUser>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedate).HasColumnType("datetime");

            entity.HasOne(d => d.ApproveUser).WithMany(p => p.RccmTaskUserApproveUsers)
                .HasForeignKey(d => d.ApproveUserId)
                .HasConstraintName("FK_RccmTaskUsers_GRC_USERS1");

            entity.HasOne(d => d.Status).WithMany(p => p.RccmTaskUsers)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmTaskUsers_RccmTCmTaskStatus");

            entity.HasOne(d => d.Task).WithMany(p => p.RccmTaskUsers)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmTaskUsers_RccmCmTasks");

            entity.HasOne(d => d.User).WithMany(p => p.RccmTaskUserUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmTaskUsers_GRC_USERS");
        });

        modelBuilder.Entity<RccmTaskUserAction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RccmTaskUserAction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ActionUserId).HasColumnName("ActionUserID");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.ExpectedResolvedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ResolvedDate).HasColumnType("datetime");

            entity.HasOne(d => d.ApprovedByUser).WithMany(p => p.RccmTaskUserActions)
                .HasForeignKey(d => d.ApprovedByUserId)
                .HasConstraintName("FK_RccmTaskUserAction_GRC_USERS");

            entity.HasOne(d => d.Status).WithMany(p => p.RccmTaskUserActions)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmTaskUserAction_RccmTCmTaskStatus");

            entity.HasOne(d => d.TaskUser).WithMany(p => p.RccmTaskUserActions)
                .HasForeignKey(d => d.TaskUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RccmTaskUserAction_RccmTaskUsers");
        });

        modelBuilder.Entity<RcmaAssessmentElementDetail>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnswerDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssessmentElementHeader).WithMany(p => p.RcmaAssessmentElementDetails)
                .HasForeignKey(d => d.AssessmentElementHeaderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAssessmentElementDetails_RcmaAssessmentElementHeaders");

            entity.HasOne(d => d.Comply).WithMany(p => p.RcmaAssessmentElementDetails)
                .HasForeignKey(d => d.ComplyId)
                .HasConstraintName("FK_RcmaAssessmentElementDetailsComplyId");

            entity.HasOne(d => d.Element).WithMany(p => p.RcmaAssessmentElementDetails)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAssessmentElementDetailsElementId");
        });

        modelBuilder.Entity<RcmaAssessmentElementHeader>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_RcmaAssessmentElementHeaders_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedate).HasColumnType("datetime");
            entity.Property(e => e.Score).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaAssessmentElementHeaders)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAssessmentElementHeaders_GRC_Accounts");

            entity.HasOne(d => d.ExternalUser).WithMany(p => p.RcmaAssessmentElementHeaders)
                .HasForeignKey(d => d.ExternalUserId)
                .HasConstraintName("FK_ExternalUserIdRcmaAssessmentElementHeaders");

            entity.HasOne(d => d.Status).WithMany(p => p.RcmaAssessmentElementHeaders)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAssessmentElementHeaders_RcmaStatus1");

            entity.HasOne(d => d.Task).WithMany(p => p.RcmaAssessmentElementHeaders)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAssessmentElementHeaders_RcmaTasks");

            entity.HasOne(d => d.User).WithMany(p => p.RcmaAssessmentElementHeaders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_RcmaAssessmentElementHeaders_GRC_USERS");
        });

        modelBuilder.Entity<RcmaAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RcmaAttacments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentElementDetailId).HasColumnName("AssessmentElementDetailID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.AssessmentElementDetail).WithMany(p => p.RcmaAttachments)
                .HasForeignKey(d => d.AssessmentElementDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaAttachments_RcmaAssessmentElementDetails");
        });

        modelBuilder.Entity<RcmaCalendarTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RcmaCalendarTaskUsers");

            entity.HasIndex(e => e.AccountId, "IX_RcmaCalendarTasks_id_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CalendarEndDate).HasColumnType("datetime");
            entity.Property(e => e.CalendarStartDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaCalendarTasks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaCalendarTasks_GRC_Accounts");

            entity.HasOne(d => d.Task).WithMany(p => p.RcmaCalendarTasks)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaCalendarUsers_RcmaTasks");
        });

        modelBuilder.Entity<RcmaDepartmentTaskScore>(entity =>
        {
            entity.ToTable("RcmaDepartmentTaskScore");

            entity.HasIndex(e => e.AccountId, "IX_RcmaDepartmentTaskScore_GRC_Accounts");

            entity.HasIndex(e => e.AccountId, "IX_RcmaElements_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CompleteDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaDepartmentTaskScores)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaDepartmentTaskScore_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.RcmaDepartmentTaskScores)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaDepartmentTaskScore.departmentId");

            entity.HasOne(d => d.Task).WithMany(p => p.RcmaDepartmentTaskScores)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaDepartmentTaskScore_RcmaTasks");
        });

        modelBuilder.Entity<RcmaElement>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaElements)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaElements_GRC_Accounts");

            entity.HasOne(d => d.Principle).WithMany(p => p.RcmaElements)
                .HasForeignKey(d => d.PrincipleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaElementsPrinciples");
        });

        modelBuilder.Entity<RcmaMaturityCode>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_RcmaMaturityCodes_GRC_Accounts");

            entity.HasIndex(e => e.AccountId, "IX_RcmaPrinciples_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Color).HasMaxLength(200);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.MaturityCode).HasMaxLength(10);

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaMaturityCodes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaMaturityCodes_GRC_Accounts");
        });

        modelBuilder.Entity<RcmaPrinciple>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaPrinciples)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaPrinciples_GRC_Accounts");

            entity.HasOne(d => d.PrincipleType).WithMany(p => p.RcmaPrinciples)
                .HasForeignKey(d => d.PrincipleTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaPrinciples_RcmaPrincipleTypes");
        });

        modelBuilder.Entity<RcmaPrincipleType>(entity =>
        {
            entity.HasIndex(e => e.Type, "IX_RcmaPrincipleTypes").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_RcmaPrincipleTypes_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaPrincipleTypes)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaPrincipleTypes_GRC_Accounts");
        });

        modelBuilder.Entity<RcmaStatus>(entity =>
        {
            entity.ToTable("RcmaStatus");

            entity.HasIndex(e => e.AccountId, "IX_RcmaStatus_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaStatuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaStatus_GRC_Accounts");
        });

        modelBuilder.Entity<RcmaTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RcmaTasks_1");

            entity.HasIndex(e => e.AccountId, "IX_RcmaTasks_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaTasks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTasks_GRC_Accounts");
        });

        modelBuilder.Entity<RcmaTaskUserTemplate>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference).HasMaxLength(50);

            entity.HasOne(d => d.Department).WithMany(p => p.RcmaTaskUserTemplates)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_RcmaTaskUserTemplates_GRC_Departments");

            entity.HasOne(d => d.ExternalUser).WithMany(p => p.RcmaTaskUserTemplates)
                .HasForeignKey(d => d.ExternalUserId)
                .HasConstraintName("FK_ExternalUserId");

            entity.HasOne(d => d.Task).WithMany(p => p.RcmaTaskUserTemplates)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTaskUserTemplates_RcmaTasks");

            entity.HasOne(d => d.Template).WithMany(p => p.RcmaTaskUserTemplates)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTaskUserTemplates_RcmaTemplates");

            entity.HasOne(d => d.User).WithMany(p => p.RcmaTaskUserTemplates)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TaskUserTemplatesUderId");
        });

        modelBuilder.Entity<RcmaTemplate>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_RcmaTemplates_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.RcmaTemplates)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTemplates_GRC_Accounts");
        });

        modelBuilder.Entity<RcmaTemplateElement>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Element).WithMany(p => p.RcmaTemplateElements)
                .HasForeignKey(d => d.ElementId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTemplateElementsElementId");

            entity.HasOne(d => d.Template).WithMany(p => p.RcmaTemplateElements)
                .HasForeignKey(d => d.TemplateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RcmaTemplateElements_RcmaTemplates");
        });

        modelBuilder.Entity<RcmriskImpact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RCMRiskImpact2");

            entity.ToTable("RCMRiskImpact");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RcmriskOccurence>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RCMRiskOccurence2");

            entity.ToTable("RCMRiskOccurence");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<RcmsummaryDept>(entity =>
        {
            entity.ToTable("RCMSummaryDept");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAuditBreaches).HasDefaultValue(0);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.HasIndex(e => e.AccountId, "IX_Region_GRC_Accounts");

            entity.Property(e => e.RegionId).HasColumnName("Region_ID");
            entity.Property(e => e.CreatedBy).HasColumnName("Created_By");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Creation_Date");
            entity.Property(e => e.LastUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("Last_Update_Date");
            entity.Property(e => e.LastUpdatedBy).HasColumnName("Last_Updated_by");
            entity.Property(e => e.RegionName)
                .HasMaxLength(200)
                .HasColumnName("Region_Name");

            entity.HasOne(d => d.Account).WithMany(p => p.Regions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Region_GRC_Accounts");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Section>(entity =>
        {
            entity.ToTable("Section");

            entity.HasIndex(e => e.Code, "IX_Section").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_Section_GRC_Accounts");

            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.Account).WithMany(p => p.Sections)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.Sections)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Section_Department");
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.HasIndex(e => e.LastHeartbeat, "IX_HangFire_Server_LastHeartbeat");

            entity.Property(e => e.Id).HasMaxLength(200);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => new { e.Key, e.Value }).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt").HasFilter("([ExpireAt] IS NOT NULL)");

            entity.HasIndex(e => new { e.Key, e.Score }, "IX_HangFire_Set_Score");

            entity.Property(e => e.Key).HasMaxLength(100);
            entity.Property(e => e.Value).HasMaxLength(256);
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.Id }).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.CreatedAt, "IX_HangFire_State_CreatedAt");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.ToTable("Status");

            entity.HasIndex(e => e.AccountId, "IX_Status_GRC_Accounts");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Status_GRC_Accounts");
        });

        modelBuilder.Entity<StrategicObjective>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_StrategicObjectives_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.StrategicObjectives)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StrategicObjectives_GRC_Accounts");
        });

        modelBuilder.Entity<StrategicProgram>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_StrategicPrograms_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.StrategicPrograms)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StrategicPrograms_GRC_Accounts");

            entity.HasOne(d => d.StrateigcObjectives).WithMany(p => p.StrategicPrograms)
                .HasForeignKey(d => d.StrateigcObjectivesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StrategicPrograms_StrategicObjectives");
        });

        modelBuilder.Entity<StrategicProgramProject>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_StrategicProgramProjects_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.StrategicProgramProjects)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StrategicProgramProjects_GRC_Accounts");

            entity.HasOne(d => d.StrategiccProgram).WithMany(p => p.StrategicProgramProjects)
                .HasForeignKey(d => d.StrategiccProgramId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StrategicProgramProjects_StrategicPrograms");
        });

        modelBuilder.Entity<SubProduct>(entity =>
        {
            entity.ToTable("SubProduct");

            entity.HasIndex(e => e.Id, "IX_SubProduct").IsUnique();

            entity.HasIndex(e => e.AccountId, "IX_SubProduct_GRC_Accounts");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Sla).HasColumnName("SLA");

            entity.HasOne(d => d.Account).WithMany(p => p.SubProducts)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubProduct_GRC_Accounts");

            entity.HasOne(d => d.Product).WithMany(p => p.SubProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubProduct_Product1");
        });

        modelBuilder.Entity<SystemParameter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SystemParameter");

            entity.HasIndex(e => e.AccountId, "IX_SystemParameter_GRC_Accounts");

            entity.Property(e => e.PasswordComplexity).HasMaxLength(100);

            entity.HasOne(d => d.Account).WithMany()
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SystemParameter_GRC_Accounts");
        });

        modelBuilder.Entity<UserBranch>(entity =>
        {
            entity.ToTable("User_Branch");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Account).WithMany(p => p.UserBranches)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Branch_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.UserBranches)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Branch_GRC_BRANCHES");

            entity.HasOne(d => d.User).WithMany(p => p.UserBranches)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Branch_GRC_USERS");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.ToTable("UserDetail");

            entity.HasIndex(e => e.AccountId, "IX_UserDetail_GRC_Accounts");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(100);
            entity.Property(e => e.JoinDate).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserDetail_GRC_Accounts");
        });

        modelBuilder.Entity<UserDivision>(entity =>
        {
            entity.ToTable("User_Division");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.UserDivisions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Division_GRC_Accounts");

            entity.HasOne(d => d.Division).WithMany(p => p.UserDivisions)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Division_Division");

            entity.HasOne(d => d.User).WithMany(p => p.UserDivisions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Division_GRC_USERS");
        });

        modelBuilder.Entity<WblowerCase>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("EncryptedBeforeInsert"));

            entity.HasIndex(e => e.AccountId, "IX_WblowerCases_GRC_Accounts");

            entity.Property(e => e.CaseDescription).IsUnicode(false);
            entity.Property(e => e.ConcernedUsers).IsUnicode(false);
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.IncidentDate).HasColumnType("datetime");
            entity.Property(e => e.IncidentDescription).IsUnicode(false);
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Name).IsUnicode(false);
            entity.Property(e => e.Reference).HasMaxLength(200);
            entity.Property(e => e.Subject).IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCases)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCases_GRC_Accounts");

            entity.HasOne(d => d.ReportChannel).WithMany(p => p.WblowerCases)
                .HasForeignKey(d => d.ReportChannelId)
                .HasConstraintName("FK_WblowerCases_ReportChannelId");

            entity.HasOne(d => d.ReportClass).WithMany(p => p.WblowerCases)
                .HasForeignKey(d => d.ReportClassId)
                .HasConstraintName("FK_WblowerCases_ReportClassId");

            entity.HasOne(d => d.Status).WithMany(p => p.WblowerCases)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCases_Status");
        });

        modelBuilder.Entity<WblowerCaseAction>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseActions_GRC_Accounts");

            entity.Property(e => e.ActionDate).HasColumnType("datetime");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ExpectedResolvedDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseActions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseActions_GRC_Accounts");

            entity.HasOne(d => d.AssignUser).WithMany(p => p.WblowerCaseActionAssignUsers)
                .HasForeignKey(d => d.AssignUserId)
                .HasConstraintName("FK_WblowerCaseActions_GRC_USERSAssignUserId");

            entity.HasOne(d => d.Branch).WithMany(p => p.WblowerCaseActions)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_WblowerCaseActions_GRC_BRANCHES");

            entity.HasOne(d => d.Department).WithMany(p => p.WblowerCaseActions)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_WblowerCaseActions_GRC_DepartmentsId");

            entity.HasOne(d => d.EscalatedUser).WithMany(p => p.WblowerCaseActionEscalatedUsers)
                .HasForeignKey(d => d.EscalatedUserId)
                .HasConstraintName("FK_WblowerCaseActions_GRC_USERSEscalatedUserId");

            entity.HasOne(d => d.LoggedUser).WithMany(p => p.WblowerCaseActionLoggedUsers)
                .HasForeignKey(d => d.LoggedUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseActions_GRC_USERSLoggedByUserId");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.WblowerCaseActions)
                .HasForeignKey(d => d.WblowerCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseActions_WblowerCasesId");
        });

        modelBuilder.Entity<WblowerCaseAttachment>(entity =>
        {
            entity.ToTable("WblowerCaseAttachment");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseAttachment_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseAttachments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseAttachment_GRC_Accounts");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.WblowerCaseAttachments)
                .HasForeignKey(d => d.WblowerCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseAttachment_WblowerCases");
        });

        modelBuilder.Entity<WblowerCaseBreachDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WblowerBreachDepartments");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseBreachDepartments_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseBreachDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseBreachDepartments_GRC_Accounts");

            entity.HasOne(d => d.Branch).WithMany(p => p.WblowerCaseBreachDepartments)
                .HasForeignKey(d => d.BranchId)
                .HasConstraintName("FK_WblowerCaseBreachDepartments_GRC_BRANCHESId");

            entity.HasOne(d => d.Department).WithMany(p => p.WblowerCaseBreachDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Table_1_GRC_DepartmentsDepartmentId");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.WblowerCaseBreachDepartments)
                .HasForeignKey(d => d.WblowerCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_WblowerCasesWblowerCaseId");
        });

        modelBuilder.Entity<WblowerCaseClassPosition>(entity =>
        {
            entity.ToTable("WblowerCaseClassPosition");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseClassPosition_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseClassPositions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseClassPosition_GRC_Accounts");

            entity.HasOne(d => d.Case).WithMany(p => p.WblowerCaseClassPositions)
                .HasForeignKey(d => d.CaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseClassPosition_WblowerCases");

            entity.HasOne(d => d.ClassPosition).WithMany(p => p.WblowerCaseClassPositions)
                .HasForeignKey(d => d.ClassPositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseClassPosition_WblowerClassPosition");
        });

        modelBuilder.Entity<WblowerCaseDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_WblowerDepartments");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseDepartments_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseDepartments)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseDepartments_GRC_Accounts");

            entity.HasOne(d => d.Department).WithMany(p => p.WblowerCaseDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_GRC_DepartmentsId");

            entity.HasOne(d => d.WbloweCase).WithMany(p => p.WblowerCaseDepartments)
                .HasForeignKey(d => d.WbloweCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Table_1_WblowerCasesId");
        });

        modelBuilder.Entity<WblowerCaseEscPosition>(entity =>
        {
            entity.ToTable("WblowerCaseEscPosition");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseEscPosition_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseEscPositions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseEscPosition_GRC_Accounts");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.WblowerCaseEscPositions)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TWblowerCaseEscPosition_JobTitleId");

            entity.HasOne(d => d.WbloweCase).WithMany(p => p.WblowerCaseEscPositions)
                .HasForeignKey(d => d.WbloweCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseEscPosition_WblowerCasesId");
        });

        modelBuilder.Entity<WblowerCaseResolution>(entity =>
        {
            entity.ToTable("WblowerCaseResolution");

            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseResolution_GRC_Accounts");

            entity.HasIndex(e => e.ProcessId, "WblowerCaseResolution_ProcessId");

            entity.HasIndex(e => e.ProcessId, "index_name");

            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ProcessId).HasColumnName("ProcessID");
            entity.Property(e => e.SubRegulationId).HasColumnName("SubRegulationID");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseResolutions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseResolution_GRC_Accounts");

            entity.HasOne(d => d.Process).WithMany(p => p.WblowerCaseResolutions)
                .HasForeignKey(d => d.ProcessId)
                .HasConstraintName("FK__WblowerCa__Proce__0D645A60");

            entity.HasOne(d => d.SubRegulation).WithMany(p => p.WblowerCaseResolutions)
                .HasForeignKey(d => d.SubRegulationId)
                .HasConstraintName("FK_WblowerCaseResolution_GRC_Sub_RegulationsId");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.WblowerCaseResolutions)
                .HasForeignKey(d => d.WblowerCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseResolution_WblowerCasesId");
        });

        modelBuilder.Entity<WblowerCaseRisk>(entity =>
        {
            entity.HasIndex(e => e.AccountId, "IX_WblowerCaseRisks_GRC_Accounts");

            entity.HasIndex(e => e.WblowerCaseId, "IX_WblowerCaseRiskscaseId");

            entity.HasIndex(e => e.RiskId, "idx_RiskId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerCaseRisks)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseRisks_GRC_Accounts");

            entity.HasOne(d => d.Risk).WithMany(p => p.WblowerCaseRisks)
                .HasForeignKey(d => d.RiskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RiskId");

            entity.HasOne(d => d.WblowerCase).WithMany(p => p.WblowerCaseRisks)
                .HasForeignKey(d => d.WblowerCaseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerCaseRisks_WblowerCases");
        });

        modelBuilder.Entity<WblowerClassPosition>(entity =>
        {
            entity.ToTable("WblowerClassPosition");

            entity.HasIndex(e => e.AccountId, "IX_WblowerClassPosition_GRC_Accounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerClassPositions)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerClassPosition_GRC_Accounts");

            entity.HasOne(d => d.JobTitle).WithMany(p => p.WblowerClassPositions)
                .HasForeignKey(d => d.JobTitleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerClassPosition_GRC_JobTitle");

            entity.HasOne(d => d.WblowerClass).WithMany(p => p.WblowerClassPositions)
                .HasForeignKey(d => d.WblowerClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerClassPosition_WblowerClassification");
        });

        modelBuilder.Entity<WblowerClassification>(entity =>
        {
            entity.ToTable("WblowerClassification");

            entity.HasIndex(e => e.AccountId, "IX_WblowerClassification_GRC_Accounts");

            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.LastUpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerClassifications)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WblowerClassification_GRC_Accounts");
        });

        modelBuilder.Entity<WblowerReportChannel>(entity =>
        {
            entity.ToTable("WBlowerReportChannel");

            entity.HasIndex(e => e.Accountid, "IX_Accountid");

            entity.HasIndex(e => e.Code, "IX_Code");

            entity.HasIndex(e => e.Id, "IX_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerReportChannels)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WBlowerReportChannel_GRC_accounts");
        });

        modelBuilder.Entity<WblowerReportClass>(entity =>
        {
            entity.ToTable("WBlowerReportClass");

            entity.HasIndex(e => new { e.Id, e.Code, e.Accountid }, "IX_IdCodeAccountId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.WblowerReportClasses)
                .HasForeignKey(d => d.Accountid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_WBlowerReportClass_GRC_accounts");
        });
        modelBuilder.HasSequence("GovernorateCodeSequence");
        modelBuilder.HasSequence("RcamadvisoryRefrence")
            .HasMin(1L)
            .HasMax(9999999999L);
        modelBuilder.HasSequence("RcamApprovalReference")
            .HasMin(1L)
            .HasMax(9999999999L);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
