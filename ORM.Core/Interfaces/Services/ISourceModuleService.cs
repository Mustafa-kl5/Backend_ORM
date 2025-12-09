using ORM.Core.DTOs.ActivityLog;

namespace ORM.Core.Interfaces.Services;

public interface ISourceModuleService
{
    Task<SourceModuleDto?> GetByIdAsync(int id);
    Task<SourceModuleDto?> GetByCodeAsync(int sourceSystemId, string moduleCode);
    Task<List<SourceModuleDto>> GetBySystemIdAsync(int sourceSystemId);
    Task<List<SourceModuleDto>> GetAllActiveAsync();
    Task<int> CreateAsync(CreateSourceModuleDto dto);
    Task<bool> UpdateAsync(int id, UpdateSourceModuleDto dto);
    Task<bool> ActivateAsync(int id);
    Task<bool> DeactivateAsync(int id);
}
