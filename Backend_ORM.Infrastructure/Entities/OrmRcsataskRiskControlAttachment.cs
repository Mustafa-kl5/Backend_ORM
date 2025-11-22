using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsataskRiskControlAttachment
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TaskRiskControlId { get; set; }

    public string? AttachFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmRcsaDueTaskRiskControl TaskRiskControl { get; set; } = null!;
}
