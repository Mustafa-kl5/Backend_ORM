using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

[ApiController]
[Route("api/rba/controls")]
public class RbaControlController : ControllerBase
{
    private readonly IRbaControlService _controlService;

    public RbaControlController(IRbaControlService controlService)
    {
        _controlService = controlService;
    }

    /// <summary>
    /// Get all control assessments for a specific process risk
    /// GET /api/rba/controls/processes/{processId}/risks/{riskId}?accountId=1
    /// </summary>
    [HttpGet("processes/{processId}/risks/{riskId}")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ControlAssessmentDto>>>> GetProcessRiskControls(
        [FromRoute] int processId,
        [FromRoute] int riskId,
        [FromQuery] int accountId)
    {
        try
        {
            var controls = await _controlService.GetProcessRiskControlsAsync(accountId, processId, riskId);
            return Ok(ApiResponse<IEnumerable<ControlAssessmentDto>>.SuccessResponse(
                controls, 
                $"Control assessments for process {processId}, risk {riskId} retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ControlAssessmentDto>>.ErrorResponse(
                "Failed to retrieve control assessments", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get specific control assessment by ID
    /// GET /api/rba/controls/{assessmentId}?accountId=1
    /// </summary>
    [HttpGet("{assessmentId}")]
    public async Task<ActionResult<ApiResponse<ControlAssessmentDto>>> GetControlAssessmentById(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId)
    {
        try
        {
            var control = await _controlService.GetControlAssessmentByIdAsync(accountId, assessmentId);
            
            if (control == null)
                return NotFound(ApiResponse<ControlAssessmentDto>.ErrorResponse(
                    "Control assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<ControlAssessmentDto>.SuccessResponse(
                control, 
                "Control assessment retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<ControlAssessmentDto>.ErrorResponse(
                "Failed to retrieve control assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Create new control assessment
    /// POST /api/rba/controls/assessments
    /// </summary>
    [HttpPost("assessments")]
    public async Task<ActionResult<ApiResponse<object>>> CreateControlAssessment([FromBody] ControlAssessmentCreateDto dto)
    {
        try
        {
            var rbaControlId = await _controlService.CreateControlAssessmentAsync(dto);
            
            return CreatedAtAction(
                nameof(GetControlAssessmentById),
                new { assessmentId = rbaControlId, accountId = dto.AccountId },
                ApiResponse<object>.SuccessResponse(
                    new
                    {
                        rbaControlId,
                        residualRiskExposure = dto.ResidualRiskExposure,
                        residualRiskQuadrantId = dto.ResidualRiskQuadrantId
                    },
                    "Control assessment created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to create control assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Update control assessment
    /// PUT /api/rba/controls/{assessmentId}?accountId=1
    /// </summary>
    [HttpPut("{assessmentId}")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateControlAssessment(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId,
        [FromBody] ControlAssessmentUpdateDto dto)
    {
        try
        {
            var updated = await _controlService.UpdateControlAssessmentAsync(assessmentId, dto);
            
            if (!updated)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Control assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { assessmentId }, 
                "Control assessment updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to update control assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Delete control assessment
    /// DELETE /api/rba/controls/{assessmentId}?accountId=1
    /// </summary>
    [HttpDelete("{assessmentId}")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteControlAssessment(
        [FromRoute] int assessmentId,
        [FromQuery] int accountId)
    {
        try
        {
            var deleted = await _controlService.DeleteControlAssessmentAsync(accountId, assessmentId);
            
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Control assessment not found", 
                    $"No assessment found with ID {assessmentId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { assessmentId }, 
                "Control assessment deleted successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to delete control assessment", 
                ex.Message));
        }
    }
}
