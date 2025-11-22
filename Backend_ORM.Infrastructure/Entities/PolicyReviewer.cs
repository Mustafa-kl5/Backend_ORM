using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class PolicyReviewer
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int PolicyId { get; set; }

    public int UserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
