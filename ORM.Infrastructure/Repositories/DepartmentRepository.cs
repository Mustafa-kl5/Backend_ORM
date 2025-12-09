using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ORMContext _context;

    public DepartmentRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<List<GrcDepartment>> GetAllAsync(int accountId)
    {
        return await _context.GrcDepartments
            .Include(d => d.Country)
            .Include(d => d.Sector)
            .Where(d => d.AccountId == accountId)
            .AsNoTracking()
            .OrderBy(d => d.DepartmentName)
            .ToListAsync();
    }

    public async Task<GrcDepartment?> GetByIdAsync(int departmentId, int accountId)
    {
        return await _context.GrcDepartments
            .Include(d => d.Country)
            .Include(d => d.Sector)
            .Where(d => d.DepartmentId == departmentId && d.AccountId == accountId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<GrcDepartment>> GetByCountryAsync(int countryId, int accountId)
    {
        return await _context.GrcDepartments
            .Include(d => d.Country)
            .Include(d => d.Sector)
            .Where(d => d.CountryId == countryId && d.AccountId == accountId)
            .AsNoTracking()
            .OrderBy(d => d.DepartmentName)
            .ToListAsync();
    }

    public async Task<List<GrcDepartment>> GetBySectorAsync(int sectorId, int accountId)
    {
        return await _context.GrcDepartments
            .Include(d => d.Country)
            .Include(d => d.Sector)
            .Where(d => d.SectorId == sectorId && d.AccountId == accountId)
            .AsNoTracking()
            .OrderBy(d => d.DepartmentName)
            .ToListAsync();
    }

    public async Task<GrcDepartment> CreateAsync(GrcDepartment department)
    {
        _context.GrcDepartments.Add(department);
        await _context.SaveChangesAsync();
        
        // Reload with navigation properties
        return await GetByIdAsync(department.DepartmentId, department.AccountId) ?? department;
    }

    public async Task<GrcDepartment> UpdateAsync(GrcDepartment department)
    {
        _context.GrcDepartments.Update(department);
        await _context.SaveChangesAsync();
        
        // Reload with navigation properties
        return await GetByIdAsync(department.DepartmentId, department.AccountId) ?? department;
    }

    public async Task<bool> DeleteAsync(int departmentId, int accountId)
    {
        var department = await _context.GrcDepartments
            .Where(d => d.DepartmentId == departmentId && d.AccountId == accountId)
            .FirstOrDefaultAsync();

        if (department == null)
            return false;

        _context.GrcDepartments.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string departmentName, int accountId, int? excludeDepartmentId = null)
    {
        var query = _context.GrcDepartments
            .Where(d => d.AccountId == accountId &&
                       d.DepartmentName.ToLower().Trim() == departmentName.ToLower().Trim());

        if (excludeDepartmentId.HasValue)
        {
            query = query.Where(d => d.DepartmentId != excludeDepartmentId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<bool> ExistsAsync(string departmentName, string departmentCode, int accountId, int? excludeDepartmentId = null)
    {
        var query = _context.GrcDepartments
            .Where(d => d.AccountId == accountId &&
                       d.DepartmentName.ToLower().Trim() == departmentName.ToLower().Trim() &&
                       d.DepartmentCode != null &&
                       d.DepartmentCode.ToLower().Trim() == departmentCode.ToLower().Trim());

        if (excludeDepartmentId.HasValue)
        {
            query = query.Where(d => d.DepartmentId != excludeDepartmentId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<bool> CodeExistsAsync(string departmentCode, int accountId, int? excludeDepartmentId = null)
    {
        var query = _context.GrcDepartments
            .Where(d => d.AccountId == accountId &&
                       d.DepartmentCode != null &&
                       d.DepartmentCode.ToLower().Trim() == departmentCode.ToLower().Trim());

        if (excludeDepartmentId.HasValue)
        {
            query = query.Where(d => d.DepartmentId != excludeDepartmentId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<bool> EmailExistsAsync(string email, int accountId, int? excludeDepartmentId = null)
    {
        var normalizedEmail = email.ToLower().Trim();
        
        var query = _context.GrcDepartments
            .Where(d => d.AccountId == accountId &&
                       (d.DepartmentEmail1.ToLower().Trim() == normalizedEmail ||
                        (d.DepartmentEmail2 != null && d.DepartmentEmail2.ToLower().Trim() == normalizedEmail)));

        if (excludeDepartmentId.HasValue)
        {
            query = query.Where(d => d.DepartmentId != excludeDepartmentId.Value);
        }

        return await query.AnyAsync();
    }
}
