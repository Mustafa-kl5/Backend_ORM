using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmTemplate
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Reference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmRcsaTaskTemplate> OrmRcsaTaskTemplates { get; set; } = new List<OrmRcsaTaskTemplate>();

    public virtual ICollection<OrmTemplateProcess> OrmTemplateProcesses { get; set; } = new List<OrmTemplateProcess>();
}
