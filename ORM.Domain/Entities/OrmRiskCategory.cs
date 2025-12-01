using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRiskCategory
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmCategory Category { get; set; } = null!;

    public virtual ICollection<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; } = new List<OrmRbaProcessRiskAsesmnt>();

    public virtual ICollection<OrmRbaRisk> OrmRbaRisks { get; set; } = new List<OrmRbaRisk>();

    public virtual ICollection<OrmRiskElement> OrmRiskElements { get; set; } = new List<OrmRiskElement>();
}
