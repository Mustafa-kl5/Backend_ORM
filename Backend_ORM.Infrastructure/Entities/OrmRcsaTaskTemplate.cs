using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaTaskTemplate
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TemplateId { get; set; }

    public int TaskId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmRcsaTask Task { get; set; } = null!;

    public virtual OrmTemplate Template { get; set; } = null!;
}
