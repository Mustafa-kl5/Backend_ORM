using ORM.Application.Common.Exceptions;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Services;

public class SourceSystemService : ISourceSystemService
{
    private readonly ISourceSystemRepository _sourceSystemRepository;

    public SourceSystemService(ISourceSystemRepository sourceSystemRepository)
    {
        _sourceSystemRepository = sourceSystemRepository;
    }

    public async Task<SourceSystemDto?> GetByIdAsync(int id)
    {
        var system = await _sourceSystemRepository.GetByIdAsync(id);
        return system != null ? MapToDto(system) : null;
    }

    public async Task<SourceSystemDto?> GetByCodeAsync(string systemCode)
    {
        var system = await _sourceSystemRepository.GetByCodeAsync(systemCode);
        return system != null ? MapToDto(system) : null;
    }

    public async Task<List<SourceSystemDto>> GetAllAsync()
    {
        var systems = await _sourceSystemRepository.GetAllAsync();
        return systems.Select(MapToDto).ToList();
    }

    public async Task<List<SourceSystemDto>> GetAllActiveAsync()
    {
        var systems = await _sourceSystemRepository.GetAllActiveAsync();
        return systems.Select(MapToDto).ToList();
    }

    public async Task<int> CreateAsync(CreateSourceSystemDto dto)
    {
        // Check if system code already exists
        if (await _sourceSystemRepository.ExistsAsync(dto.SystemCode))
        {
            throw new ConflictException($"Source system with code '{dto.SystemCode}' already exists");
        }

        var system = new SourceSystem
        {
            SystemCode = dto.SystemCode,
            SystemName = dto.SystemName,
            IsActive = true
        };

        return await _sourceSystemRepository.CreateAsync(system);
    }

    public async Task<bool> UpdateAsync(int id, UpdateSourceSystemDto dto)
    {
        var system = await _sourceSystemRepository.GetByIdAsync(id);
        if (system == null)
        {
            throw new NotFoundException($"Source system with ID {id} not found");
        }

        system.SystemName = dto.SystemName;
        system.IsActive = dto.IsActive;

        return await _sourceSystemRepository.UpdateAsync(system);
    }

    public async Task<bool> ActivateAsync(int id)
    {
        var system = await _sourceSystemRepository.GetByIdAsync(id);
        if (system == null)
        {
            throw new NotFoundException($"Source system with ID {id} not found");
        }

        system.IsActive = true;
        return await _sourceSystemRepository.UpdateAsync(system);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        var system = await _sourceSystemRepository.GetByIdAsync(id);
        if (system == null)
        {
            throw new NotFoundException($"Source system with ID {id} not found");
        }

        system.IsActive = false;
        return await _sourceSystemRepository.UpdateAsync(system);
    }

    private SourceSystemDto MapToDto(SourceSystem system)
    {
        return new SourceSystemDto
        {
            SourceSystemId = system.SourceSystemId,
            SystemCode = system.SystemCode,
            SystemName = system.SystemName,
            IsActive = system.IsActive,
            CreatedOn = system.CreatedOn,
            ModuleCount = system.SourceModules?.Count ?? 0
        };
    }
}
