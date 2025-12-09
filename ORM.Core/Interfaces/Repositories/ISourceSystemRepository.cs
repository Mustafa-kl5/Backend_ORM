using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface ISourceSystemRepository
{
    Task<SourceSystem?> GetByIdAsync(int id);
    Task<SourceSystem?> GetByCodeAsync(string systemCode);
    Task<List<SourceSystem>> GetAllAsync();
    Task<List<SourceSystem>> GetAllActiveAsync();
    Task<int> CreateAsync(SourceSystem sourceSystem);
    Task<bool> UpdateAsync(SourceSystem sourceSystem);
    Task<bool> ExistsAsync(string systemCode);
    Task<int> GetModuleCountAsync(int sourceSystemId);
}
