using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

[ApiController]
[Route("api/rba/processes")]
public class RbaProcessRiskController : ControllerBase
{
    private readonly IRbaProcessRiskService _processRiskService;

    public RbaProcessRiskController(IRbaProcessRiskService processRiskService)
    {
        _processRiskService = processRiskService;
    }

    /// <summary>
    /// Get all processes with maximum risk summary
    /// GET /api/rba/processes?accountId=1
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProcessRiskSummaryDto>>>> GetProcesses([FromQuery] int accountId)
    {
        try
        {
            var processes = await _processRiskService.GetProcessesWithRiskSummaryAsync(accountId);
            return Ok(ApiResponse<IEnumerable<ProcessRiskSummaryDto>>.SuccessResponse(
                processes, 
                "Process risk summary retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ProcessRiskSummaryDto>>.ErrorResponse(
                "Failed to retrieve process risk summary", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get all risks linked to a specific process
    /// GET /api/rba/processes/{processId}/risks?accountId=1
    /// </summary>
    [HttpGet("{processId}/risks")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ProcessRiskAssessmentDto>>>> GetProcessRisks(
        [FromRoute] int processId,
        [FromQuery] int accountId)
    {
        try
        {
            var risks = await _processRiskService.GetProcessRisksAsync(accountId, processId);
            return Ok(ApiResponse<IEnumerable<ProcessRiskAssessmentDto>>.SuccessResponse(
                risks, 
                $"Process risks for process ID {processId} retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ProcessRiskAssessmentDto>>.ErrorResponse(
                "Failed to retrieve process risks", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get specific process risk assessment by ID
    /// GET /api/rba/processes/risks/{assessmentId}?accountId=1
    /// </summary>
    [HttpGet("risks/{assessmentId}")]
    public async Task<ActionResult<ApiResponse<ProcessRiskAssessmentDto>>> GetProcessRiskById(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId)
    {
        try
        {
            var risk = await _processRiskService.GetProcessRiskByIdAsync(accountId, assessmentId);
            
            if (risk == null)
                return NotFound(ApiResponse<ProcessRiskAssessmentDto>.ErrorResponse(
                    "Process risk assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<ProcessRiskAssessmentDto>.SuccessResponse(
                risk, 
                "Process risk assessment retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<ProcessRiskAssessmentDto>.ErrorResponse(
                "Failed to retrieve process risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Create new process risk assessment
    /// POST /api/rba/processes/risks/assessments
    /// </summary>
    [HttpPost("risks/assessments")]
    public async Task<ActionResult<ApiResponse<object>>> CreateProcessRiskAssessment([FromBody] ProcessRiskAssessmentCreateDto dto)
    {
        try
        {
            var rbaProcessId = await _processRiskService.CreateProcessRiskAssessmentAsync(dto);
            
            return CreatedAtAction(
                nameof(GetProcessRiskById),
                new { assessmentId = rbaProcessId, accountId = dto.AccountId },
                ApiResponse<object>.SuccessResponse(
                    new
                    {
                        rbaProcessId,
                        inherentRiskValue = dto.InherentRiskValue,
                        grossLossExpectation = dto.GrossLossExpectation
                    },
                    "Process risk assessment created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to create process risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Update process risk assessment
    /// PUT /api/rba/processes/risks/{assessmentId}?accountId=1
    /// </summary>
    [HttpPut("risks/{assessmentId}")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateProcessRiskAssessment(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId,
        [FromBody] ProcessRiskAssessmentUpdateDto dto)
    {
        try
        {
            var updated = await _processRiskService.UpdateProcessRiskAssessmentAsync(assessmentId, dto);
            
            if (!updated)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Process risk assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { assessmentId }, 
                "Process risk assessment updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to update process risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Update gross loss expectation only (partial update)
    /// PATCH /api/rba/processes/risks/{assessmentId}/gross-loss
    /// </summary>
    [HttpPatch("risks/{assessmentId}/gross-loss")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateGrossLoss(
        [FromRoute] int assessmentId,
        [FromBody] GrossLossUpdateRequest request)
    {
        try
        {
            var updated = await _processRiskService.UpdateGrossLossExpectationAsync(
                assessmentId,
                request.OccurrenceWeight,
                request.UserId);
            
            if (!updated)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Process risk assessment not found or financial impact is missing", 
                    $"No assessment found with ID {assessmentId} or financial impact data is missing"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { assessmentId }, 
                "Gross loss expectation recalculated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to update gross loss expectation", 
                ex.Message));
        }
    }

    /// <summary>
    /// Delete process risk assessment
    /// DELETE /api/rba/processes/risks/{assessmentId}?accountId=1
    /// </summary>
    [HttpDelete("risks/{assessmentId}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteProcessRiskAssessment(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId)
    {
        try
        {
            var deleted = await _processRiskService.DeleteProcessRiskAssessmentAsync(accountId, assessmentId);
            
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Process risk assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { assessmentId }, 
                "Process risk assessment deleted successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to delete process risk assessment", 
                ex.Message));
        }
    }
}

public class GrossLossUpdateRequest
{
    public int OccurrenceWeight { get; set; }
    public int UserId { get; set; }
}
