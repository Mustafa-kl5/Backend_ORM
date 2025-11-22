using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcmaAssessmentElementHeader
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int? UserId { get; set; }

    public int StatusId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedate { get; set; }

    public decimal? Score { get; set; }

    public int? ExternalUserId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcExternalUserAccess? ExternalUser { get; set; }

    public virtual ICollection<RcmaAssessmentElementDetail> RcmaAssessmentElementDetails { get; set; } = new List<RcmaAssessmentElementDetail>();

    public virtual RcmaStatus Status { get; set; } = null!;

    public virtual RcmaTask Task { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
