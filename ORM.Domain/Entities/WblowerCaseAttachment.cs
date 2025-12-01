using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class WblowerCaseAttachment
{
    public int Id { get; set; }

    public int WblowerCaseId { get; set; }

    public string Attachment { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual WblowerCase WblowerCase { get; set; } = null!;
}
