using Backend_ORM.Infrastructure.Entities;

namespace Backend_ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface for Process operations
/// </summary>
public interface IProcessRepository
{
    Task<(List<OrmProcess> processes, int totalCount)> GetProcessesAsync(
        int accountId,
        int? processTypeId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir);

    Task<OrmProcess?> GetProcessByIdAsync(int accountId, int id);

    Task<bool> ProcessExistsAsync(int accountId, int processTypeId, string description, int? excludeId = null);

    Task<int> CreateProcessAsync(OrmProcess process);

    Task<bool> UpdateProcessAsync(OrmProcess process);

    Task<bool> DeleteProcessAsync(int accountId, int id);

    Task<bool> HasSubProcessesAsync(int accountId, int processId);
}
