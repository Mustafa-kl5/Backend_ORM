using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class RccmCmType
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public string TypeCode { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();
}
