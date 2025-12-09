using ORM.Core.DTOs.User;

namespace ORM.Core.Interfaces.Services;

/// <summary>
/// Service for managing user context/state
/// </summary>
public interface IUserContextService
{
    /// <summary>
    /// Get full user context including roles, authorities, departments, branches, divisions
    /// </summary>
    Task<UserContextDto?> GetUserContextAsync(int userId);
}
