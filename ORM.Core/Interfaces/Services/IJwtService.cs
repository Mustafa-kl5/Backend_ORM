using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Services;

public interface IJwtService
{
    string GenerateToken(GrcUser user);
    string GenerateRefreshToken();
    int? ValidateToken(string token);
    int? GetUserIdFromExpiredToken(string token);
}
