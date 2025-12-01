using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmaTemplate
{
    public int Id { get; set; }

    public string Reference { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RcmaTaskUserTemplate> RcmaTaskUserTemplates { get; set; } = new List<RcmaTaskUserTemplate>();

    public virtual ICollection<RcmaTemplateElement> RcmaTemplateElements { get; set; } = new List<RcmaTemplateElement>();
}
