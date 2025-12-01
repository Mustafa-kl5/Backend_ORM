using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcamAdvisoryActionAttachment
{
    public int Id { get; set; }

    public int AdvisoryActionId { get; set; }

    public string AttachFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual RcamAdvisoryRequestAction AdvisoryAction { get; set; } = null!;
}
