using ORM.Core.DTOs.Migration;

namespace ORM.Core.Interfaces.Services;

/// <summary>
/// Service for data migration operations
/// </summary>
public interface IMigrationService
{
    /// <summary>
    /// Migrate all users - re-encrypt data and reset passwords
    /// </summary>
    Task<MigrationResponseDto> MigrateUsersAsync();
}
