using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmActionMonitor
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int? KriEntryId { get; set; }

    public int? Rcsaid { get; set; }

    public int? EventLossId { get; set; }

    public int? DepartmentId { get; set; }

    public int? UserId { get; set; }

    public int? BranchId { get; set; }

    public int? DivisionId { get; set; }

    public int? ProcessDetailId { get; set; }

    public int StatusId { get; set; }

    public int SourceId { get; set; }

    public DateTime? DueDate { get; set; }

    public string? RiskJustification { get; set; }

    public string? Recommendation { get; set; }

    public string? Comments { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? PlanScheduleId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual Division? Division { get; set; }

    public virtual OrmLossEvent? EventLoss { get; set; }

    public virtual OrmKriEntry? KriEntry { get; set; }

    public virtual ICollection<OrmActionMonitorDetail> OrmActionMonitorDetails { get; set; } = new List<OrmActionMonitorDetail>();

    public virtual BcmBiaPlanSchedule? PlanSchedule { get; set; }

    public virtual OrmProcessDetail? ProcessDetail { get; set; }

    public virtual OrmRcsaDueTaskRiskControl? Rcsa { get; set; }

    public virtual OrmSource Source { get; set; } = null!;

    public virtual OrmActionStatus Status { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
