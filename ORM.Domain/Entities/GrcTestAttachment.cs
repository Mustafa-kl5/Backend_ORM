using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcTestAttachment
{
    public int Id { get; set; }

    public int TestId { get; set; }

    public string Attachment { get; set; } = null!;

    public string AttachedBy { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual GrcTestDetail Test { get; set; } = null!;
}
