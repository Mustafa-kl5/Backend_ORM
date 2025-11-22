using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class WblowerCaseClassPosition
{
    public int Id { get; set; }

    public int ClassPositionId { get; set; }

    public int CaseId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual WblowerCase Case { get; set; } = null!;

    public virtual WblowerClassPosition ClassPosition { get; set; } = null!;
}
