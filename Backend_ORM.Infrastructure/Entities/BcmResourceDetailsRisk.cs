using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmResourceDetailsRisk
{
    public int Id { get; set; }

    public int RiskElementId { get; set; }

    public int ResourceDetailsId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual BcmResourceDetail ResourceDetails { get; set; } = null!;

    public virtual OrmRiskElement RiskElement { get; set; } = null!;
}
