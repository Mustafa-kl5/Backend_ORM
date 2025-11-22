using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmLossEventKri
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int LossEventId { get; set; }

    public int KriId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmKri Kri { get; set; } = null!;

    public virtual OrmLossEvent LossEvent { get; set; } = null!;
}
