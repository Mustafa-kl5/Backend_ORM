using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class AuditLossImpact
{
    public int Id { get; set; }

    public int IssueId { get; set; }

    public int FinancialLossTypeId { get; set; }

    public int? FinancialRecoveryId { get; set; }

    public int? BaseCurrencyId { get; set; }

    public int CurrencyLoss { get; set; }

    public int? RecoveryCurrency { get; set; }

    public decimal? BaseAmount { get; set; }

    public decimal LossAmount { get; set; }

    public decimal? RecoveryAmount { get; set; }

    public DateTime EventDate { get; set; }

    public string? Detailes { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedby { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Currency? BaseCurrency { get; set; }

    public virtual Currency CurrencyLossNavigation { get; set; } = null!;

    public virtual FinancialLossType FinancialLossType { get; set; } = null!;

    public virtual FinancialLossRecoverySource? FinancialRecovery { get; set; }

    public virtual GrcAuditFinding Issue { get; set; } = null!;

    public virtual Currency? RecoveryCurrencyNavigation { get; set; }
}
