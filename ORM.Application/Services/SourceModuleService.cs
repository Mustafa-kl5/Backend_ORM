using ORM.Application.Common.Exceptions;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Services;

public class SourceModuleService : ISourceModuleService
{
    private readonly ISourceModuleRepository _sourceModuleRepository;
    private readonly ISourceSystemRepository _sourceSystemRepository;

    public SourceModuleService(
        ISourceModuleRepository sourceModuleRepository,
        ISourceSystemRepository sourceSystemRepository)
    {
        _sourceModuleRepository = sourceModuleRepository;
        _sourceSystemRepository = sourceSystemRepository;
    }

    public async Task<SourceModuleDto?> GetByIdAsync(int id)
    {
        var module = await _sourceModuleRepository.GetByIdAsync(id);
        return module != null ? MapToDto(module) : null;
    }

    public async Task<SourceModuleDto?> GetByCodeAsync(int sourceSystemId, string moduleCode)
    {
        var module = await _sourceModuleRepository.GetByCodeAsync(sourceSystemId, moduleCode);
        return module != null ? MapToDto(module) : null;
    }

    public async Task<List<SourceModuleDto>> GetBySystemIdAsync(int sourceSystemId)
    {
        var modules = await _sourceModuleRepository.GetBySystemIdAsync(sourceSystemId);
        return modules.Select(MapToDto).ToList();
    }

    public async Task<List<SourceModuleDto>> GetAllActiveAsync()
    {
        var modules = await _sourceModuleRepository.GetAllActiveAsync();
        return modules.Select(MapToDto).ToList();
    }

    public async Task<int> CreateAsync(CreateSourceModuleDto dto)
    {
        // Verify source system exists
        var system = await _sourceSystemRepository.GetByIdAsync(dto.SourceSystemId);
        if (system == null)
        {
            throw new NotFoundException($"Source system with ID {dto.SourceSystemId} not found");
        }

        // Check if module code already exists for this system
        if (await _sourceModuleRepository.ExistsAsync(dto.SourceSystemId, dto.ModuleCode))
        {
            throw new ConflictException($"Source module with code '{dto.ModuleCode}' already exists for this system");
        }

        var module = new SourceModule
        {
            SourceSystemId = dto.SourceSystemId,
            ModuleCode = dto.ModuleCode,
            ModuleName = dto.ModuleName,
            IsActive = true
        };

        return await _sourceModuleRepository.CreateAsync(module);
    }

    public async Task<bool> UpdateAsync(int id, UpdateSourceModuleDto dto)
    {
        var module = await _sourceModuleRepository.GetByIdAsync(id);
        if (module == null)
        {
            throw new NotFoundException($"Source module with ID {id} not found");
        }

        module.ModuleName = dto.ModuleName;
        module.IsActive = dto.IsActive;

        return await _sourceModuleRepository.UpdateAsync(module);
    }

    public async Task<bool> ActivateAsync(int id)
    {
        var module = await _sourceModuleRepository.GetByIdAsync(id);
        if (module == null)
        {
            throw new NotFoundException($"Source module with ID {id} not found");
        }

        module.IsActive = true;
        return await _sourceModuleRepository.UpdateAsync(module);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        var module = await _sourceModuleRepository.GetByIdAsync(id);
        if (module == null)
        {
            throw new NotFoundException($"Source module with ID {id} not found");
        }

        module.IsActive = false;
        return await _sourceModuleRepository.UpdateAsync(module);
    }

    private SourceModuleDto MapToDto(SourceModule module)
    {
        return new SourceModuleDto
        {
            SourceModuleId = module.SourceModuleId,
            SourceSystemId = module.SourceSystemId,
            SourceSystemName = module.SourceSystem?.SystemName ?? string.Empty,
            ModuleCode = module.ModuleCode,
            ModuleName = module.ModuleName,
            IsActive = module.IsActive,
            CreatedOn = module.CreatedOn
        };
    }
}
