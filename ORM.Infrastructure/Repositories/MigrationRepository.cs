using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

/// <summary>
/// Repository for migration operations
/// </summary>
public class MigrationRepository : IMigrationRepository
{
    private readonly ORMContext _context;

    public MigrationRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<List<GrcUser>> GetAllUsersAsync()
    {
        return await _context.GrcUsers.ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
