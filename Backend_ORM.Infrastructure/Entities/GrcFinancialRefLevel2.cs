using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcFinancialRefLevel2
{
    public int ValueId { get; set; }

    public string Name { get; set; } = null!;

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcFinancialCollectionLevel2> GrcFinancialCollectionLevel2s { get; set; } = new List<GrcFinancialCollectionLevel2>();

    public virtual ICollection<GrcFinancialRefLevelLink> GrcFinancialRefLevelLinks { get; set; } = new List<GrcFinancialRefLevelLink>();
}
