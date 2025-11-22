using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// Controller for ProcessType operations
/// Handles HTTP requests for the 4-level process hierarchy - Level 1
/// </summary>
[ApiController]
[Route("api/processtypes")]
public class ProcessTypeController : ControllerBase
{
    private readonly IProcessTypeService _service;
    private readonly ILogger<ProcessTypeController> _logger;

    // TODO: Replace with actual authentication
    private const int DEFAULT_ACCOUNT_ID = 1;
    private const int DEFAULT_USER_ID = 1;

    public ProcessTypeController(
        IProcessTypeService service,
        ILogger<ProcessTypeController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all process types with pagination and sorting
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetProcessTypes(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "description",
        [FromQuery] string sortDir = "ASC")
    {
        try
        {
            var result = await _service.GetProcessTypesAsync(
                DEFAULT_ACCOUNT_ID,
                pageNumber,
                pageSize,
                sortBy,
                sortDir);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProcessTypes");
            return StatusCode(500, "An error occurred while retrieving process types");
        }
    }

    /// <summary>
    /// Get a specific process type by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProcessTypeById(int id)
    {
        try
        {
            var result = await _service.GetProcessTypeByIdAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProcessTypeById for ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the process type");
        }
    }

    /// <summary>
    /// Create a new process type
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateProcessType([FromBody] CreateProcessTypeDto dto)
    {
        try
        {
            var result = await _service.CreateProcessTypeAsync(
                DEFAULT_ACCOUNT_ID,
                DEFAULT_USER_ID,
                dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetProcessTypeById),
                new { id = result.Data?.Id },
                result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateProcessType");
            return StatusCode(500, "An error occurred while creating the process type");
        }
    }

    /// <summary>
    /// Update an existing process type
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProcessType(int id, [FromBody] UpdateProcessTypeDto dto)
    {
        try
        {
            var result = await _service.UpdateProcessTypeAsync(
                DEFAULT_ACCOUNT_ID,
                DEFAULT_USER_ID,
                id,
                dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in UpdateProcessType for ID {Id}", id);
            return StatusCode(500, "An error occurred while updating the process type");
        }
    }

    /// <summary>
    /// Delete a process type
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProcessType(int id)
    {
        try
        {
            var result = await _service.DeleteProcessTypeAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteProcessType for ID {Id}", id);
            return StatusCode(500, "An error occurred while deleting the process type");
        }
    }
}
