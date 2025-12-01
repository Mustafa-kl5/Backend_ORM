using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmProcessDetail
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int SubjectId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaFuntionProcess> BcmBiaFuntionProcesses { get; set; } = new List<BcmBiaFuntionProcess>();

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmKriProcess> OrmKriProcesses { get; set; } = new List<OrmKriProcess>();

    public virtual ICollection<OrmLossEventProcess> OrmLossEventProcesses { get; set; } = new List<OrmLossEventProcess>();

    public virtual ICollection<OrmProcessBlLink> OrmProcessBlLinks { get; set; } = new List<OrmProcessBlLink>();

    public virtual ICollection<OrmProcessDetailBlwork> OrmProcessDetailBlworks { get; set; } = new List<OrmProcessDetailBlwork>();

    public virtual ICollection<OrmProcessRiskLink> OrmProcessRiskLinks { get; set; } = new List<OrmProcessRiskLink>();

    public virtual ICollection<OrmRbaProcessRiskAsesmnt> OrmRbaProcessRiskAsesmnts { get; set; } = new List<OrmRbaProcessRiskAsesmnt>();

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();

    public virtual ICollection<OrmTemplateProcess> OrmTemplateProcesses { get; set; } = new List<OrmTemplateProcess>();

    public virtual OrmProcessSubject Subject { get; set; } = null!;
}
