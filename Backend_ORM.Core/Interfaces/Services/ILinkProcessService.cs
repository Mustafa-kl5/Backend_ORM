using Backend_ORM.Core.DTOs.LinkProcess;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for LinkProcess business logic
/// </summary>
public interface ILinkProcessService
{
    /// <summary>
    /// Get paginated list of processes with link counts
    /// </summary>
    Task<ApiResponse<ProcessListResponseDto>> GetProcessesAsync(
        int accountId,
        int? categoryId = null,
        int? processId = null,
        int? subProcessId = null,
        int? processDetailsId = null,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Category",
        string sortDir = "ASC");

    /// <summary>
    /// Get detailed process information with all links
    /// </summary>
    Task<ApiResponse<ProcessDetailDto>> GetProcessDetailAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get business line links for a process
    /// </summary>
    Task<ApiResponse<List<BusinessLineDto>>> GetBusinessLinksAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get risk links for a process with controls
    /// </summary>
    Task<ApiResponse<List<RiskLinkDto>>> GetRiskLinksAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Delete a business line link
    /// </summary>
    Task<ApiResponse<DeleteResponseDto>> DeleteBusinessLineLinkAsync(int linkId, int processDetailsId, int accountId);

    /// <summary>
    /// Delete a risk link (cascades to controls)
    /// </summary>
    Task<ApiResponse<DeleteResponseDto>> DeleteRiskLinkAsync(int riskLinkId, int processDetailsId, int accountId);

    /// <summary>
    /// Delete a control link
    /// </summary>
    Task<ApiResponse<DeleteResponseDto>> DeleteControlLinkAsync(int controlLinkId, int riskLinkId, int accountId);

    /// <summary>
    /// Batch delete multiple links
    /// </summary>
    Task<ApiResponse<BatchDeleteResponseDto>> BatchDeleteAsync(BatchDeleteRequestDto request, int accountId);

    /// <summary>
    /// Get all departments for lookup
    /// </summary>
    Task<ApiResponse<List<DepartmentLookupDto>>> GetDepartmentsAsync(int accountId);

    /// <summary>
    /// Get all branches for lookup
    /// </summary>
    Task<ApiResponse<List<BranchLookupDto>>> GetBranchesAsync(int accountId);

    /// <summary>
    /// Get all divisions for lookup
    /// </summary>
    Task<ApiResponse<List<DivisionLookupDto>>> GetDivisionsAsync(int accountId);

    /// <summary>
    /// Get all users for lookup
    /// </summary>
    Task<ApiResponse<List<UserLookupDto>>> GetUsersAsync(int accountId);

    /// <summary>
    /// Add a business line link
    /// </summary>
    Task<ApiResponse<AddBusinessLineResponseDto>> AddBusinessLineLinkAsync(
        AddBusinessLineDto request,
        int accountId,
        int createdBy);

    /// <summary>
    /// Get all risks for lookup
    /// </summary>
    Task<ApiResponse<List<RiskLookupDto>>> GetRisksAsync(int accountId);

    /// <summary>
    /// Add a risk link
    /// </summary>
    Task<ApiResponse<AddRiskLinkResponseDto>> AddRiskLinkAsync(
        AddRiskLinkDto request,
        int accountId,
        int createdBy);

    /// <summary>
    /// Get all controls for lookup
    /// </summary>
    Task<ApiResponse<List<ControlLookupDto>>> GetControlsAsync(int accountId);

    /// <summary>
    /// Add a control link to a risk
    /// </summary>
    Task<ApiResponse<AddControlLinkResponseDto>> AddControlLinkAsync(
        AddControlLinkDto request,
        int accountId,
        int createdBy);
}
