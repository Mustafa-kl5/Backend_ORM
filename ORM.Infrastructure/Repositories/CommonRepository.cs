using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class CommonRepository : ICommonRepository
{
    private readonly ORMContext _context;

    public CommonRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<List<GrcExtention>> GetExtensionsAsync()
    {
        return await _context.GrcExtentions
            .AsNoTracking()
            .ToListAsync();
    }
}
