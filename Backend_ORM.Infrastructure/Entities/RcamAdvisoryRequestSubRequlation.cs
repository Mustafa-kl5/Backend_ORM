using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RcamAdvisoryRequestSubRequlation
{
    public int Id { get; set; }

    public int AdvisoryRequestId { get; set; }

    public int SubRegulationId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcamAdvisoryRequest AdvisoryRequest { get; set; } = null!;

    public virtual GrcSubRegulation SubRegulation { get; set; } = null!;
}
