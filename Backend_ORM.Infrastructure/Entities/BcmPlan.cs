using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmPlan
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int? PlanEventCategoryId { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlan> BcmBiaPlans { get; set; } = new List<BcmBiaPlan>();

    public virtual BcmPlanEventCategory? PlanEventCategory { get; set; }
}
