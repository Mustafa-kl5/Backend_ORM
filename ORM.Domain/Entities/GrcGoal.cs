using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcGoal
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public int? Code { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcGoalsCategory Category { get; set; } = null!;

    public virtual ICollection<GrcGoalsBu> GrcGoalsBus { get; set; } = new List<GrcGoalsBu>();

    public virtual ICollection<GrcGoalsDetail> GrcGoalsDetails { get; set; } = new List<GrcGoalsDetail>();
}
