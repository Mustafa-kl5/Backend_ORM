using Backend_ORM.Core.DTOs;
using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

[ApiController]
[Route("api/rba/reference")]
public class RbaReferenceDataController : ControllerBase
{
    private readonly IRbaReferenceDataService _referenceDataService;

    public RbaReferenceDataController(IRbaReferenceDataService referenceDataService)
    {
        _referenceDataService = referenceDataService;
    }

    /// <summary>
    /// Get all risk impact levels (non-financial)
    /// GET /api/rba/reference/impact-levels?accountId=1
    /// </summary>
    [HttpGet("impact-levels")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ImpactLevelDto>>>> GetImpactLevels([FromQuery] int accountId)
    {
        try
        {
            var levels = await _referenceDataService.GetImpactLevelsAsync(accountId, includeFinancial: false);
            return Ok(ApiResponse<IEnumerable<ImpactLevelDto>>.SuccessResponse(
                levels, 
                "Risk impact levels retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ImpactLevelDto>>.ErrorResponse(
                "Failed to retrieve impact levels", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get impact levels with financial thresholds
    /// GET /api/rba/reference/impact-levels/financial?accountId=1
    /// </summary>
    [HttpGet("impact-levels/financial")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ImpactLevelDto>>>> GetImpactLevelsFinancial([FromQuery] int accountId)
    {
        try
        {
            var levels = await _referenceDataService.GetImpactLevelsAsync(accountId, includeFinancial: true);
            return Ok(ApiResponse<IEnumerable<ImpactLevelDto>>.SuccessResponse(
                levels, 
                "Financial impact levels retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ImpactLevelDto>>.ErrorResponse(
                "Failed to retrieve financial impact levels", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get impact level classification by financial amount
    /// GET /api/rba/reference/impact-levels/by-amount?accountId=1&amount=50000
    /// </summary>
    [HttpGet("impact-levels/by-amount")]
    public async Task<ActionResult<ApiResponse<ImpactLevelDto>>> GetImpactByAmount(
        [FromQuery] int accountId,
        [FromQuery] decimal amount)
    {
        try
        {
            var level = await _referenceDataService.GetImpactByAmountAsync(accountId, amount);
            
            if (level == null)
                return NotFound(ApiResponse<ImpactLevelDto>.ErrorResponse(
                    "No impact level found for the specified amount", 
                    $"Amount {amount:C} does not match any configured impact level thresholds"));

            return Ok(ApiResponse<ImpactLevelDto>.SuccessResponse(
                level, 
                $"Impact level for amount {amount:C} retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<ImpactLevelDto>.ErrorResponse(
                "Failed to retrieve impact level by amount", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get all risk occurrence levels (without multipliers)
    /// GET /api/rba/reference/occurrence-levels?accountId=1
    /// </summary>
    [HttpGet("occurrence-levels")]
    public async Task<ActionResult<ApiResponse<IEnumerable<OccurrenceLevelDto>>>> GetOccurrenceLevels([FromQuery] int accountId)
    {
        try
        {
            var levels = await _referenceDataService.GetOccurrenceLevelsAsync(accountId, includeMultipliers: false);
            return Ok(ApiResponse<IEnumerable<OccurrenceLevelDto>>.SuccessResponse(
                levels, 
                "Risk occurrence levels retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<OccurrenceLevelDto>>.ErrorResponse(
                "Failed to retrieve occurrence levels", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get occurrence levels with gross loss multipliers
    /// GET /api/rba/reference/occurrence-levels/multipliers?accountId=1
    /// </summary>
    [HttpGet("occurrence-levels/multipliers")]
    public async Task<ActionResult<ApiResponse<IEnumerable<OccurrenceLevelDto>>>> GetOccurrenceLevelsMultipliers([FromQuery] int accountId)
    {
        try
        {
            var levels = await _referenceDataService.GetOccurrenceLevelsAsync(accountId, includeMultipliers: true);
            return Ok(ApiResponse<IEnumerable<OccurrenceLevelDto>>.SuccessResponse(
                levels, 
                "Occurrence levels with multipliers retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<OccurrenceLevelDto>>.ErrorResponse(
                "Failed to retrieve occurrence levels with multipliers", 
                ex.Message));
        }
    }

    /// <summary>
    /// Calculate inherent risk score and get rating (Very High, High, Medium, Low)
    /// POST /api/rba/reference/inherent-score
    /// </summary>
    [HttpPost("inherent-score")]
    public async Task<ActionResult<ApiResponse<InherentRiskScoreDto>>> CalculateInherentScore([FromBody] InherentScoreRequest request)
    {
        try
        {
            var score = await _referenceDataService.CalculateInherentScoreAsync(request.AccountId, request.Score);
            
            if (score == null)
                return NotFound(ApiResponse<InherentRiskScoreDto>.ErrorResponse(
                    "No inherent risk score found for the calculated value", 
                    $"Score value {request.Score} does not match any configured inherent risk score ranges"));

            return Ok(ApiResponse<InherentRiskScoreDto>.SuccessResponse(
                score, 
                "Inherent risk score calculated successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<InherentRiskScoreDto>.ErrorResponse(
                "Failed to calculate inherent risk score", 
                ex.Message));
        }
    }

    /// <summary>
    /// Get control effectiveness levels for residual risk calculation
    /// GET /api/rba/reference/control-effectiveness-levels?accountId=1
    /// </summary>
    [HttpGet("control-effectiveness-levels")]
    public async Task<ActionResult<ApiResponse<IEnumerable<ControlEffectivenessLevelDto>>>> GetControlEffectivenessLevels([FromQuery] int accountId)
    {
        try
        {
            var levels = await _referenceDataService.GetControlEffectivenessLevelsAsync(accountId);
            return Ok(ApiResponse<IEnumerable<ControlEffectivenessLevelDto>>.SuccessResponse(
                levels, 
                "Control effectiveness levels retrieved successfully"));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ApiResponse<IEnumerable<ControlEffectivenessLevelDto>>.ErrorResponse(
                "Failed to retrieve control effectiveness levels", 
                ex.Message));
        }
    }
}

public class InherentScoreRequest
{
    public int AccountId { get; set; }
    public int Score { get; set; }
}
