using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface ICommonRepository
{
    Task<List<GrcExtention>> GetExtensionsAsync();
}
