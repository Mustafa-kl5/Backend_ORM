using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class BcmResourceDetailsControl
{
    public int Id { get; set; }

    public int ControlElementId { get; set; }

    public int ResourceDetailsId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual OrmControlCategoryElement ControlElement { get; set; } = null!;

    public virtual BcmResourceDetail ResourceDetails { get; set; } = null!;
}
