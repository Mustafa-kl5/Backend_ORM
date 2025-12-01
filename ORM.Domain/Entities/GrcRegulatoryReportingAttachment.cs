using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcRegulatoryReportingAttachment
{
    public int Id { get; set; }

    public int ReportingId { get; set; }

    public string AttachedFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcRegulatoryReportingTrack Reporting { get; set; } = null!;
}
