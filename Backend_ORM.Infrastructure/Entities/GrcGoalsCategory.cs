using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcGoalsCategory
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public string Description { get; set; } = null!;

    public int Code { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpDatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual ICollection<GrcGoal> GrcGoals { get; set; } = new List<GrcGoal>();
}
