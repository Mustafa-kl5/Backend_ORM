using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmraElementDetail
{
    public int Id { get; set; }

    public int RaElementId { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<OrmProcessDetailBlworkDetail> OrmProcessDetailBlworkDetails { get; set; } = new List<OrmProcessDetailBlworkDetail>();

    public virtual ICollection<OrmRbaProcessRiskAsesmntDetail> OrmRbaProcessRiskAsesmntDetails { get; set; } = new List<OrmRbaProcessRiskAsesmntDetail>();

    public virtual ICollection<OrmrbaRiskDetail> OrmrbaRiskDetails { get; set; } = new List<OrmrbaRiskDetail>();

    public virtual OrmraElement RaElement { get; set; } = null!;
}
