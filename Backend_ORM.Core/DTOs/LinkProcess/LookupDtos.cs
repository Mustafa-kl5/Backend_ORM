namespace Backend_ORM.Core.DTOs.LinkProcess;

/// <summary>
/// DTO for department lookup
/// </summary>
public class DepartmentLookupDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}

/// <summary>
/// DTO for branch lookup
/// </summary>
public class BranchLookupDto
{
    public int BranchId { get; set; }
    public string BranchCode { get; set; } = null!;
    public string BranchName { get; set; } = null!;
    public string? City { get; set; }
}

/// <summary>
/// DTO for division lookup
/// </summary>
public class DivisionLookupDto
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public int DepartmentId { get; set; }
}

/// <summary>
/// DTO for user lookup
/// </summary>
public class UserLookupDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string UserLogin { get; set; } = null!;
    public string? EmailAddress { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string DisplayName { get; set; } = null!;
}

/// <summary>
/// DTO for adding a business line link
/// </summary>
public class AddBusinessLineDto
{
    public int ProcessDetailsId { get; set; }
    public int Source { get; set; } // 1=Department, 2=Branch, 3=Division, 4=User
    public int EntityId { get; set; }
}

/// <summary>
/// Response DTO after adding a business line
/// </summary>
public class AddBusinessLineResponseDto
{
    public int LinkId { get; set; }
    public string Message { get; set; } = null!;
}

/// <summary>
/// DTO for risk lookup
/// </summary>
public class RiskLookupDto
{
    public int Id { get; set; }
    public int RiskCategoryId { get; set; }
    public string RiskCategoryDescription { get; set; } = null!;
    public string? Code { get; set; }
    public string Description { get; set; } = null!;
    public string? RiskDetails { get; set; }
}

/// <summary>
/// DTO for adding a risk link
/// </summary>
public class AddRiskLinkDto
{
    public int ProcessDetailsId { get; set; }
    public int RiskElementId { get; set; }
    public int? RiskImpactId { get; set; }
    public int? RiskOccurrenceId { get; set; }
}

/// <summary>
/// Response DTO after adding a risk link
/// </summary>
public class AddRiskLinkResponseDto
{
    public int LinkId { get; set; }
    public string Message { get; set; } = null!;
}

/// <summary>
/// DTO for control element lookup
/// </summary>
public class ControlLookupDto
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? ControlCategoryId { get; set; }
    public string? ControlCategoryDescription { get; set; }
}

/// <summary>
/// DTO for adding a control link
/// </summary>
public class AddControlLinkDto
{
    public int ProcessRiskLinkId { get; set; }
    public int ControlElementId { get; set; }
    public int? ControlDesignEffectId { get; set; }
    public int? ResidualRiskExposure { get; set; }
    public int? ResidualRiskQuadrantId { get; set; }
}

/// <summary>
/// Response DTO after adding a control link
/// </summary>
public class AddControlLinkResponseDto
{
    public int LinkId { get; set; }
    public string Message { get; set; } = null!;
}
