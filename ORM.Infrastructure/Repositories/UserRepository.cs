using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ORMContext _context;

    public UserRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<GrcUser?> GetByIdAsync(int userId)
    {
        return await _context.GrcUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public async Task<GrcUser?> GetByLoginAsync(string userLogin)
    {
        return await _context.GrcUsers
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserLogin == userLogin);
    }

    public async Task<bool> UpdateAsync(GrcUser user)
    {
        _context.GrcUsers.Update(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateRefreshTokenAsync(int userId, string refreshToken, DateTime expiration)
    {
        var user = await _context.GrcUsers.FindAsync(userId);
        if (user == null) return false;

        // Using ResetPasswordToken field to store refresh token
        // You may want to add a dedicated RefreshToken column to the database
        user.ResetPasswordToken = refreshToken;
        user.LastUpdateDate = DateTime.UtcNow;

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> ClearRefreshTokenAsync(int userId)
    {
        var user = await _context.GrcUsers.FindAsync(userId);
        if (user == null) return false;

        user.ResetPasswordToken = null;
        user.LastUpdateDate = DateTime.UtcNow;

        return await _context.SaveChangesAsync() > 0;
    }
}
