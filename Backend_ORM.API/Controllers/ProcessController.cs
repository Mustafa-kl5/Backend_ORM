using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// Controller for Process operations
/// Handles HTTP requests for the 4-level process hierarchy - Level 2
/// </summary>
[ApiController]
[Route("api/processes")]
public class ProcessController : ControllerBase
{
    private readonly IProcessService _service;
    private readonly ILogger<ProcessController> _logger;

    // TODO: Replace with actual authentication
    private const int DEFAULT_ACCOUNT_ID = 1;
    private const int DEFAULT_USER_ID = 1;

    public ProcessController(
        IProcessService service,
        ILogger<ProcessController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all processes with optional filter by process type
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetProcesses(
        [FromQuery] int? processTypeId = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "description",
        [FromQuery] string sortDir = "ASC")
    {
        try
        {
            var result = await _service.GetProcessesAsync(
                DEFAULT_ACCOUNT_ID,
                processTypeId,
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
            _logger.LogError(ex, "Error in GetProcesses");
            return StatusCode(500, "An error occurred while retrieving processes");
        }
    }

    /// <summary>
    /// Get a specific process by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProcessById(int id)
    {
        try
        {
            var result = await _service.GetProcessByIdAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProcessById for ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the process");
        }
    }

    /// <summary>
    /// Create a new process
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateProcess([FromBody] CreateProcessLevelTwoDto dto)
    {
        try
        {
            var result = await _service.CreateProcessAsync(
                DEFAULT_ACCOUNT_ID,
                DEFAULT_USER_ID,
                dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetProcessById),
                new { id = result.Data?.Id },
                result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateProcess");
            return StatusCode(500, "An error occurred while creating the process");
        }
    }

    /// <summary>
    /// Update an existing process
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProcess(int id, [FromBody] UpdateProcessLevelTwoDto dto)
    {
        try
        {
            var result = await _service.UpdateProcessAsync(
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
            _logger.LogError(ex, "Error in UpdateProcess for ID {Id}", id);
            return StatusCode(500, "An error occurred while updating the process");
        }
    }

    /// <summary>
    /// Delete a process
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProcess(int id)
    {
        try
        {
            var result = await _service.DeleteProcessAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteProcess for ID {Id}", id);
            return StatusCode(500, "An error occurred while deleting the process");
        }
    }
}
