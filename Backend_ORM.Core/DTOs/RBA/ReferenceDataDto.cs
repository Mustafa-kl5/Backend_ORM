namespace Backend_ORM.Core.DTOs.RBA;

public class ImpactLevelDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int? FinancialImpact { get; set; }
}

public class OccurrenceLevelDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Weight { get; set; }
    public int? Multiplier { get; set; }
}

public class InherentRiskScoreDto
{
    public int Id { get; set; }
    public int Code { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UpperValue { get; set; }
}

public class ControlEffectivenessLevelDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UpperValue { get; set; }
}
