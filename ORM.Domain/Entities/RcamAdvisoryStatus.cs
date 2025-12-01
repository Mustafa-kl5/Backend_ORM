using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcamAdvisoryStatus
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RcamAdvisoryRequestAction> RcamAdvisoryRequestActions { get; set; } = new List<RcamAdvisoryRequestAction>();

    public virtual ICollection<RcamAdvisoryRequest> RcamAdvisoryRequests { get; set; } = new List<RcamAdvisoryRequest>();
}
