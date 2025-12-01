using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class BcmBiaPlanResourceDetailsTest
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BiaPlanResourceTestId { get; set; }

    public int ResourceDetailsId { get; set; }

    public int BiaResourceId { get; set; }

    public int FunctionId { get; set; }

    public int FunctionDetailsId { get; set; }

    public int RtoPeriodId { get; set; }

    public int RpoPeriodId { get; set; }

    public int RtoDucration { get; set; }

    public int RpoDuration { get; set; }

    public string? RtoRecoveryStrategy { get; set; }

    public string? RpoBackupStrategy { get; set; }

    public int RtoPeriodTestId { get; set; }

    public int RpoPeriodTestId { get; set; }

    public int RtoDucrationTest { get; set; }

    public int RpoDurationTest { get; set; }

    public string? RtoRecoveryStrategyTest { get; set; }

    public string? RpoBackupStrategyTest { get; set; }

    public int TestResultId { get; set; }

    public string TestResult { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual BcmBiaPlanResourceTest BiaPlanResourceTest { get; set; } = null!;

    public virtual BcmBiaResource BiaResource { get; set; } = null!;

    public virtual BcmFunction Function { get; set; } = null!;

    public virtual BcmFunctionDetail FunctionDetails { get; set; } = null!;

    public virtual BcmResourceDetail ResourceDetails { get; set; } = null!;

    public virtual BcmPeriod RpoPeriod { get; set; } = null!;

    public virtual BcmPeriod RpoPeriodTest { get; set; } = null!;

    public virtual BcmPeriod RtoPeriod { get; set; } = null!;

    public virtual BcmPeriod RtoPeriodTest { get; set; } = null!;

    public virtual BcmTestResultStatus TestResultNavigation { get; set; } = null!;
}
