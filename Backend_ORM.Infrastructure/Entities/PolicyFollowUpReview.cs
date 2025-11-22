using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class PolicyFollowUpReview
{
    public int Id { get; set; }

    public int ReviewUserId { get; set; }

    public int PolicyReviewId { get; set; }

    public string Comments { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual PolicyReview PolicyReview { get; set; } = null!;

    public virtual GrcUser ReviewUser { get; set; } = null!;
}
