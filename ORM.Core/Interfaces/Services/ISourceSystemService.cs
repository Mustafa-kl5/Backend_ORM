using ORM.Core.DTOs.ActivityLog;

namespace ORM.Core.Interfaces.Services;

public interface ISourceSystemService
{
    Task<SourceSystemDto?> GetByIdAsync(int id);
    Task<SourceSystemDto?> GetByCodeAsync(string systemCode);
    Task<List<SourceSystemDto>> GetAllAsync();
    Task<List<SourceSystemDto>> GetAllActiveAsync();
    Task<int> CreateAsync(CreateSourceSystemDto dto);
    Task<bool> UpdateAsync(int id, UpdateSourceSystemDto dto);
    Task<bool> ActivateAsync(int id);
    Task<bool> DeactivateAsync(int id);
}
