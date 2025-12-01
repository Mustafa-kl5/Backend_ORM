using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCriterion
{
    public int Id { get; set; }

    public string CriteriaName { get; set; } = null!;

    public int Weight { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int LastUpdatedBy { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public int? Code { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcDepartmentCriteriaRank> GrcDepartmentCriteriaRanks { get; set; } = new List<GrcDepartmentCriteriaRank>();
}
