using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface ISourceModuleRepository
{
    Task<SourceModule?> GetByIdAsync(int id);
    Task<SourceModule?> GetByCodeAsync(int sourceSystemId, string moduleCode);
    Task<List<SourceModule>> GetBySystemIdAsync(int sourceSystemId);
    Task<List<SourceModule>> GetAllActiveAsync();
    Task<int> CreateAsync(SourceModule sourceModule);
    Task<bool> UpdateAsync(SourceModule sourceModule);
    Task<bool> ExistsAsync(int sourceSystemId, string moduleCode);
}
