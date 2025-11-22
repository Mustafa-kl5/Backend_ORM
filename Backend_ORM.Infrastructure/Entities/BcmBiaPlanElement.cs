using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmBiaPlanElement
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanId { get; set; }

    public int PlanElementId { get; set; }

    public string Feedback { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanElementTest> BcmBiaPlanElementTests { get; set; } = new List<BcmBiaPlanElementTest>();

    public virtual BcmBiaPlan BiaPlan { get; set; } = null!;

    public virtual BcmPlanElement PlanElement { get; set; } = null!;
}
