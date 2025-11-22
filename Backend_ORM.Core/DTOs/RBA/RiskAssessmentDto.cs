namespace Backend_ORM.Core.DTOs.RBA;

public class RiskAssessmentDto
{
    public int RiskId { get; set; }
    public int RiskCategoryId { get; set; }
    public string RiskDescription { get; set; } = string.Empty;
    public int ImpactWeight { get; set; }
    public int OccWeight { get; set; }
    public int InherentRiskValue { get; set; }
    public string InherentDesc { get; set; } = string.Empty;
    public int CodeScore { get; set; }
    public string? Comments { get; set; }
}

public class RiskAssessmentDetailDto : RiskAssessmentDto
{
    public string Reference { get; set; } = string.Empty;
    public string? RiskDetails { get; set; }
}

public class RiskAssessmentCreateDto
{
    public int AccountId { get; set; }
    public int RiskCategoryId { get; set; }
    public int RiskElementId { get; set; }
    public int RiskImpactId { get; set; }
    public int RiskOccurenceId { get; set; }
    public int InherentRiskScore { get; set; }
    public int InherentRiskValue { get; set; }
    public string? Comments { get; set; }
    public int CreatedBy { get; set; }
}

public class RiskAssessmentUpdateDto
{
    public int RiskImpactId { get; set; }
    public int RiskOccurenceId { get; set; }
    public int InherentRiskScore { get; set; }
    public int InherentRiskValue { get; set; }
    public string? Comments { get; set; }
    public int LastUpdatedBy { get; set; }
}
