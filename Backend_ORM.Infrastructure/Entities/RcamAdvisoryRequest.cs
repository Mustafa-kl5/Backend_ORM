using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcamAdvisoryRequest
{
    public int Id { get; set; }

    public int? InitiatedByUserId { get; set; }

    public int AdvisoryStatusId { get; set; }

    public int AdvisoryCategoryId { get; set; }

    public int AdvisoryPriorityId { get; set; }

    public int AdvisoryTypeId { get; set; }

    public string AdvisoryReference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime DueDate { get; set; }

    public string? ResponseSummary { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ExternalInitiatedBy { get; set; }

    public int? Views { get; set; }

    public int AccountId { get; set; }

    public string? Subject { get; set; }

    public bool? Visibility { get; set; }

    public string? ResolveReason { get; set; }

    public DateTime? ResolveDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual RcamAdvisoryCategory AdvisoryCategory { get; set; } = null!;

    public virtual RcamAdvisoryPriority AdvisoryPriority { get; set; } = null!;

    public virtual RcamAdvisoryStatus AdvisoryStatus { get; set; } = null!;

    public virtual RcamAdvisoryType AdvisoryType { get; set; } = null!;

    public virtual GrcExternalUserAccess? ExternalInitiatedByNavigation { get; set; }

    public virtual GrcUser? InitiatedByUser { get; set; }

    public virtual ICollection<RcamAdvisoryRequestAction> RcamAdvisoryRequestActions { get; set; } = new List<RcamAdvisoryRequestAction>();

    public virtual ICollection<RcamAdvisoryRequestAttachment> RcamAdvisoryRequestAttachments { get; set; } = new List<RcamAdvisoryRequestAttachment>();

    public virtual ICollection<RcamAdvisoryRequestSubRequlation> RcamAdvisoryRequestSubRequlations { get; set; } = new List<RcamAdvisoryRequestSubRequlation>();

    public virtual ICollection<RcamAdvisoryRequestUser> RcamAdvisoryRequestUsers { get; set; } = new List<RcamAdvisoryRequestUser>();
}
