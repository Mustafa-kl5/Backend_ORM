using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

[Authorize]
public class SourceSystemController : BaseController
{
    private readonly ISourceSystemService _sourceSystemService;

    public SourceSystemController(ISourceSystemService sourceSystemService)
    {
        _sourceSystemService = sourceSystemService;
    }

    /// <summary>
    /// Get all source systems
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] bool activeOnly = false)
    {
        var systems = activeOnly 
            ? await _sourceSystemService.GetAllActiveAsync()
            : await _sourceSystemService.GetAllAsync();
        
        return Success(systems);
    }

    /// <summary>
    /// Get source system by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var system = await _sourceSystemService.GetByIdAsync(id);
        if (system == null)
            return NotFoundResponse("Source system not found");

        return Success(system);
    }

    /// <summary>
    /// Get source system by code
    /// </summary>
    [HttpGet("code/{systemCode}")]
    public async Task<IActionResult> GetByCode(string systemCode)
    {
        var system = await _sourceSystemService.GetByCodeAsync(systemCode);
        if (system == null)
            return NotFoundResponse("Source system not found");

        return Success(system);
    }

    /// <summary>
    /// Create a new source system
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSourceSystemDto dto)
    {
        var systemId = await _sourceSystemService.CreateAsync(dto);
        return Success(new { SourceSystemId = systemId }, "Source system created successfully", 201);
    }

    /// <summary>
    /// Update source system
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateSourceSystemDto dto)
    {
        var updated = await _sourceSystemService.UpdateAsync(id, dto);
        return Success(updated, "Source system updated successfully");
    }

    /// <summary>
    /// Activate source system
    /// </summary>
    [HttpPatch("{id}/activate")]
    public async Task<IActionResult> Activate(int id)
    {
        var activated = await _sourceSystemService.ActivateAsync(id);
        return Success(activated, "Source system activated successfully");
    }

    /// <summary>
    /// Deactivate source system
    /// </summary>
    [HttpPatch("{id}/deactivate")]
    public async Task<IActionResult> Deactivate(int id)
    {
        var deactivated = await _sourceSystemService.DeactivateAsync(id);
        return Success(deactivated, "Source system deactivated successfully");
    }
}
