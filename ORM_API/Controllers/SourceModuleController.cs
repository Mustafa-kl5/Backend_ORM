using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

[Authorize]
public class SourceModuleController : BaseController
{
    private readonly ISourceModuleService _sourceModuleService;

    public SourceModuleController(ISourceModuleService sourceModuleService)
    {
        _sourceModuleService = sourceModuleService;
    }

    /// <summary>
    /// Get all active source modules
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllActive()
    {
        var modules = await _sourceModuleService.GetAllActiveAsync();
        return Success(modules);
    }

    /// <summary>
    /// Get source module by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var module = await _sourceModuleService.GetByIdAsync(id);
        if (module == null)
            return NotFoundResponse("Source module not found");

        return Success(module);
    }

    /// <summary>
    /// Get source modules by system ID
    /// </summary>
    [HttpGet("system/{systemId}")]
    public async Task<IActionResult> GetBySystemId(int systemId)
    {
        var modules = await _sourceModuleService.GetBySystemIdAsync(systemId);
        return Success(modules);
    }

    /// <summary>
    /// Get source module by system ID and module code
    /// </summary>
    [HttpGet("system/{systemId}/code/{moduleCode}")]
    public async Task<IActionResult> GetByCode(int systemId, string moduleCode)
    {
        var module = await _sourceModuleService.GetByCodeAsync(systemId, moduleCode);
        if (module == null)
            return NotFoundResponse("Source module not found");

        return Success(module);
    }

    /// <summary>
    /// Create a new source module
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSourceModuleDto dto)
    {
        var moduleId = await _sourceModuleService.CreateAsync(dto);
        return Success(new { SourceModuleId = moduleId }, "Source module created successfully", 201);
    }

    /// <summary>
    /// Update source module
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSourceModuleDto dto)
    {
        var updated = await _sourceModuleService.UpdateAsync(id, dto);
        return Success(updated, "Source module updated successfully");
    }

    /// <summary>
    /// Activate source module
    /// </summary>
    [HttpPatch("{id}/activate")]
    public async Task<IActionResult> Activate(int id)
    {
        var activated = await _sourceModuleService.ActivateAsync(id);
        return Success(activated, "Source module activated successfully");
    }

    /// <summary>
    /// Deactivate source module
    /// </summary>
    [HttpPatch("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var deactivated = await _sourceModuleService.DeactivateAsync(id);
        return Success(deactivated, "Source module deactivated successfully");
    }
}
