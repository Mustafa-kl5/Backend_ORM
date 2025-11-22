using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RccmTaskUser
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int UserId { get; set; }

    public int? ApproveUserId { get; set; }

    public int StatusId { get; set; }

    public int? TaskApproveById { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedate { get; set; }

    public virtual GrcUser? ApproveUser { get; set; }

    public virtual ICollection<RccmTaskUserAction> RccmTaskUserActions { get; set; } = new List<RccmTaskUserAction>();

    public virtual RccmCmTaskStatus Status { get; set; } = null!;

    public virtual RccmCmTask Task { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
