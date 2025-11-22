using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmProcessDetailBlworkDetailsRange
{
    public int Id { get; set; }

    public int OrmProcessDetailBlworkDetailsId { get; set; }

    public int DetailsRangeId { get; set; }

    public int DetailsRangeValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual OrmraElementDetailRange DetailsRange { get; set; } = null!;

    public virtual OrmProcessDetailBlworkDetail OrmProcessDetailBlworkDetails { get; set; } = null!;
}
