using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmriskGoal
{
    public int Id { get; set; }

    public int RiskDetailsId { get; set; }

    public int? GoalId { get; set; }

    public int? GoalDetailsId { get; set; }

    public int CreatedBy { get; set; }

    public string? CreationDate { get; set; }
}
