using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaDueTaskRiskControl
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int DueAsesmntRiskId { get; set; }

    public int RiskCategoryId { get; set; }

    public int RiskControlElementId { get; set; }

    public int? ControlDesignId { get; set; }

    public int? ControlEffectScore { get; set; }

    public int? InherentRiskScoreId { get; set; }

    public int? ResidualRiskScoreId { get; set; }

    public int? ResidualRiskValue { get; set; }

    public bool? DepartmentCheckerStatus { get; set; }

    public int? RiskOfficerStatusId { get; set; }

    public bool? RiskOfficerCheckerApprove { get; set; }

    public string? Comments { get; set; }

    public string? UserFeedback { get; set; }

    public string? AttachFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? DepartmentMakerComnt { get; set; }

    public int? DepMakerId { get; set; }

    public int? DepcheckerId { get; set; }

    public int? CompMakerId { get; set; }

    public int? CompCheckerId { get; set; }

    public int? RiskApetite { get; set; }

    public string? RiskApetiteComment { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcUser? CompChecker { get; set; }

    public virtual GrcUser? CompMaker { get; set; }

    public virtual OrmControlDesignEffective? ControlDesign { get; set; }

    public virtual OrmControlEffectScore? ControlEffectScoreNavigation { get; set; }

    public virtual GrcUser? DepMaker { get; set; }

    public virtual GrcUser? Depchecker { get; set; }

    public virtual OrmRcsaDueAsesmntRisk DueAsesmntRisk { get; set; } = null!;

    public virtual OrmInherentRiskScore? InherentRiskScore { get; set; }

    public virtual ICollection<OrmActionMonitor> OrmActionMonitors { get; set; } = new List<OrmActionMonitor>();

    public virtual ICollection<OrmRcsaquestioniareAnswer> OrmRcsaquestioniareAnswers { get; set; } = new List<OrmRcsaquestioniareAnswer>();

    public virtual ICollection<OrmRcsataskRiskControlAttachment> OrmRcsataskRiskControlAttachments { get; set; } = new List<OrmRcsataskRiskControlAttachment>();

    public virtual OrmResidualRiskExposure? ResidualRiskScore { get; set; }

    public virtual OrmRiskElement RiskCategory { get; set; } = null!;

    public virtual OrmControlCategoryElement RiskControlElement { get; set; } = null!;

    public virtual OrmRcsaofficerStatus? RiskOfficerStatus { get; set; }
}
