using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RccmTaskUserAction
{
    public int Id { get; set; }

    public int LineNumber { get; set; }

    public int TaskUserId { get; set; }

    public int? ApprovedByUserId { get; set; }

    public int StatusId { get; set; }

    public string Action { get; set; } = null!;

    public string? Comments { get; set; }

    public DateTime? ExpectedResolvedDate { get; set; }

    public DateTime? ResolvedDate { get; set; }

    public string? AttachFile { get; set; }

    public int ActionUserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcUser? ApprovedByUser { get; set; }

    public virtual RccmCmTaskStatus Status { get; set; } = null!;

    public virtual RccmTaskUser TaskUser { get; set; } = null!;
}
