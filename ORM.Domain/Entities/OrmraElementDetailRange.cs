using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmraElementDetailRange
{
    public int Id { get; set; }

    public int RaElementDetailId { get; set; }

    public string Name { get; set; } = null!;

    public int Score { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<OrmProcessDetailBlworkDetailsRange> OrmProcessDetailBlworkDetailsRanges { get; set; } = new List<OrmProcessDetailBlworkDetailsRange>();

    public virtual ICollection<OrmRbaProcessRiskAsesmntDetailsRange> OrmRbaProcessRiskAsesmntDetailsRanges { get; set; } = new List<OrmRbaProcessRiskAsesmntDetailsRange>();

    public virtual ICollection<OrmrbaRiskDetailsRange> OrmrbaRiskDetailsRanges { get; set; } = new List<OrmrbaRiskDetailsRange>();
}
