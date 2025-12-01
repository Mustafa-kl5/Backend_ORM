using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcComply
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcDataCollectionAnswer> GrcDataCollectionAnswers { get; set; } = new List<GrcDataCollectionAnswer>();

    public virtual ICollection<GrcDataCollectionNonfinancial> GrcDataCollectionNonfinancials { get; set; } = new List<GrcDataCollectionNonfinancial>();

    public virtual ICollection<GrcTestDetail> GrcTestDetails { get; set; } = new List<GrcTestDetail>();

    public virtual ICollection<RcmaAssessmentElementDetail> RcmaAssessmentElementDetails { get; set; } = new List<RcmaAssessmentElementDetail>();
}
