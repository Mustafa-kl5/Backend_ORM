using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmLossEventRisk
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int LossEventId { get; set; }

    public int RiskCategoryId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmLossEvent LossEvent { get; set; } = null!;

    public virtual OrmRiskElement RiskCategory { get; set; } = null!;
}
