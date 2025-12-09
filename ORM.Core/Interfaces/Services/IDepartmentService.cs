using ORM.Core.DTOs.Department;

namespace ORM.Core.Interfaces.Services;

public interface IDepartmentService
{
    Task<List<DepartmentDto>> GetAllAsync();
    Task<DepartmentDto?> GetByIdAsync(int departmentId);
    Task<List<DepartmentDto>> GetByCountryAsync(int countryId);
    Task<List<DepartmentDto>> GetBySectorAsync(int sectorId);
    Task<DepartmentDto> CreateAsync(CreateDepartmentDto dto);
    Task<DepartmentDto> UpdateAsync(int departmentId, UpdateDepartmentDto dto);
    Task<bool> DeleteAsync(int departmentId);
}
