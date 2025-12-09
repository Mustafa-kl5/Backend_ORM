using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface IDepartmentRepository
{
    Task<List<GrcDepartment>> GetAllAsync(int accountId);
    Task<GrcDepartment?> GetByIdAsync(int departmentId, int accountId);
    Task<List<GrcDepartment>> GetByCountryAsync(int countryId, int accountId);
    Task<List<GrcDepartment>> GetBySectorAsync(int sectorId, int accountId);
    Task<GrcDepartment> CreateAsync(GrcDepartment department);
    Task<GrcDepartment> UpdateAsync(GrcDepartment department);
    Task<bool> DeleteAsync(int departmentId, int accountId);
    Task<bool> ExistsAsync(string departmentName, int accountId, int? excludeDepartmentId = null);
    Task<bool> ExistsAsync(string departmentName, string departmentCode, int accountId, int? excludeDepartmentId = null);
    Task<bool> CodeExistsAsync(string departmentCode, int accountId, int? excludeDepartmentId = null);
    Task<bool> EmailExistsAsync(string email, int accountId, int? excludeDepartmentId = null);
}
