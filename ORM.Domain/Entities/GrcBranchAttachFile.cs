using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcBranchAttachFile
{
    public int Id { get; set; }

    public int BranchId { get; set; }

    public string AttachedFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcBranch Branch { get; set; } = null!;
}
