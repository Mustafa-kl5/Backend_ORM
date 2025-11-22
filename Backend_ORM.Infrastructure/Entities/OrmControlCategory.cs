using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmControlCategory
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public string? Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual ICollection<OrmControlCategoryElement> OrmControlCategoryElements { get; set; } = new List<OrmControlCategoryElement>();
}
