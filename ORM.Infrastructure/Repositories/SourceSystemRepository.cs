using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class SourceSystemRepository : ISourceSystemRepository
{
    private readonly ORMContext _context;

    public SourceSystemRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<SourceSystem?> GetByIdAsync(int id)
    {
        return await _context.SourceSystems
            .AsNoTracking()
            .Include(s => s.SourceModules)
            .FirstOrDefaultAsync(s => s.SourceSystemId == id);
    }

    public async Task<SourceSystem?> GetByCodeAsync(string systemCode)
    {
        return await _context.SourceSystems
            .AsNoTracking()
            .Include(s => s.SourceModules)
            .FirstOrDefaultAsync(s => s.SystemCode == systemCode);
    }

    public async Task<List<SourceSystem>> GetAllAsync()
    {
        return await _context.SourceSystems
            .AsNoTracking()
            .Include(s => s.SourceModules)
            .OrderBy(s => s.SystemName)
            .ToListAsync();
    }

    public async Task<List<SourceSystem>> GetAllActiveAsync()
    {
        return await _context.SourceSystems
            .AsNoTracking()
            .Where(s => s.IsActive)
            .Include(s => s.SourceModules.Where(m => m.IsActive))
            .OrderBy(s => s.SystemName)
            .ToListAsync();
    }

    public async Task<int> CreateAsync(SourceSystem sourceSystem)
    {
        _context.SourceSystems.Add(sourceSystem);
        await _context.SaveChangesAsync();
        return sourceSystem.SourceSystemId;
    }

    public async Task<bool> UpdateAsync(SourceSystem sourceSystem)
    {
        _context.SourceSystems.Update(sourceSystem);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExistsAsync(string systemCode)
    {
        return await _context.SourceSystems
            .AnyAsync(s => s.SystemCode == systemCode);
    }

    public async Task<int> GetModuleCountAsync(int sourceSystemId)
    {
        return await _context.SourceModules
            .CountAsync(m => m.SourceSystemId == sourceSystemId);
    }
}
