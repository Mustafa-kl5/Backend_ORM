using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class Policy
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int PolicyOwnerId { get; set; }

    public int InitiatedUserId { get; set; }

    public int PolicyStatusId { get; set; }

    public string? PolicyName { get; set; }

    public string? Comments { get; set; }

    public DateTime? DueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser InitiatedUser { get; set; } = null!;

    public virtual ICollection<PolicyApprovalStage> PolicyApprovalStages { get; set; } = new List<PolicyApprovalStage>();

    public virtual ICollection<PolicyDeveloper> PolicyDevelopers { get; set; } = new List<PolicyDeveloper>();

    public virtual ICollection<PolicyFile> PolicyFiles { get; set; } = new List<PolicyFile>();

    public virtual GrcUser PolicyOwner { get; set; } = null!;

    public virtual ICollection<PolicyReader> PolicyReaders { get; set; } = new List<PolicyReader>();

    public virtual ICollection<PolicyReviewer> PolicyReviewers { get; set; } = new List<PolicyReviewer>();

    public virtual ICollection<PolicyReview> PolicyReviews { get; set; } = new List<PolicyReview>();

    public virtual PolicyStatus PolicyStatus { get; set; } = null!;
}
