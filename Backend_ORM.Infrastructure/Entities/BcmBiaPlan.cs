using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaPlan
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaId { get; set; }

    public int PlanId { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanElement> BcmBiaPlanElements { get; set; } = new List<BcmBiaPlanElement>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanSchedules { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmPlanNotificationProc> BcmPlanNotificationProcs { get; set; } = new List<BcmPlanNotificationProc>();

    public virtual ICollection<BcmPlanRecoveryTeam> BcmPlanRecoveryTeams { get; set; } = new List<BcmPlanRecoveryTeam>();

    public virtual ICollection<BcmPlanVendorList> BcmPlanVendorLists { get; set; } = new List<BcmPlanVendorList>();

    public virtual BcmBiaFuntion Bia { get; set; } = null!;

    public virtual BcmPlan Plan { get; set; } = null!;
}
