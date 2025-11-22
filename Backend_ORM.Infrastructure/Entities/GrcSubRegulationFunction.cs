using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcSubRegulationFunction
{
    public int Id { get; set; }

    public int SubRegulationId { get; set; }

    public int FunctionId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcBusinessUnitFunction Function { get; set; } = null!;

    public virtual GrcSubRegulation SubRegulation { get; set; } = null!;
}
