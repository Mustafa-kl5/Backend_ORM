using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class UserContextRepository : IUserContextRepository
{
    private readonly ORMContext _context;

    public UserContextRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<GrcUser?> GetUserWithDetailsAsync(int userId)
    {
        return await _context.GrcUsers
            .Include(u => u.DepDepartment)
            .Include(u => u.Branch)
            .Include(u => u.Division)
            .Include(u => u.JobTitle)
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<List<UserBranch>> GetUserBranchesAsync(int userId)
    {
        return await _context.UserBranches
            .Include(ub => ub.Branch)
            .Where(ub => ub.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<GrcUserDepartment>> GetUserDepartmentsAsync(int userId)
    {
        return await _context.GrcUserDepartments
            .Include(ud => ud.Department)
            .Where(ud => ud.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<UserDivision>> GetUserDivisionsAsync(int userId)
    {
        return await _context.UserDivisions
            .Include(ud => ud.Division)
            .Where(ud => ud.UserId == userId)
            .ToListAsync();
    }

    public async Task<List<OrmRoleUser>> GetUserRolesAsync(int userId)
    {
        return await _context.OrmRoleUsers
            .Include(ru => ru.Role)
            .Where(ru => ru.UserId == userId)
            .ToListAsync();
    }
}
