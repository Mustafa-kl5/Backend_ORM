using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend_ORM.API.Controllers;

/// <summary>
/// API Controller for LinkProcess operations
/// Provides RESTful endpoints for managing process links to business units, risks, and controls
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class LinkProcessController : ControllerBase
{
    private readonly ILinkProcessService _linkProcessService;
    private readonly ILogger<LinkProcessController> _logger;

    // TODO: Replace with actual authentication/authorization
    private const int DEFAULT_ACCOUNT_ID = 1;

    public LinkProcessController(
        ILinkProcessService linkProcessService,
        ILogger<LinkProcessController> logger)
    {
        _linkProcessService = linkProcessService;
        _logger = logger;
    }

    /// <summary>
    /// Endpoint 1: GET /api/linkprocess/processes
    /// Retrieve list of all processes with links summary
    /// </summary>
    /// <param name="categoryId">Filter by process category (optional)</param>
    /// <param name="processId">Filter by process (optional)</param>
    /// <param name="subProcessId">Filter by sub-process (optional)</param>
    /// <param name="processDetailsId">Filter by process details (optional)</param>
    /// <param name="pageNumber">Page number (default: 1)</param>
    /// <param name="pageSize">Page size (default: 50)</param>
    /// <param name="sortBy">Sort column (default: Category)</param>
    /// <param name="sortDir">Sort direction: ASC or DESC (default: ASC)</param>
    /// <returns>Paginated list of processes with link counts</returns>
    [HttpGet("processes")]
    [ProducesResponseType(typeof(ApiResponse<ProcessListResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProcessListResponseDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProcesses(
        [FromQuery] int? categoryId = null,
        [FromQuery] int? processId = null,
        [FromQuery] int? subProcessId = null,
        [FromQuery] int? processDetailsId = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 50,
        [FromQuery] string sortBy = "Category",
        [FromQuery] string sortDir = "ASC")
    {
        try
        {
            _logger.LogInformation(
                "Getting processes list. Filters: categoryId={CategoryId}, processId={ProcessId}, subProcessId={SubProcessId}, processDetailsId={ProcessDetailsId}",
                categoryId, processId, subProcessId, processDetailsId);

            var result = await _linkProcessService.GetProcessesAsync(
                DEFAULT_ACCOUNT_ID,
                categoryId,
                processId,
                subProcessId,
                processDetailsId,
                pageNumber,
                pageSize,
                sortBy,
                sortDir);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving processes list");
            return StatusCode(500, ApiResponse<ProcessListResponseDto>.ErrorResponse(
                "An error occurred while retrieving processes",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 2: GET /api/linkprocess/processes/{processDetailsId}
    /// Retrieve detailed process with all links (for edit mode)
    /// </summary>
    /// <param name="processDetailsId">Unique process detail identifier</param>
    /// <returns>Detailed process information with all business units, risks, and controls</returns>
    [HttpGet("processes/{processDetailsId:int}")]
    [ProducesResponseType(typeof(ApiResponse<ProcessDetailDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<ProcessDetailDto>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<ProcessDetailDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetProcessDetail(int processDetailsId)
    {
        try
        {
            _logger.LogInformation("Getting process detail for ProcessDetailsId={ProcessDetailsId}", processDetailsId);

            var result = await _linkProcessService.GetProcessDetailAsync(processDetailsId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
            {
                if (result.Message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(result);
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process detail for ProcessDetailsId={ProcessDetailsId}", processDetailsId);
            return StatusCode(500, ApiResponse<ProcessDetailDto>.ErrorResponse(
                "An error occurred while retrieving process detail",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 7: GET /api/linkprocess/processes/{processDetailsId}/business-units
    /// Get all business units linked to a process
    /// </summary>
    /// <param name="processDetailsId">Process identifier</param>
    /// <returns>List of business unit links</returns>
    [HttpGet("processes/{processDetailsId:int}/business-units")]
    [ProducesResponseType(typeof(ApiResponse<List<BusinessLineDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<List<BusinessLineDto>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetBusinessUnits(int processDetailsId)
    {
        try
        {
            _logger.LogInformation("Getting business units for ProcessDetailsId={ProcessDetailsId}", processDetailsId);

            var result = await _linkProcessService.GetBusinessLinksAsync(processDetailsId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving business units for ProcessDetailsId={ProcessDetailsId}", processDetailsId);
            return StatusCode(500, ApiResponse<List<BusinessLineDto>>.ErrorResponse(
                "An error occurred while retrieving business units",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 8: GET /api/linkprocess/processes/{processDetailsId}/risks
    /// Get all risks linked to a process (includes controls)
    /// </summary>
    /// <param name="processDetailsId">Process identifier</param>
    /// <returns>List of risk links with their controls</returns>
    [HttpGet("processes/{processDetailsId:int}/risks")]
    [ProducesResponseType(typeof(ApiResponse<List<RiskLinkDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<List<RiskLinkDto>>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRisks(int processDetailsId)
    {
        try
        {
            _logger.LogInformation("Getting risks for ProcessDetailsId={ProcessDetailsId}", processDetailsId);

            var result = await _linkProcessService.GetRiskLinksAsync(processDetailsId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving risks for ProcessDetailsId={ProcessDetailsId}", processDetailsId);
            return StatusCode(500, ApiResponse<List<RiskLinkDto>>.ErrorResponse(
                "An error occurred while retrieving risks",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 3: DELETE /api/linkprocess/processes/{processDetailsId}/business-lines/{linkId}
    /// Delete a business unit link from a process
    /// </summary>
    /// <param name="processDetailsId">Process identifier</param>
    /// <param name="linkId">Business line link identifier</param>
    /// <returns>Delete response with remaining links count</returns>
    [HttpDelete("processes/{processDetailsId:int}/business-lines/{linkId:int}")]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBusinessLine(int processDetailsId, int linkId)
    {
        try
        {
            _logger.LogInformation(
                "Deleting business line link. ProcessDetailsId={ProcessDetailsId}, LinkId={LinkId}",
                processDetailsId, linkId);

            var result = await _linkProcessService.DeleteBusinessLineLinkAsync(
                linkId, processDetailsId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
            {
                if (result.Message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(result);
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting business line link. ProcessDetailsId={ProcessDetailsId}, LinkId={LinkId}",
                processDetailsId, linkId);
            return StatusCode(500, ApiResponse<DeleteResponseDto>.ErrorResponse(
                "An error occurred while deleting business line link",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 4: DELETE /api/linkprocess/processes/{processDetailsId}/risks/{riskLinkId}
    /// Delete a risk link (cascades to controls)
    /// </summary>
    /// <param name="processDetailsId">Process identifier</param>
    /// <param name="riskLinkId">Risk link identifier</param>
    /// <returns>Delete response with total deleted count (risk + cascaded controls)</returns>
    [HttpDelete("processes/{processDetailsId:int}/risks/{riskLinkId:int}")]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status409Conflict)]
    public async Task<IActionResult> DeleteRisk(int processDetailsId, int riskLinkId)
    {
        try
        {
            _logger.LogInformation(
                "Deleting risk link. ProcessDetailsId={ProcessDetailsId}, RiskLinkId={RiskLinkId}",
                processDetailsId, riskLinkId);

            var result = await _linkProcessService.DeleteRiskLinkAsync(
                riskLinkId, processDetailsId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
            {
                if (result.Message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(result);
                if (result.Message.Contains("in use", StringComparison.OrdinalIgnoreCase) ||
                    result.Message.Contains("active", StringComparison.OrdinalIgnoreCase))
                    return Conflict(result);
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting risk link. ProcessDetailsId={ProcessDetailsId}, RiskLinkId={RiskLinkId}",
                processDetailsId, riskLinkId);
            return StatusCode(500, ApiResponse<DeleteResponseDto>.ErrorResponse(
                "An error occurred while deleting risk link",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 5: DELETE /api/linkprocess/processes/{processDetailsId}/risks/{riskLinkId}/controls/{controlLinkId}
    /// Delete a control link from a risk
    /// </summary>
    /// <param name="processDetailsId">Process identifier (not used in service but validates route)</param>
    /// <param name="riskLinkId">Risk link identifier</param>
    /// <param name="controlLinkId">Control link identifier</param>
    /// <returns>Delete response with remaining controls count</returns>
    [HttpDelete("processes/{processDetailsId:int}/risks/{riskLinkId:int}/controls/{controlLinkId:int}")]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(ApiResponse<DeleteResponseDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteControl(int processDetailsId, int riskLinkId, int controlLinkId)
    {
        try
        {
            _logger.LogInformation(
                "Deleting control link. ProcessDetailsId={ProcessDetailsId}, RiskLinkId={RiskLinkId}, ControlLinkId={ControlLinkId}",
                processDetailsId, riskLinkId, controlLinkId);

            var result = await _linkProcessService.DeleteControlLinkAsync(
                controlLinkId, riskLinkId, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
            {
                if (result.Message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                    return NotFound(result);
                if (result.Message.Contains("protected", StringComparison.OrdinalIgnoreCase) ||
                    result.Message.Contains("cannot be deleted", StringComparison.OrdinalIgnoreCase))
                    return StatusCode(403, result);
                return BadRequest(result);
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex,
                "Error deleting control link. ProcessDetailsId={ProcessDetailsId}, RiskLinkId={RiskLinkId}, ControlLinkId={ControlLinkId}",
                processDetailsId, riskLinkId, controlLinkId);
            return StatusCode(500, ApiResponse<DeleteResponseDto>.ErrorResponse(
                "An error occurred while deleting control link",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 6: POST /api/linkprocess/batch-delete
    /// Delete multiple links across all categories in one operation
    /// </summary>
    /// <param name="request">Batch delete request containing all link IDs to delete</param>
    /// <returns>Batch delete response with success/failure counts</returns>
    [HttpPost("batch-delete")]
    [ProducesResponseType(typeof(ApiResponse<BatchDeleteResponseDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse<BatchDeleteResponseDto>), StatusCodes.Status207MultiStatus)]
    [ProducesResponseType(typeof(ApiResponse<BatchDeleteResponseDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> BatchDelete([FromBody] BatchDeleteRequestDto request)
    {
        try
        {
            _logger.LogInformation(
                "Batch delete requested. ProcessDetailsId={ProcessDetailsId}, BLs={BLCount}, Risks={RiskCount}, Controls={ControlCount}",
                request?.ProcessDetailsId,
                request?.BusinessLineIds.Count,
                request?.RiskIds.Count,
                request?.ControlIds.Count);

            if (request == null)
                return BadRequest(ApiResponse<BatchDeleteResponseDto>.ErrorResponse("Invalid request body"));

            var result = await _linkProcessService.BatchDeleteAsync(request, DEFAULT_ACCOUNT_ID);

            if (!result.Success)
                return BadRequest(result);

            // Return 207 Multi-Status if there were partial failures
            if (result.Data?.Failures.Any() == true)
                return StatusCode(207, result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing batch delete");
            return StatusCode(500, ApiResponse<BatchDeleteResponseDto>.ErrorResponse(
                "An error occurred while executing batch delete",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 10: GET /api/linkprocess/lookups/departments
    /// Get all departments for business unit linking
    /// </summary>
    /// <returns>List of departments</returns>
    [HttpGet("lookups/departments")]
    [ProducesResponseType(typeof(ApiResponse<List<DepartmentLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDepartments()
    {
        try
        {
            var result = await _linkProcessService.GetDepartmentsAsync(DEFAULT_ACCOUNT_ID);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving departments");
            return StatusCode(500, ApiResponse<List<DepartmentLookupDto>>.ErrorResponse(
                "An error occurred while retrieving departments",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 11: GET /api/linkprocess/lookups/branches
    /// Get all branches for business unit linking
    /// </summary>
    /// <returns>List of branches</returns>
    [HttpGet("lookups/branches")]
    [ProducesResponseType(typeof(ApiResponse<List<BranchLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBranches()
    {
        try
        {
            var result = await _linkProcessService.GetBranchesAsync(DEFAULT_ACCOUNT_ID);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving branches");
            return StatusCode(500, ApiResponse<List<BranchLookupDto>>.ErrorResponse(
                "An error occurred while retrieving branches",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 12: GET /api/linkprocess/lookups/divisions
    /// Get all divisions for business unit linking
    /// </summary>
    /// <returns>List of divisions</returns>
    [HttpGet("lookups/divisions")]
    [ProducesResponseType(typeof(ApiResponse<List<DivisionLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDivisions()
    {
        try
        {
            var result = await _linkProcessService.GetDivisionsAsync(DEFAULT_ACCOUNT_ID);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving divisions");
            return StatusCode(500, ApiResponse<List<DivisionLookupDto>>.ErrorResponse(
                "An error occurred while retrieving divisions",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 13: GET /api/linkprocess/lookups/users
    /// Get all users for business unit linking
    /// </summary>
    /// <returns>List of users</returns>
    [HttpGet("lookups/users")]
    [ProducesResponseType(typeof(ApiResponse<List<UserLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var result = await _linkProcessService.GetUsersAsync(DEFAULT_ACCOUNT_ID);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving users");
            return StatusCode(500, ApiResponse<List<UserLookupDto>>.ErrorResponse(
                "An error occurred while retrieving users",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 14: POST /api/linkprocess/processes/{id}/business-units
    /// Add a new business unit link to a process
    /// </summary>
    /// <param name="id">Process details ID</param>
    /// <param name="request">Business unit link details</param>
    /// <returns>Created link information</returns>
    [HttpPost("processes/{id}/business-units")]
    [ProducesResponseType(typeof(ApiResponse<AddBusinessLineResponseDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<AddBusinessLineResponseDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddBusinessUnit(int id, [FromBody] AddBusinessLineDto request)
    {
        try
        {
            _logger.LogInformation(
                "Adding business unit link. ProcessDetailsId={ProcessDetailsId}, Source={Source}, EntityId={EntityId}",
                id,
                request?.Source,
                request?.EntityId);

            if (request == null)
                return BadRequest(ApiResponse<AddBusinessLineResponseDto>.ErrorResponse("Invalid request body"));

            // Ensure ID matches route parameter
            request.ProcessDetailsId = id;

            // TODO: Get actual user ID from authentication
            const int userId = 1;

            var result = await _linkProcessService.AddBusinessLineLinkAsync(request, DEFAULT_ACCOUNT_ID, userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding business unit link");
            return StatusCode(500, ApiResponse<AddBusinessLineResponseDto>.ErrorResponse(
                "An error occurred while adding business unit link",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 15: GET /api/linkprocess/lookups/risks
    /// Get all risks for lookup dropdown
    /// </summary>
    /// <returns>List of all risks with categories</returns>
    [HttpGet("lookups/risks")]
    [ProducesResponseType(typeof(ApiResponse<List<RiskLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRisks()
    {
        try
        {
            _logger.LogInformation("Retrieving risks for account {AccountId}", DEFAULT_ACCOUNT_ID);

            var result = await _linkProcessService.GetRisksAsync(DEFAULT_ACCOUNT_ID);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving risks");
            return StatusCode(500, ApiResponse<List<RiskLookupDto>>.ErrorResponse(
                "An error occurred while retrieving risks",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 16: POST /api/linkprocess/processes/{id}/risks
    /// Add a new risk link to a process
    /// </summary>
    /// <param name="id">Process details ID</param>
    /// <param name="request">Risk link details</param>
    /// <returns>Created link information</returns>
    [HttpPost("processes/{id}/risks")]
    [ProducesResponseType(typeof(ApiResponse<AddRiskLinkResponseDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<AddRiskLinkResponseDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddRisk(int id, [FromBody] AddRiskLinkDto request)
    {
        try
        {
            _logger.LogInformation(
                "Adding risk link. ProcessDetailsId={ProcessDetailsId}, RiskElementId={RiskElementId}",
                id,
                request?.RiskElementId);

            if (request == null)
                return BadRequest(ApiResponse<AddRiskLinkResponseDto>.ErrorResponse("Invalid request body"));

            // Ensure ID matches route parameter
            request.ProcessDetailsId = id;

            // TODO: Get actual user ID from authentication
            const int userId = 1;

            var result = await _linkProcessService.AddRiskLinkAsync(request, DEFAULT_ACCOUNT_ID, userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding risk link");
            return StatusCode(500, ApiResponse<AddRiskLinkResponseDto>.ErrorResponse(
                "An error occurred while adding risk link",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 17: GET /api/linkprocess/lookups/controls
    /// Get all controls for lookup dropdown
    /// </summary>
    /// <returns>List of all controls with categories</returns>
    [HttpGet("lookups/controls")]
    [ProducesResponseType(typeof(ApiResponse<List<ControlLookupDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetControls()
    {
        try
        {
            _logger.LogInformation("Retrieving controls for account {AccountId}", DEFAULT_ACCOUNT_ID);

            var result = await _linkProcessService.GetControlsAsync(DEFAULT_ACCOUNT_ID);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving controls");
            return StatusCode(500, ApiResponse<List<ControlLookupDto>>.ErrorResponse(
                "An error occurred while retrieving controls",
                ex.Message));
        }
    }

    /// <summary>
    /// Endpoint 18: POST /api/linkprocess/risks/{riskLinkId}/controls
    /// Add a new control link to a risk
    /// </summary>
    /// <param name="riskLinkId">Risk link ID (OrmProcessRiskLink.Id)</param>
    /// <param name="request">Control link details</param>
    /// <returns>Created link information</returns>
    [HttpPost("risks/{riskLinkId}/controls")]
    [ProducesResponseType(typeof(ApiResponse<AddControlLinkResponseDto>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse<AddControlLinkResponseDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddControl(int riskLinkId, [FromBody] AddControlLinkDto request)
    {
        try
        {
            _logger.LogInformation(
                "Adding control link. RiskLinkId={RiskLinkId}, ControlElementId={ControlElementId}",
                riskLinkId,
                request?.ControlElementId);

            if (request == null)
                return BadRequest(ApiResponse<AddControlLinkResponseDto>.ErrorResponse("Invalid request body"));

            // Ensure ID matches route parameter
            request.ProcessRiskLinkId = riskLinkId;

            // TODO: Get actual user ID from authentication
            const int userId = 1;

            var result = await _linkProcessService.AddControlLinkAsync(request, DEFAULT_ACCOUNT_ID, userId);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding control link");
            return StatusCode(500, ApiResponse<AddControlLinkResponseDto>.ErrorResponse(
                "An error occurred while adding control link",
                ex.Message));
        }
    }
}

