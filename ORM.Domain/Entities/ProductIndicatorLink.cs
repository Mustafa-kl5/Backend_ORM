using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ProductIndicatorLink
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int IndicatorId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ProductCategoryIndicator Indicator { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
