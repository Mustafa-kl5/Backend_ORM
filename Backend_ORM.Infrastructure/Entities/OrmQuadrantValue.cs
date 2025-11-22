using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmQuadrantValue
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ResidualQuadrantId { get; set; }

    public int Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmResidualRiskQuadrant ResidualQuadrant { get; set; } = null!;
}
