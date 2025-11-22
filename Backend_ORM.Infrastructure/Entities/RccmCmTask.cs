using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RccmCmTask
{
    public int Id { get; set; }

    public int ChangeManagemenrId { get; set; }

    public string TaskRef { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? StatusId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual RccmChangeManagement ChangeManagemenr { get; set; } = null!;

    public virtual ICollection<RccmCmTaskDetail> RccmCmTaskDetails { get; set; } = new List<RccmCmTaskDetail>();

    public virtual ICollection<RccmTaskUser> RccmTaskUsers { get; set; } = new List<RccmTaskUser>();

    public virtual RccmCmTaskStatus? Status { get; set; }
}
