using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcess
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProcessTypeId { get; set; }

    public string? Description { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmProcessSubject> OrmProcessSubjects { get; set; } = new List<OrmProcessSubject>();

    public virtual OrmProcessType ProcessType { get; set; } = null!;
}
