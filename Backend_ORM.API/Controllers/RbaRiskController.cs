using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

[ApiController]
[Route("api/rba/risks")]
public class RbaRiskController : ControllerBase
{
    private readonly IRbaRiskService _riskService;

    public RbaRiskController(IRbaRiskService riskService)
    {
        _riskService = riskService;
    }

    /// <summary>
    /// Get all risk categories for an account
    /// GET /api/rba/risks/categories?accountId=1
    /// </summary>
    [HttpGet("categories")]
    public async Task<ActionResult<ApiResponse<IEnumerable<CategoryDto>>>> GetCategories([FromQuery] int accountId)
    {
        try
        {
            var categories = await _riskService.GetCategoriesAsync(accountId);
            return Ok(ApiResponse<IEnumerable<CategoryDto>>.SuccessResponse(
                categories, 
                "Risk categories retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<CategoryDto>>.ErrorResponse(
                "Failed to retrieve risk categories", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get risk elements for a specific category
    /// GET /api/rba/risks/categories/{categoryId}/risks?accountId=1
    /// </summary>
    [HttpGet("categories/{categoryId}/risks")]
    public async Task<ActionResult<ApiResponse<IEnumerable<RiskCategoryDto>>>> GetRisksByCategory(
        [FromRoute] int categoryId,
        [FromQuery] int accountId)
    {
        try
        {
            var risks = await _riskService.GetRiskCategoriesByCategoryAsync(accountId, categoryId);
            return Ok(ApiResponse<IEnumerable<RiskCategoryDto>>.SuccessResponse(
                risks, 
                "Risk elements retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<RiskCategoryDto>>.ErrorResponse(
                "Failed to retrieve risk elements", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get risk assessment for a specific risk element
    /// GET /api/rba/risks/{riskElementId}/assessment?accountId=1
    /// </summary>
    [HttpGet("{riskElementId}/assessment")]
    public async Task<ActionResult<ApiResponse<RiskAssessmentDto>>> GetRiskAssessment(
        [FromRoute] int riskElementId,
        [FromQuery] int accountId)
    {
        try
        {
            var assessment = await _riskService.GetRiskAssessmentByElementAsync(accountId, riskElementId);
            
            if (assessment == null)
                return NotFound(ApiResponse<RiskAssessmentDto>.ErrorResponse(
                    "Risk assessment not found", 
                    $"No assessment found for risk element ID {riskElementId}"));

            return Ok(ApiResponse<RiskAssessmentDto>.SuccessResponse(
                assessment, 
                "Risk assessment retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<RiskAssessmentDto>.ErrorResponse(
                "Failed to retrieve risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get all risk assessments for a risk category
    /// GET /api/rba/risks/categories/{riskCategoryId}/assessments?accountId=1
    /// </summary>
    [HttpGet("categories/{riskCategoryId}/assessments")]
    public async Task<ActionResult<ApiResponse<IEnumerable<RiskAssessmentDetailDto>>>> GetRiskAssessmentsByCategory(
        [FromRoute] int riskCategoryId,
        [FromQuery] int accountId)
    {
        try
        {
            var assessments = await _riskService.GetRiskAssessmentsByCategoryAsync(accountId, riskCategoryId);
            return Ok(ApiResponse<IEnumerable<RiskAssessmentDetailDto>>.SuccessResponse(
                assessments, 
                "Risk assessments retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<RiskAssessmentDetailDto>>.ErrorResponse(
                "Failed to retrieve risk assessments", 
                ex.Message));
        }
    }

    /// <summary>
    /// Create new risk assessment
    /// POST /api/rba/risks/assessments
    /// </summary>
    [HttpPost("assessments")]
    public async Task<ActionResult<ApiResponse<object>>> CreateRiskAssessment([FromBody] RiskAssessmentCreateDto dto)
    {
        try
        {
            var rbaId = await _riskService.CreateRiskAssessmentAsync(dto);
            return CreatedAtAction(
                nameof(GetRiskAssessment),
                new { riskElementId = dto.RiskElementId, accountId = dto.AccountId },
                ApiResponse<object>.SuccessResponse(
                    new { rbaId }, 
                    "Risk assessment created successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to create risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Update risk assessment
    /// PUT /api/rba/risks/{riskElementId}/assessment
    /// </summary>
    [HttpPut("{riskElementId}/assessment")]
    public async Task<ActionResult<ApiResponse<object>>> UpdateRiskAssessment(
        [FromRoute] int riskElementId,
        [FromQuery] int accountId,
        [FromBody] RiskAssessmentUpdateDto dto)
    {
        try
        {
            var updated = await _riskService.UpdateRiskAssessmentAsync(riskElementId, dto);
            
            if (!updated)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Risk assessment not found", 
                    $"No assessment found for risk element ID {riskElementId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { riskElementId }, 
                "Risk assessment updated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to update risk assessment", 
                ex.Message));
        }
    }

    /// <summary>
    /// Delete risk assessment
    /// DELETE /api/rba/risks/{riskElementId}/assessment?accountId=1
    /// </summary>
    [HttpDelete("{riskElementId}/assessment")]
    public async Task<ActionResult<ApiResponse<object>>> DeleteRiskAssessment(
        [FromRoute] int riskElementId,
        [FromQuery] int accountId)
    {
        try
        {
            var deleted = await _riskService.DeleteRiskAssessmentAsync(accountId, riskElementId);
            
            if (!deleted)
                return NotFound(ApiResponse<object>.ErrorResponse(
                    "Risk assessment not found", 
                    $"No assessment found for risk element ID {riskElementId}"));

            return Ok(ApiResponse<object>.SuccessResponse(
                new { riskElementId }, 
                "Risk assessment deleted successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<object>.ErrorResponse(
                "Failed to delete risk assessment", 
                ex.Message));
        }
    }
}
