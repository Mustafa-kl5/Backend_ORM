namespace Backend_ORM.Core.DTOs.RBA;

public class ProcessRiskSummaryDto
{
    public int ProcessDetailsId { get; set; }
    public string ProcessType { get; set; } = string.Empty;
    public string ProcessCategory { get; set; } = string.Empty;
    public string ProcessSubject { get; set; } = string.Empty;
    public string ProcessDetails { get; set; } = string.Empty;
    public string? MaxRiskInherentRiskScore { get; set; }
    public int? MaxRiskInherentCode { get; set; }
    public double? AvgInherentRiskValue { get; set; }
}

public class ProcessRiskAssessmentDto
{
    public int RiskId { get; set; }
    public string RiskDesc { get; set; } = string.Empty;
    public int ProcessDetailsId { get; set; }
    public int RiskProcessLinkId { get; set; }
    public int? ProcessRbaId { get; set; }
    public int? RiskWeight { get; set; }
    public int? OccWeight { get; set; }
    public int? InherentRiskValue { get; set; }
    public string? InherentScore { get; set; }
    public int? InherentScoreCode { get; set; }
    public int? FinancialImpact { get; set; }
    public int? GrossLossExpectation { get; set; }
    public string? Comments { get; set; }
}

public class ProcessRiskAssessmentCreateDto
{
    public int AccountId { get; set; }
    public int? ProcessDetailId { get; set; }
    public int RiskProcessLinkId { get; set; }
    public int RiskElementId { get; set; }
    public int RiskImpactId { get; set; }
    public int RiskOccurenceId { get; set; }
    public int InherentRiskScore { get; set; }
    public int InherentRiskValue { get; set; }
    public string? Comments { get; set; }
    public int? FinancialImpact { get; set; }
    public int? GrossLossExpectation { get; set; }
    public int CreatedBy { get; set; }
}

public class ProcessRiskAssessmentUpdateDto
{
    public int RiskImpactId { get; set; }
    public int RiskOccurenceId { get; set; }
    public int InherentRiskScore { get; set; }
    public int InherentRiskValue { get; set; }
    public string? Comments { get; set; }
    public int? FinancialImpact { get; set; }
    public int? GrossLossExpectation { get; set; }
    public int? RiskProcessLinkId { get; set; }
    public int LastUpdatedBy { get; set; }
}
