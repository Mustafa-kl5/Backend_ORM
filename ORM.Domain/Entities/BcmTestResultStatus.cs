using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmTestResultStatus
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<BcmBiaPlanImpactAnalysisTest> BcmBiaPlanImpactAnalysisTests { get; set; } = new List<BcmBiaPlanImpactAnalysisTest>();

    public virtual ICollection<BcmBiaPlanProcessRiskControlTest> BcmBiaPlanProcessRiskControlTests { get; set; } = new List<BcmBiaPlanProcessRiskControlTest>();

    public virtual ICollection<BcmBiaPlanProcessTest> BcmBiaPlanProcessTests { get; set; } = new List<BcmBiaPlanProcessTest>();

    public virtual ICollection<BcmBiaPlanRecoveryTest> BcmBiaPlanRecoveryTests { get; set; } = new List<BcmBiaPlanRecoveryTest>();

    public virtual ICollection<BcmBiaPlanResourceDetailsTest> BcmBiaPlanResourceDetailsTests { get; set; } = new List<BcmBiaPlanResourceDetailsTest>();

    public virtual ICollection<BcmBiaPlanResourceTest> BcmBiaPlanResourceTests { get; set; } = new List<BcmBiaPlanResourceTest>();

    public virtual ICollection<BcmBiaPlanSchedule> BcmBiaPlanSchedules { get; set; } = new List<BcmBiaPlanSchedule>();

    public virtual ICollection<BcmBiaPlanTest> BcmBiaPlanTests { get; set; } = new List<BcmBiaPlanTest>();
}
