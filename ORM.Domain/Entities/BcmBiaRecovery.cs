using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaRecovery
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaFunctionId { get; set; }

    public int RtoPeriodId { get; set; }

    public int RpoPeriodId { get; set; }

    public int? RtoDucration { get; set; }

    public string? RtoBackupStrategy { get; set; }

    public int? RpoDuration { get; set; }

    public string? RpoRecoveryStrategy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaFuntion BiaFunction { get; set; } = null!;

    public virtual BcmPeriod RpoPeriod { get; set; } = null!;

    public virtual BcmPeriod RtoPeriod { get; set; } = null!;
}
