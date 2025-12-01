using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaAssessmentElementDetail
{
    public int Id { get; set; }

    public int AssessmentElementHeaderId { get; set; }

    public int? ComplyId { get; set; }

    public int ElementId { get; set; }

    public string? Feedback { get; set; }

    public string? AssessmentAnalysis { get; set; }

    public int? Score { get; set; }

    public DateTime? AnswerDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcmaAssessmentElementHeader AssessmentElementHeader { get; set; } = null!;

    public virtual GrcComply? Comply { get; set; }

    public virtual RcmaElement Element { get; set; } = null!;

    public virtual ICollection<RcmaAttachment> RcmaAttachments { get; set; } = new List<RcmaAttachment>();
}
