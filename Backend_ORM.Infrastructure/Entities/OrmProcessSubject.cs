using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcessSubject
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ProcessId { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmProcessDetail> OrmProcessDetails { get; set; } = new List<OrmProcessDetail>();

    public virtual OrmProcess Process { get; set; } = null!;
}
