using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcFinancialRefLevelLink
{
    public int ValueId { get; set; }

    public int FreValueId { get; set; }

    public int FrlValueId { get; set; }

    public bool? IsAdd { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcFinancialRef FreValue { get; set; } = null!;

    public virtual GrcFinancialRefLevel2 FrlValue { get; set; } = null!;
}
