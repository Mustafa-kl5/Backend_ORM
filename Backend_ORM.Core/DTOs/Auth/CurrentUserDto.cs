namespace Backend_ORM.Core.DTOs.Auth;

/// <summary>
/// DTO representing the current authenticated user
/// </summary>
public class CurrentUserDto
{
    /// <summary>
    /// User ID
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// User's display name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// User's login username
    /// </summary>
    public string UserLogin { get; set; } = null!;

    /// <summary>
    /// User's email address
    /// </summary>
    public string? EmailAddress { get; set; }

    /// <summary>
    /// User's account ID
    /// </summary>
    public int AccountId { get; set; }

    /// <summary>
    /// User's department ID
    /// </summary>
    public int? DepartmentId { get; set; }

    /// <summary>
    /// User's branch ID
    /// </summary>
    public int? BranchId { get; set; }

    /// <summary>
    /// User's division ID
    /// </summary>
    public int? DivisionId { get; set; }

    /// <summary>
    /// Indicates if user has admin access
    /// </summary>
    public bool HasAdminAccess { get; set; }

    /// <summary>
    /// Indicates if user's password must be changed on next login
    /// </summary>
    public bool IsPasswordChangeRequired { get; set; }

    /// <summary>
    /// Indicates if user is the default action user
    /// </summary>
    public bool IsDefaultActionUser { get; set; }

    /// <summary>
    /// Indicates if user can approve escalations
    /// </summary>
    public bool CanApproveEscalations { get; set; }

    /// <summary>
    /// Indicates if user has regulatory management access
    /// </summary>
    public bool HasRegulatoryAccess { get; set; }

    /// <summary>
    /// Indicates if user has breach management access
    /// </summary>
    public bool HasBreachManagementAccess { get; set; }

    /// <summary>
    /// Indicates if user has whistleblower management access
    /// </summary>
    public bool HasWhistleblowerAccess { get; set; }

    /// <summary>
    /// Indicates if user can approve staging regulations
    /// </summary>
    public bool CanApproveStagingRegulations { get; set; }

    /// <summary>
    /// Indicates if user has RCMA access
    /// </summary>
    public bool HasRcmaAccess { get; set; }

    /// <summary>
    /// Indicates if user has RCCM access
    /// </summary>
    public bool HasRccmAccess { get; set; }

    /// <summary>
    /// Indicates if user has advisory access
    /// </summary>
    public bool HasAdvisoryAccess { get; set; }

    /// <summary>
    /// User's job title ID
    /// </summary>
    public int? JobTitleId { get; set; }

    /// <summary>
    /// User's preferred language code
    /// </summary>
    public int? LanguageCode { get; set; }
}
