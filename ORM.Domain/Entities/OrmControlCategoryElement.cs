using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmControlCategoryElement
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int ControlCategoryId { get; set; }

    public string? Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual ICollection<BcmResourceDetailsControl> BcmResourceDetailsControls { get; set; } = new List<BcmResourceDetailsControl>();

    public virtual OrmControlCategory ControlCategory { get; set; } = null!;

    public virtual ICollection<OrmProcessControlLink> OrmProcessControlLinks { get; set; } = new List<OrmProcessControlLink>();

    public virtual ICollection<OrmRcsaDueTaskRiskControl> OrmRcsaDueTaskRiskControls { get; set; } = new List<OrmRcsaDueTaskRiskControl>();
}
