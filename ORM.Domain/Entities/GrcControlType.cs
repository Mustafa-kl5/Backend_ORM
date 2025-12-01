using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcControlType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int? Value { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? AccountId { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual ICollection<GrcControlBusinessUnit> GrcControlBusinessUnits { get; set; } = new List<GrcControlBusinessUnit>();
}
