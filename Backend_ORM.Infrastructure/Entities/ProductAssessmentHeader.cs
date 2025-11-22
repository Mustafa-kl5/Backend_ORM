using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class ProductAssessmentHeader
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int FreqOfUseId { get; set; }

    public int DamageSeverityId { get; set; }

    public decimal ChanceOfDefect { get; set; }

    public decimal? ProductRiskAssessment { get; set; }

    public DateTime AssessmentDate { get; set; }

    public string? AssessmentSummary { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateOnly? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ProductClassification DamageSeverity { get; set; } = null!;

    public virtual ProductClassification FreqOfUse { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<ProductAssessmentDetail> ProductAssessmentDetails { get; set; } = new List<ProductAssessmentDetail>();
}
