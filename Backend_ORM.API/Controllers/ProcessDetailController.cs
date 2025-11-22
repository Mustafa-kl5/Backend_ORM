using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// Controller for ProcessDetail operations
/// Handles HTTP requests for the 4-level process hierarchy - Level 4
/// </summary>
[ApiController]
[Route("api/processdetails")]
public class ProcessDetailController : ControllerBase
{
    private readonly IProcessDetailService _service;
    private readonly ILogger<ProcessDetailController> _logger;

    // TODO: Replace with actual authentication
    private const int DEFAULT_ACCOUNT_ID = 1;
    private const int DEFAULT_USER_ID = 1;

    public ProcessDetailController(
        IProcessDetailService service,
        ILogger<ProcessDetailController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all process details with optional filter by sub-process
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetProcessDetails(
        [FromQuery] int? subjectId = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string sortBy = "description",
        [FromQuery] string sortDir = "ASC")
    {
        try
        {
            var result = await _service.GetProcessDetailsAsync(
                DEFAULT_ACCOUNT_ID,
                subjectId,
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
            _logger.LogError(ex, "Error in GetProcessDetails");
            return StatusCode(500, "An error occurred while retrieving process details");
        }
    }

    /// <summary>
    /// Get a specific process detail by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProcessDetailById(int id)
    {
        try
        {
            var result = await _service.GetProcessDetailByIdAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProcessDetailById for ID {Id}", id);
            return StatusCode(500, "An error occurred while retrieving the process detail");
        }
    }

    /// <summary>
    /// Create a new process detail
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateProcessDetail([FromBody] CreateProcessDetailDto dto)
    {
        try
        {
            var result = await _service.CreateProcessDetailAsync(
                DEFAULT_ACCOUNT_ID,
                DEFAULT_USER_ID,
                dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction(
                nameof(GetProcessDetailById),
                new { id = result.Data?.Id },
                result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in CreateProcessDetail");
            return StatusCode(500, "An error occurred while creating the process detail");
        }
    }

    /// <summary>
    /// Update an existing process detail
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProcessDetail(int id, [FromBody] UpdateProcessDetailDto dto)
    {
        try
        {
            var result = await _service.UpdateProcessDetailAsync(
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
            _logger.LogError(ex, "Error in UpdateProcessDetail for ID {Id}", id);
            return StatusCode(500, "An error occurred while updating the process detail");
        }
    }

    /// <summary>
    /// Delete a process detail
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProcessDetail(int id)
    {
        try
        {
            var result = await _service.DeleteProcessDetailAsync(DEFAULT_ACCOUNT_ID, id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in DeleteProcessDetail for ID {Id}", id);
            return StatusCode(500, "An error occurred while deleting the process detail");
        }
    }
}
