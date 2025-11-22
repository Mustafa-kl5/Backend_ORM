using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaAttachment
{
    public int Id { get; set; }

    public int AssessmentElementDetailId { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcmaAssessmentElementDetail AssessmentElementDetail { get; set; } = null!;
}
