namespace ORM.Core.DTOs.User;

/// <summary>
/// Global user context/state DTO containing all user information
/// </summary>
public class UserContextDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UserLogin { get; set; } = string.Empty;
    public string? EmailAddress { get; set; }

    // Primary Department, Branch, Division (from GrcUser)
    public DepartmentDto? Department { get; set; }
    public BranchDto? Branch { get; set; }
    public DivisionDto? Division { get; set; }

    // Job Title
    public JobTitleDto? JobTitle { get; set; }

    // Multiple Branches (from User_Branch)
    public List<BranchDto> Branches { get; set; } = new();

    // Multiple Departments (from GRC_User_Department)
    public List<DepartmentDto> Departments { get; set; } = new();

    // Multiple Divisions (from User_Division)
    public List<DivisionDto> Divisions { get; set; } = new();

    // IDs
    public int? CountryId { get; set; }
    public int AccountId { get; set; }
    public int? LanguageCode { get; set; }

    // Role (code 1, 2, 3, 99)
    public RoleDto? Role { get; set; }

    // Authorities (code 50, 51, 55, 56)
    public UserAuthoritiesDto Authorities { get; set; } = new();
}

/// <summary>
/// Department information
/// </summary>
public class DepartmentDto
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
}

/// <summary>
/// Branch information
/// </summary>
public class BranchDto
{
    public int BranchId { get; set; }
    public string BranchName { get; set; } = string.Empty;
}

/// <summary>
/// Division information
/// </summary>
public class DivisionDto
{
    public int DivisionId { get; set; }
    public string DivisionName { get; set; } = string.Empty;
}

/// <summary>
/// Job Title information
/// </summary>
public class JobTitleDto
{
    public int JobTitleId { get; set; }
    public string JobTitleName { get; set; } = string.Empty;
}

/// <summary>
/// Role information (code 1, 2, 3, 99)
/// </summary>
public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public int Code { get; set; }
}

/// <summary>
/// User authorities flags (code 50, 51, 55, 56)
/// </summary>
public class UserAuthoritiesDto
{
    /// <summary>
    /// Code 50 - Maker authority
    /// </summary>
    public bool IsMaker { get; set; }

    /// <summary>
    /// Code 51 - Checker authority
    /// </summary>
    public bool IsChecker { get; set; }

    /// <summary>
    /// Code 55 - Admin authority
    /// </summary>
    public bool IsAdmin { get; set; }

    /// <summary>
    /// Code 56 - Manager authority
    /// </summary>
    public bool IsManager { get; set; }
}
