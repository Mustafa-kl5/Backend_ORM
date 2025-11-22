using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmResidualRiskExposure
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int UpperValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmProcessControlLink> OrmProcessControlLinks { get; set; } = new List<OrmProcessControlLink>();

    public virtual ICollection<OrmRbaControlAsesmnt> OrmRbaControlAsesmnts { get; set; } = new List<OrmRbaControlAsesmnt>();

    public virtual ICollection<OrmRbaControlProcessControl> OrmRbaControlProcessControls { get; set; } = new List<OrmRbaControlProcessControl>();

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();
}
