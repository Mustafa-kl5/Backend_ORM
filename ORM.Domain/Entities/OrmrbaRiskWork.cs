using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmrbaRiskWork
{
    public int Id { get; set; }

    public int RiskId { get; set; }

    public DateTime? AsesmntDate { get; set; }

    public int RiskImpactId { get; set; }

    public int RiskOccurenceId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<OrmrbaRiskDetail> OrmrbaRiskDetails { get; set; } = new List<OrmrbaRiskDetail>();

    public virtual OrmRbaRisk Risk { get; set; } = null!;
}
