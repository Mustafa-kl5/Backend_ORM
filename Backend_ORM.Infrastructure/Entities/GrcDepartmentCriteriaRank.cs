using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDepartmentCriteriaRank
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int CriteriaId { get; set; }

    public int Value { get; set; }

    public int Rank { get; set; }

    public DateTime RunDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCriterion Criteria { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;
}
