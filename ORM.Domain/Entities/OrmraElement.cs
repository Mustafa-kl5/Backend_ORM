using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmraElement
{
    public int Id { get; set; }

    public int RaCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<OrmProcessDetailBlworkDetail> OrmProcessDetailBlworkDetails { get; set; } = new List<OrmProcessDetailBlworkDetail>();

    public virtual ICollection<OrmRbaProcessRiskAsesmntDetail> OrmRbaProcessRiskAsesmntDetails { get; set; } = new List<OrmRbaProcessRiskAsesmntDetail>();

    public virtual ICollection<OrmraElementDetail> OrmraElementDetails { get; set; } = new List<OrmraElementDetail>();

    public virtual ICollection<OrmraElementRange> OrmraElementRanges { get; set; } = new List<OrmraElementRange>();

    public virtual ICollection<OrmrbaRiskDetail> OrmrbaRiskDetails { get; set; } = new List<OrmrbaRiskDetail>();

    public virtual OrmraCategory RaCategory { get; set; } = null!;
}
