using ORM.Core.DTOs.User;

namespace ORM.Core.Interfaces.Services;

/// <summary>
/// Service to access current authenticated user information from anywhere in the application
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the current user's ID from JWT claims
    /// </summary>
    int? UserId { get; }

    /// <summary>
    /// Gets the current user's login name from JWT claims
    /// </summary>
    string? UserLogin { get; }

    /// <summary>
    /// Gets the current user's name from JWT claims
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets the current user's account ID from JWT claims
    /// </summary>
    int? AccountId { get; }

    /// <summary>
    /// Checks if user is authenticated
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the full user context with roles, authorities, branches, departments, divisions
    /// </summary>
    Task<UserContextDto?> GetUserContextAsync();
}
