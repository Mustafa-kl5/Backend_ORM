using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class AiCombinationRisk
{
    public int Id { get; set; }

    public int CombinationId { get; set; }

    public int RiskId { get; set; }

    public int RiskClassId { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual AiCombination Combination { get; set; } = null!;
}
