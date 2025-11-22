using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmrbaRiskDetail
{
    public int Id { get; set; }

    public int AsesmntWorkId { get; set; }

    public int AsesmntElementId { get; set; }

    public int? AsesmntElementDetailId { get; set; }

    public decimal? ElementScore { get; set; }

    public int? ElementMultiplier { get; set; }

    public decimal? DetailScore { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ElementRangeId { get; set; }

    public int? ElementRangeValue { get; set; }

    public virtual OrmraElement AsesmntElement { get; set; } = null!;

    public virtual OrmraElementDetail? AsesmntElementDetail { get; set; }

    public virtual OrmrbaRiskWork AsesmntWork { get; set; } = null!;

    public virtual OrmraElementRange? ElementRange { get; set; }

    public virtual ICollection<OrmrbaRiskDetailsRange> OrmrbaRiskDetailsRanges { get; set; } = new List<OrmrbaRiskDetailsRange>();
}
