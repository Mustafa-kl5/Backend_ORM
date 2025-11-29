using Backend_ORM.Core.DTOs.Auth;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for accessing current authenticated user information
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the current authenticated user's ID
    /// </summary>
    int? UserId { get; }

    /// <summary>
    /// Gets the current authenticated user's account ID
    /// </summary>
    int? AccountId { get; }

    /// <summary>
    /// Gets the current authenticated user's name
    /// </summary>
    string? UserName { get; }

    /// <summary>
    /// Gets the current authenticated user's email
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// Indicates if a user is currently authenticated
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the full current user information
    /// </summary>
    CurrentUserDto? CurrentUser { get; }
}
