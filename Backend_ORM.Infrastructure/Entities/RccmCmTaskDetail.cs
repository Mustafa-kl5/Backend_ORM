using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RccmCmTaskDetail
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public int? SubRegulationId { get; set; }

    public int? FunctionId { get; set; }

    public int? SubProductId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcBusinessUnitFunction? Function { get; set; }

    public virtual SubProduct? SubProduct { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }

    public virtual RccmCmTask Task { get; set; } = null!;
}
