using Backend_ORM.Infrastructure.Entities;

namespace Backend_ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface for ProcessType operations
/// </summary>
public interface IProcessTypeRepository
{
    Task<(List<OrmProcessType> processTypes, int totalCount)> GetProcessTypesAsync(
        int accountId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir);

    Task<OrmProcessType?> GetProcessTypeByIdAsync(int accountId, int id);

    Task<bool> ProcessTypeExistsAsync(int accountId, string description, int? excludeId = null);

    Task<int> GetNextCodeAsync(int accountId);

    Task<int> CreateProcessTypeAsync(OrmProcessType processType);

    Task<bool> UpdateProcessTypeAsync(OrmProcessType processType);

    Task<bool> DeleteProcessTypeAsync(int accountId, int id);

    Task<bool> HasProcessesAsync(int accountId, int processTypeId);
}
