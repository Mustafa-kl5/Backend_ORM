using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcEntityAssessmentDetail
{
    public int Id { get; set; }

    public int? BranchId { get; set; }

    public int AssessorUserId { get; set; }

    public int RiskRatingId { get; set; }

    public DateTime? Date { get; set; }

    public string? FeedBack { get; set; }

    public string? RiskRatingReason { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser AssessorUser { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcAuditRiskRating RiskRating { get; set; } = null!;
}
