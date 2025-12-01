using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcamAdvisoryRequestAction
{
    public int Id { get; set; }

    public int AdvisoryRequestId { get; set; }

    public int UserId { get; set; }

    public int AdvisoryStatusId { get; set; }

    public int LineNumber { get; set; }

    public string Feedback { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcamAdvisoryRequest AdvisoryRequest { get; set; } = null!;

    public virtual RcamAdvisoryStatus AdvisoryStatus { get; set; } = null!;

    public virtual ICollection<RcamAdvisoryActionAttachment> RcamAdvisoryActionAttachments { get; set; } = new List<RcamAdvisoryActionAttachment>();

    public virtual GrcUser User { get; set; } = null!;
}
