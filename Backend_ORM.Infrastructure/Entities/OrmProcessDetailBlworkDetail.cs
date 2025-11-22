using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcessDetailBlworkDetail
{
    public int Id { get; set; }

    public int ProcessLinkWorkId { get; set; }

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

    public virtual OrmraElementRange? ElementRange { get; set; }

    public virtual ICollection<OrmProcessDetailBlworkDetailsRange> OrmProcessDetailBlworkDetailsRanges { get; set; } = new List<OrmProcessDetailBlworkDetailsRange>();

    public virtual OrmProcessDetailBlwork ProcessLinkWork { get; set; } = null!;
}
