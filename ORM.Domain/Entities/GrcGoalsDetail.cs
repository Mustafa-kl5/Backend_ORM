using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcGoalsDetail
{
    public int Id { get; set; }

    public int GoalId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public int? Code { get; set; }

    public virtual GrcGoal Goal { get; set; } = null!;

    public virtual ICollection<GrcGoalDetailsBu> GrcGoalDetailsBus { get; set; } = new List<GrcGoalDetailsBu>();
}
