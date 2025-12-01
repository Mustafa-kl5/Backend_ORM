using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class UserBranch
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int UserId { get; set; }

    public int BranchId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch Branch { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
