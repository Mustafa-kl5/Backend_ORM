using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDataNonFinancialAttachFile
{
    public int Id { get; set; }

    public int NonFinancialCollectionId { get; set; }

    public string AttachedFile { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcDataCollectionNonfinancial NonFinancialCollection { get; set; } = null!;
}
