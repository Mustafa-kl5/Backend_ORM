using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcRegulationsAttachment
{
    public int Id { get; set; }

    public int? RegulationId { get; set; }

    public int? SubRegulationId { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcRegulation? Regulation { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }
}
