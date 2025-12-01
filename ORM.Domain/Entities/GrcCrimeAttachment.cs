using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCrimeAttachment
{
    public int Id { get; set; }

    public int CrimeId { get; set; }

    public string Attachment { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? AddedByCompliance { get; set; }
}
