using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmRcsaofficerStatus
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();
}
