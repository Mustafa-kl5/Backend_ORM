using Backend_ORM.Infrastructure.Entities;

namespace Backend_ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository interface for Process Detail (OrmProcessDetail) operations
/// </summary>
public interface IProcessDetailRepository
{
    Task<(List<OrmProcessDetail> processDetails, int totalCount)> GetProcessDetailsAsync(
        int accountId,
        int? subjectId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir);

    Task<OrmProcessDetail?> GetProcessDetailByIdAsync(int accountId, int id);

    Task<bool> ProcessDetailExistsAsync(int accountId, int subjectId, string description, int? excludeId = null);

    Task<int> CreateProcessDetailAsync(OrmProcessDetail processDetail);

    Task<bool> UpdateProcessDetailAsync(OrmProcessDetail processDetail);

    Task<bool> DeleteProcessDetailAsync(int accountId, int id);
}
