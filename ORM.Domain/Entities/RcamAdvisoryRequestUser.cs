using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcamAdvisoryRequestUser
{
    public int Id { get; set; }

    public int AdvisoryRequestId { get; set; }

    public int UserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDatw { get; set; }

    public virtual RcamAdvisoryRequest AdvisoryRequest { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
