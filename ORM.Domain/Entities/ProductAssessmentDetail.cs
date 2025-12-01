using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class ProductAssessmentDetail
{
    public int Id { get; set; }

    public int AssessmentHeaderId { get; set; }

    public int EvaluationId { get; set; }

    public int IndicatorId { get; set; }

    public string IndicatorReference { get; set; } = null!;

    public string IndicatorDescription { get; set; } = null!;

    public string? Notes { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdaredBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ProductAssessmentHeader AssessmentHeader { get; set; } = null!;

    public virtual ProductClassification Evaluation { get; set; } = null!;

    public virtual ProductCategoryIndicator Indicator { get; set; } = null!;
}
