using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaTemplateElement
{
    public int Id { get; set; }

    public int TemplateId { get; set; }

    public int ElementId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcmaElement Element { get; set; } = null!;

    public virtual RcmaTemplate Template { get; set; } = null!;
}
