using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmLossEventProcess
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public int LossEventId { get; set; }

    public int ProcessDetailesId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int ProcessBusinessLineId { get; set; }

    public virtual OrmLossEvent LossEvent { get; set; } = null!;

    public virtual OrmLossEventProcessBusinessLine ProcessBusinessLine { get; set; } = null!;

    public virtual OrmProcessDetail ProcessDetailes { get; set; } = null!;
}
