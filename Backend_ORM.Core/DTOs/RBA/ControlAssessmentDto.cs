namespace Backend_ORM.Core.DTOs.RBA;

public class ControlAssessmentDto
{
    public int Id { get; set; }
    public string ControlCode { get; set; } = string.Empty;
    public string ControlDescription { get; set; } = string.Empty;
    public int RiskId { get; set; }
    public int? ControlAsse { get; set; }
    public int? ControlDesignEffectId { get; set; }
    public double? ResidualRiskExposure { get; set; }
    public string? ResidualRiskExposureText { get; set; }
    public int? ResidualRiskExposureCode { get; set; }
    public string? ResidualRiskQuadrantText { get; set; }
    public int? ResidualRiskQuadrantCode { get; set; }
    public string? Comments { get; set; }
}

public class ControlAssessmentCreateDto
{
    public int AccountId { get; set; }
    public int ControlProccessRiskId { get; set; }
    public int ControlDesignEffectId { get; set; }
    public int ResidualRiskExposure { get; set; }
    public int ResidualRiskQuadrantId { get; set; }
    public string? Comments { get; set; }
    public int CreatedBy { get; set; }
}

public class ControlAssessmentUpdateDto
{
    public int ControlDesignEffectId { get; set; }
    public int ResidualRiskExposure { get; set; }
    public int ResidualRiskQuadrantId { get; set; }
    public string? Comments { get; set; }
    public int LastUpdatedBy { get; set; }
}
