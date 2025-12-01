using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcFunctionDetail
{
    public int Id { get; set; }

    public int FunctionId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcBusinessUnitFunction Function { get; set; } = null!;
}
