using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class SourceModuleRepository : ISourceModuleRepository
{
    private readonly ORMContext _context;

    public SourceModuleRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<SourceModule?> GetByIdAsync(int id)
    {
        return await _context.SourceModules
            .AsNoTracking()
            .Include(m => m.SourceSystem)
            .FirstOrDefaultAsync(m => m.SourceModuleId == id);
    }

    public async Task<SourceModule?> GetByCodeAsync(int sourceSystemId, string moduleCode)
    {
        return await _context.SourceModules
            .AsNoTracking()
            .Include(m => m.SourceSystem)
            .FirstOrDefaultAsync(m => m.SourceSystemId == sourceSystemId && m.ModuleCode == moduleCode);
    }

    public async Task<List<SourceModule>> GetBySystemIdAsync(int sourceSystemId)
    {
        return await _context.SourceModules
            .AsNoTracking()
            .Include(m => m.SourceSystem)
            .Where(m => m.SourceSystemId == sourceSystemId)
            .OrderBy(m => m.ModuleName)
            .ToListAsync();
    }

    public async Task<List<SourceModule>> GetAllActiveAsync()
    {
        return await _context.SourceModules
            .AsNoTracking()
            .Include(m => m.SourceSystem)
            .Where(m => m.IsActive && m.SourceSystem.IsActive)
            .OrderBy(m => m.SourceSystem.SystemName)
            .ThenBy(m => m.ModuleName)
            .ToListAsync();
    }

    public async Task<int> CreateAsync(SourceModule sourceModule)
    {
        _context.SourceModules.Add(sourceModule);
        await _context.SaveChangesAsync();
        return sourceModule.SourceModuleId;
    }

    public async Task<bool> UpdateAsync(SourceModule sourceModule)
    {
        _context.SourceModules.Update(sourceModule);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExistsAsync(int sourceSystemId, string moduleCode)
    {
        return await _context.SourceModules
            .AnyAsync(m => m.SourceSystemId == sourceSystemId && m.ModuleCode == moduleCode);
    }
}
