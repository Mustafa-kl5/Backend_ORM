using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmraCategory
{
    public int Id { get; set; }

    public int Code { get; set; }

    public string Name { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<OrmraElement> OrmraElements { get; set; } = new List<OrmraElement>();
}
