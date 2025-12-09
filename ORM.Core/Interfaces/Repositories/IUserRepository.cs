using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface IUserRepository
{
    Task<GrcUser?> GetByIdAsync(int userId);
    Task<GrcUser?> GetByLoginAsync(string userLogin);
    Task<bool> UpdateAsync(GrcUser user);
    Task<bool> UpdateRefreshTokenAsync(int userId, string refreshToken, DateTime expiration);
    Task<bool> ClearRefreshTokenAsync(int userId);
}
