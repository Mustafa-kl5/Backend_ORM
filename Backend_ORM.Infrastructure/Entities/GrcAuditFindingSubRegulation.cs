using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcAuditFindingSubRegulation
{
    public int Id { get; set; }

    public int AuditFindingId { get; set; }

    public int RegulationId { get; set; }

    public int SubRegulationId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAuditFinding AuditFinding { get; set; } = null!;

    public virtual GrcRegulation Regulation { get; set; } = null!;

    public virtual GrcSubRegulation SubRegulation { get; set; } = null!;
}
