using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CompRootCause
{
    public int Id { get; set; }

    public int CustomerCallId { get; set; }

    public int RecoveryMeanId { get; set; }

    public int? SubRegulationId { get; set; }

    public decimal? RecoveryAmount { get; set; }

    public string CausedBy { get; set; } = null!;

    public DateTime ResolvedDate { get; set; }

    public bool? IsBreach { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? ResolutionSummary { get; set; }

    public int? RejectReasonId { get; set; }

    public bool FinancialEducation { get; set; }

    public int? CurrencyId { get; set; }

    public bool IsDeleted { get; set; }

    public int AccountId { get; set; }

    public int? ComRootTypeId { get; set; }

    public int? Approve { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ComRootCauseType? ComRootType { get; set; }

    public virtual ICollection<CompRootCauseAttachment> CompRootCauseAttachments { get; set; } = new List<CompRootCauseAttachment>();

    public virtual Currency? Currency { get; set; }

    public virtual CompCustomerCall CustomerCall { get; set; } = null!;

    public virtual CompRecoveryMean RecoveryMean { get; set; } = null!;

    public virtual CompRejectReason? RejectReason { get; set; }

    public virtual GrcSubRegulation? SubRegulation { get; set; }
}
