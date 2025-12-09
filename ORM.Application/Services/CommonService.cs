using ORM.Core.DTOs.Common;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;

namespace ORM.Application.Services;

public class CommonService : ICommonService
{
    private readonly ICommonRepository _commonRepository;

    public CommonService(ICommonRepository commonRepository)
    {
        _commonRepository = commonRepository;
    }

    public async Task<List<ExtensionDto>> GetExtensionsAsync()
    {
        var extensions = await _commonRepository.GetExtensionsAsync();

        // Manually map to DTO without AutoMapper
        var extensionDtos = extensions.Select(e => new ExtensionDto
        {
            Id = e.Id,
            Extention = e.Extention,
            CreatedBy = e.CreatedBy,
            CreationDate = e.CreationDate,
            UpdatedBy = e.UpdatedBy,
            UpdatedDate = e.UpdatedDate
        }).ToList();

        return extensionDtos;
    }
}
