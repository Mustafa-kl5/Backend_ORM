using ORM.Core.DTOs.Common;

namespace ORM.Core.Interfaces.Services;

public interface ICommonService
{
    Task<List<ExtensionDto>> GetExtensionsAsync();
}
