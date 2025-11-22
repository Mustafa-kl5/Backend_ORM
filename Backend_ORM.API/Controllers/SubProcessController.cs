using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// Controller for SubProcess operations
/// Handles HTTP requests for the 4-level process hierarchy - Level 3
/// </summary>
[ApiController]
[Route("api/subprocesses")]
public class SubProcessController : ControllerBase
{
    private readonly ISubProcessService _service;
    private readonly ILogger<SubProcessController> _logger;

    // TODO: Replace with actual authentication
    private const int DEFAULT_ACCOUNT_ID = 1;
    private const int DEFAULT_USER_ID = 1;

    public SubProcessController(
        ISubProcessService service,
        ILogger<SubProcessController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all sub-processes with optional filter by process
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetSubProcesses(
        [FromQuery] int? processId = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "description",
        [FromQuery] string sortDir = "ASC")
    {
        try
        {
            var result = await _service.GetSubProcessesAsync(
                DEFAULT_ACCOUNT_ID,
                processId,
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
            _logger.LogError(ex, "Error in GetSubProcesses");
            return StatusCode(500, "An error occurred while retrieving sub-processes");
        }
    }

    /// <summary>
    /// Get a specific sub-process by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubProcessById(int id)
    {
        try
        {
            var result = await _service.GetSubProcessByIdAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetSubProcessById for ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the sub-process");
        }
    }

    /// <summary>
    /// Create a new sub-process
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateSubProcess([FromBody] CreateSubProcessDto dto)
    {
        try
        {
            var result = await _service.CreateSubProcessAsync(
                DEFAULT_ACCOUNT_ID,
                DEFAULT_USER_ID,
                dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetSubProcessById),
                new { id = result.Data?.Id },
                result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateSubProcess");
            return StatusCode(500, "An error occurred while creating the sub-process");
        }
    }

    /// <summary>
    /// Update an existing sub-process
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubProcess(int id, [FromBody] UpdateSubProcessDto dto)
    {
        try
        {
            var result = await _service.UpdateSubProcessAsync(
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
            _logger.LogError(ex, "Error in UpdateSubProcess for ID {Id}", id);
            return StatusCode(500, "An error occurred while updating the sub-process");
        }
    }

    /// <summary>
    /// Delete a sub-process
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubProcess(int id)
    {
        try
        {
            var result = await _service.DeleteSubProcessAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteSubProcess for ID {Id}", id);
            return StatusCode(500, "An error occurred while deleting the sub-process");
        }
    }
}
