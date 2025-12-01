using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class AiCombination
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int RiskVal { get; set; }

    public int RiskClass { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int? Sequence { get; set; }

    public virtual ICollection<AiCombinationDetail> AiCombinationDetails { get; set; } = new List<AiCombinationDetail>();

    public virtual ICollection<AiCombinationRisk> AiCombinationRisks { get; set; } = new List<AiCombinationRisk>();
}
