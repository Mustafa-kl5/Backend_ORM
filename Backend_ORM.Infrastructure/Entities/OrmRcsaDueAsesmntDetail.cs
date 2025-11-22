using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaDueAsesmntDetail
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int DueAsesmntId { get; set; }

    public int ProcessDetailId { get; set; }

    public int AssessmentStatusId { get; set; }

    public int? ControlEffecId { get; set; }

    public int? ResidualRiskExposureId { get; set; }

    public int? RiskOfficerStatusId { get; set; }

    public string? RiskDescription { get; set; }

    public string? Recommendation { get; set; }

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual OrmAssessmentStatus AssessmentStatus { get; set; } = null!;

    public virtual OrmControlDesignEffective? ControlEffec { get; set; }

    public virtual OrmRcsaDueAsesmnt DueAsesmnt { get; set; } = null!;

    public virtual ICollection<OrmRcsaDueAsesmntRisk> OrmRcsaDueAsesmntRisks { get; set; } = new List<OrmRcsaDueAsesmntRisk>();

    public virtual OrmProcessDetail ProcessDetail { get; set; } = null!;

    public virtual OrmResidualRiskExposure? ResidualRiskExposure { get; set; }

    public virtual OrmRcsaofficerStatus? RiskOfficerStatus { get; set; }
}
