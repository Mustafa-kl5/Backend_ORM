using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CorresAttachFile
{
    public int Id { get; set; }

    public int LetterId { get; set; }

    public string AttachFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual CorresLetter Letter { get; set; } = null!;
}
