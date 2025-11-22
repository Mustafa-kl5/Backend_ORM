using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CompRootCauseAttachment
{
    public int Id { get; set; }

    public int CompRootCauseId { get; set; }

    public string AttachedFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual CompRootCause CompRootCause { get; set; } = null!;
}
