using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ProductCategoryIndicator
{
    public int Id { get; set; }

    public int ProductCategoryId { get; set; }

    public string Reference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<ProductAssessmentDetail> ProductAssessmentDetails { get; set; } = new List<ProductAssessmentDetail>();

    public virtual ProductCategory ProductCategory { get; set; } = null!;

    public virtual ICollection<ProductIndicatorLink> ProductIndicatorLinks { get; set; } = new List<ProductIndicatorLink>();
}
