using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class PolicyRejectReasonLog
{
    public int Id { get; set; }

    public int PolicyReviewId { get; set; }

    public int RejectUserId { get; set; }

    public string RejectionReason { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual PolicyReview PolicyReview { get; set; } = null!;

    public virtual GrcUser RejectUser { get; set; } = null!;
}
