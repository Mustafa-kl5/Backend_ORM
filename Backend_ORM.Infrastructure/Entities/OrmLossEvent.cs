using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmLossEvent
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int? CategoryId { get; set; }

    public int TypeId { get; set; }

    public int? ProductId { get; set; }

    public int? RecoverySourceId { get; set; }

    public decimal? LossAmmount { get; set; }

    public int? CurrencyLossId { get; set; }

    public decimal? BaseAmmount { get; set; }

    public int? CurrencyBaseId { get; set; }

    public decimal? RecoveryAmmount { get; set; }

    public int? CurrencyRecoveryId { get; set; }

    public int StatusId { get; set; }

    public int CauseOfLossId { get; set; }

    public string Reference { get; set; } = null!;

    public string? LongDescription { get; set; }

    public string ShortDescription { get; set; } = null!;

    public DateTime EventDate { get; set; }

    public DateTime DetectionDate { get; set; }

    public DateTime? InvestigationClosedDate { get; set; }

    public string? NonFinancialDetails { get; set; }

    public DateTime? RecoveryDate { get; set; }

    public string? DataInputSource { get; set; }

    public string? PrimaryCause { get; set; }

    public string? ContributingFactors { get; set; }

    public DateTime? DueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? AttachFile { get; set; }

    public string? Location { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmLossEventCategory? Category { get; set; }

    public virtual OrmLossEventCauseOfLoss CauseOfLoss { get; set; } = null!;

    public virtual Currency? CurrencyBase { get; set; }

    public virtual Currency? CurrencyLoss { get; set; }

    public virtual Currency? CurrencyRecovery { get; set; }

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmLossEventControl> OrmLossEventControls { get; set; } = new List<OrmLossEventControl>();

    public virtual ICollection<OrmLossEventKri> OrmLossEventKris { get; set; } = new List<OrmLossEventKri>();

    public virtual ICollection<OrmLossEventProcessBusinessLine> OrmLossEventProcessBusinessLines { get; set; } = new List<OrmLossEventProcessBusinessLine>();

    public virtual ICollection<OrmLossEventProcess> OrmLossEventProcesses { get; set; } = new List<OrmLossEventProcess>();

    public virtual ICollection<OrmLossEventRisk> OrmLossEventRisks { get; set; } = new List<OrmLossEventRisk>();

    public virtual OrmLossEventProduct? Product { get; set; }

    public virtual OrmLossEventRecoverySource? RecoverySource { get; set; }

    public virtual OrmLossEventStatus Status { get; set; } = null!;

    public virtual OrmLossEventType Type { get; set; } = null!;
}
