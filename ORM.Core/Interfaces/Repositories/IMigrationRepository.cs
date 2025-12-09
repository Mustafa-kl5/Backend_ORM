using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository for migration operations
/// </summary>
public interface IMigrationRepository
{
    /// <summary>
    /// Get all users for migration
    /// </summary>
    Task<List<GrcUser>> GetAllUsersAsync();

    /// <summary>
    /// Save changes after migration
    /// </summary>
    Task SaveChangesAsync();
}
