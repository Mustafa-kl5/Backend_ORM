using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcArchivingPolicy
{
    public int Id { get; set; }

    public string ArchiveTable { get; set; } = null!;

    public int RepititionPeriod { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CrationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
