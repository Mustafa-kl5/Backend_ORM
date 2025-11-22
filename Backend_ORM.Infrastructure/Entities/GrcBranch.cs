using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcBranch
{
    public int BranchId { get; set; }

    public int CouCountryId { get; set; }

    public int DepDepartmentId { get; set; }

    public string BranchCode { get; set; } = null!;

    public string BranchName { get; set; } = null!;

    public string BranchEmail1 { get; set; } = null!;

    public string? BranchEmail2 { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? City { get; set; }

    public string? Pobox { get; set; }

    public string? District { get; set; }

    public string? Street { get; set; }

    public string? BuildingNo { get; set; }

    public string? BranchPhone { get; set; }

    public string? BranchFax { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; } = new List<BcmBiaFuntionsBusinessUnit>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual ICollection<CompActionDetail> CompActionDetails { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompBreachDepartment> CompBreachDepartments { get; set; } = new List<CompBreachDepartment>();

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual GrcDepartment DepDepartment { get; set; } = null!;

    public virtual ICollection<GrcAuditDepBranch> GrcAuditDepBranches { get; set; } = new List<GrcAuditDepBranch>();

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();

    public virtual ICollection<GrcBranchAttachFile> GrcBranchAttachFiles { get; set; } = new List<GrcBranchAttachFile>();

    public virtual ICollection<GrcCalendarDepartment> GrcCalendarDepartments { get; set; } = new List<GrcCalendarDepartment>();

    public virtual ICollection<GrcCrimeBusinessunit> GrcCrimeBusinessunits { get; set; } = new List<GrcCrimeBusinessunit>();

    public virtual ICollection<GrcEntityAssessmentDetail> GrcEntityAssessmentDetails { get; set; } = new List<GrcEntityAssessmentDetail>();

    public virtual ICollection<GrcGoalDetailsBu> GrcGoalDetailsBus { get; set; } = new List<GrcGoalDetailsBu>();

    public virtual ICollection<GrcGoalsBu> GrcGoalsBus { get; set; } = new List<GrcGoalsBu>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<GrcWblowerCaseBranch> GrcWblowerCaseBranches { get; set; } = new List<GrcWblowerCaseBranch>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<UserBranch> UserBranches { get; set; } = new List<UserBranch>();

    public virtual ICollection<WblowerCaseAction> WblowerCaseActions { get; set; } = new List<WblowerCaseAction>();

    public virtual ICollection<WblowerCaseBreachDepartment> WblowerCaseBreachDepartments { get; set; } = new List<WblowerCaseBreachDepartment>();
}
