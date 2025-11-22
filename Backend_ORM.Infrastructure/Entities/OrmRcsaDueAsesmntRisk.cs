using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaDueAsesmntRisk
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int DueAsesmntDetailId { get; set; }

    public int RiskElementId { get; set; }

    public int InherentRiskId { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmRcsaDueAsesmntDetail DueAsesmntDetail { get; set; } = null!;

    public virtual OrmInherentRiskScore InherentRisk { get; set; } = null!;

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();

    public virtual OrmRiskElement RiskElement { get; set; } = null!;
}
