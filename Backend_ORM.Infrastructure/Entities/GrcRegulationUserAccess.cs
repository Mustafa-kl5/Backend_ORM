using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationUserAccess
{
    public int Id { get; set; }

    public int? RegulationId { get; set; }

    public int? StagingRegulationId { get; set; }

    public int UserId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcRegulation? Regulation { get; set; }

    public virtual GrcStagingRegulation? StagingRegulation { get; set; }

    public virtual GrcUser User { get; set; } = null!;
}
