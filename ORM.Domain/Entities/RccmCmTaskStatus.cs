using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RccmCmTaskStatus
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int Code { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RccmCmTask> RccmCmTasks { get; set; } = new List<RccmCmTask>();

    public virtual ICollection<RccmTaskUserAction> RccmTaskUserActions { get; set; } = new List<RccmTaskUserAction>();

    public virtual ICollection<RccmTaskUser> RccmTaskUsers { get; set; } = new List<RccmTaskUser>();
}
