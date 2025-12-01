using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmrbaRiskDetailsRange
{
    public int Id { get; set; }

    public int OrmrbaRiskDetailsId { get; set; }

    public int DetailsRangeId { get; set; }

    public int DetailsRangeValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual OrmraElementDetailRange DetailsRange { get; set; } = null!;

    public virtual OrmrbaRiskDetail OrmrbaRiskDetails { get; set; } = null!;
}
