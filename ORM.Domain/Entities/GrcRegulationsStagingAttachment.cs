using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRegulationsStagingAttachment
{
    public int Id { get; set; }

    public int? RegulationId { get; set; }

    public int? SubRegulationId { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcStagingRegulation? Regulation { get; set; }

    public virtual GrcStagingSubRegulation? SubRegulation { get; set; }
}
