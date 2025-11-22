using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class PolicyReview
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int UserId { get; set; }

    public int PolicyId { get; set; }

    public int PolicyStatusId { get; set; }

    public string? Comments { get; set; }

    public string PolicyVersion { get; set; } = null!;

    public string AttachedFile { get; set; } = null!;

    public string? AttachedFilePdf { get; set; }

    public string? AttachedReviewFilePdf { get; set; }

    public DateTime? ApproveDate { get; set; }

    public DateTime? PublishDate { get; set; }

    public DateTime? RetireDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;

    public virtual ICollection<PolicyFollowUpReview> PolicyFollowUpReviews { get; set; } = new List<PolicyFollowUpReview>();

    public virtual ICollection<PolicyRejectReasonLog> PolicyRejectReasonLogs { get; set; } = new List<PolicyRejectReasonLog>();

    public virtual PolicyStatus PolicyStatus { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
