using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RccmAttachment
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }
}
