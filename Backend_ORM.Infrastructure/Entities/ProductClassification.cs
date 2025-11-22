using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ProductClassification
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string ShortDesc { get; set; } = null!;

    public string? Description { get; set; }

    public int Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<ProductAssessmentDetail> ProductAssessmentDetails { get; set; } = new List<ProductAssessmentDetail>();

    public virtual ICollection<ProductAssessmentHeader> ProductAssessmentHeaderDamageSeverities { get; set; } = new List<ProductAssessmentHeader>();

    public virtual ICollection<ProductAssessmentHeader> ProductAssessmentHeaderFreqOfUses { get; set; } = new List<ProductAssessmentHeader>();
}
