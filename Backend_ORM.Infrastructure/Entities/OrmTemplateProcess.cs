using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmTemplateProcess
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TemplateId { get; set; }

    public int ProcessDetailId { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmProcessDetail ProcessDetail { get; set; } = null!;

    public virtual OrmTemplate Template { get; set; } = null!;
}
