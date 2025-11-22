namespace Backend_ORM.Core.DTOs.LinkProcess;

/// <summary>
/// DTO for detailed process information with all links
/// </summary>
public class ProcessDetailDto
{
    public ProcessHierarchyDto ProcessHierarchy { get; set; } = new();
    public List<BusinessLineDto> BusinessLines { get; set; } = new();
    public List<RiskLinkDto> Risks { get; set; } = new();
}

/// <summary>
/// Process hierarchy information
/// </summary>
public class ProcessHierarchyDto
{
    public int ProcessDetailsId { get; set; }
    public int ProcessTypeId { get; set; }
    public string ProcessTypeDescription { get; set; } = string.Empty;
    public int ProcessId { get; set; }
    public string ProcessDescription { get; set; } = string.Empty;
    public int SubjectId { get; set; }
    public string SubjectDescription { get; set; } = string.Empty;
    public string DetailsDescription { get; set; } = string.Empty;
}

/// <summary>
/// Business line link information
/// </summary>
public class BusinessLineDto
{
    public int Id { get; set; }
    public int Source { get; set; } // 1=Department, 2=Branch, 3=Division, 4=User
    public int EntityId { get; set; }
    public string EntityName { get; set; } = string.Empty;
    public bool CanDelete { get; set; } = true;
}

/// <summary>
/// Risk link information with controls
/// </summary>
public class RiskLinkDto
{
    public int Id { get; set; }
    public int RiskCategoryId { get; set; }
    public string RiskCategory { get; set; } = string.Empty;
    public string RiskElement { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int? RiskImpactId { get; set; }
    public int? RiskOccurrenceId { get; set; }
    public int? InherentRiskScore { get; set; }
    public bool CanDelete { get; set; } = true;
    public List<ControlLinkDto> Controls { get; set; } = new();
}

/// <summary>
/// Control link information
/// </summary>
public class ControlLinkDto
{
    public int Id { get; set; }
    public int ControlElementId { get; set; }
    public string ControlElement { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public int? ControlDesignEffectId { get; set; }
    public int? ResidualRiskExposure { get; set; }
    public int? ResidualRiskQuadrantId { get; set; }
    public bool CanDelete { get; set; } = true;
}
