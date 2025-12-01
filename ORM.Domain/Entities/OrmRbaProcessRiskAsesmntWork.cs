using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRbaProcessRiskAsesmntWork
{
    public int Id { get; set; }

    public int AsesmntId { get; set; }

    public DateTime? AsesmntDate { get; set; }

    public int RiskImpactId { get; set; }

    public int RiskOccurenceId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual OrmRbaProcessRiskAsesmnt Asesmnt { get; set; } = null!;

    public virtual ICollection<OrmRbaProcessRiskAsesmntDetail> OrmRbaProcessRiskAsesmntDetails { get; set; } = new List<OrmRbaProcessRiskAsesmntDetail>();
}
