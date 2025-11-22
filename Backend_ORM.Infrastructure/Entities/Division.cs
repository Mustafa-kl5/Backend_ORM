using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class Division
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int DepartmentId { get; set; }

    public string Description { get; set; } = null!;

    public string? Email1 { get; set; }

    public string? Email2 { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntionsBusinessUnit> BcmBiaFuntionsBusinessUnits { get; set; } = new List<BcmBiaFuntionsBusinessUnit>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual ICollection<GrcGoalDetailsBu> GrcGoalDetailsBus { get; set; } = new List<GrcGoalDetailsBu>();

    public virtual ICollection<GrcGoalsBu> GrcGoalsBus { get; set; } = new List<GrcGoalsBu>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<UserDivision> UserDivisions { get; set; } = new List<UserDivision>();
}
