using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaElement
{
    public int Id { get; set; }

    public int PrincipleId { get; set; }

    public string Reference { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string? Comments { get; set; }

    public int Weight { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual RcmaPrinciple Principle { get; set; } = null!;

    public virtual ICollection<RcmaAssessmentElementDetail> RcmaAssessmentElementDetails { get; set; } = new List<RcmaAssessmentElementDetail>();

    public virtual ICollection<RcmaTemplateElement> RcmaTemplateElements { get; set; } = new List<RcmaTemplateElement>();
}
