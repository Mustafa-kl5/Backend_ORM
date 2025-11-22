using Backend_ORM.Core.DTOs.LinkProcess;

namespace Backend_ORM.Core.Interfaces.Repositories;

/// <summary>
/// Repository for LinkProcess operations
/// </summary>
public interface ILinkProcessRepository
{
    /// <summary>
    /// Get paginated list of processes with link counts
    /// </summary>
    Task<(List<ProcessListDto> Processes, int TotalCount)> GetProcessesAsync(
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
    Task<ProcessDetailDto?> GetProcessDetailAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get business line links for a process
    /// </summary>
    Task<List<BusinessLineDto>> GetBusinessLinksAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get risk links for a process
    /// </summary>
    Task<List<RiskLinkDto>> GetRiskLinksAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get control links for a specific risk
    /// </summary>
    Task<List<ControlLinkDto>> GetControlLinksAsync(int riskLinkId, int accountId);

    /// <summary>
    /// Delete a business line link
    /// </summary>
    Task<bool> DeleteBusinessLineLinkAsync(int linkId, int processDetailsId, int accountId);

    /// <summary>
    /// Delete a risk link (cascades to controls)
    /// </summary>
    Task<int> DeleteRiskLinkAsync(int riskLinkId, int processDetailsId, int accountId);

    /// <summary>
    /// Delete a control link
    /// </summary>
    Task<bool> DeleteControlLinkAsync(int controlLinkId, int riskLinkId, int accountId);

    /// <summary>
    /// Delete a control link by ID only (for batch operations)
    /// </summary>
    Task<bool> DeleteControlLinkByIdAsync(int controlLinkId, int accountId);

    /// <summary>
    /// Check if a business line link can be deleted
    /// </summary>
    Task<(bool CanDelete, string Reason)> CanDeleteBusinessLineLinkAsync(int linkId, int accountId);

    /// <summary>
    /// Check if a risk link can be deleted
    /// </summary>
    Task<(bool CanDelete, string Reason)> CanDeleteRiskLinkAsync(int riskLinkId, int accountId);

    /// <summary>
    /// Check if a control link can be deleted
    /// </summary>
    Task<(bool CanDelete, string Reason)> CanDeleteControlLinkAsync(int controlLinkId, int accountId);

    /// <summary>
    /// Get count of remaining links after deletion
    /// </summary>
    Task<int> GetBusinessLinksCountAsync(int processDetailsId, int accountId);

    /// <summary>
    /// Get count of remaining controls for a risk
    /// </summary>
    Task<int> GetControlLinksCountAsync(int riskLinkId, int accountId);

    /// <summary>
    /// Get all departments for lookup
    /// </summary>
    Task<List<DepartmentLookupDto>> GetDepartmentsAsync(int accountId);

    /// <summary>
    /// Get all branches for lookup
    /// </summary>
    Task<List<BranchLookupDto>> GetBranchesAsync(int accountId);

    /// <summary>
    /// Get all divisions for lookup
    /// </summary>
    Task<List<DivisionLookupDto>> GetDivisionsAsync(int accountId);

    /// <summary>
    /// Get all users for lookup
    /// </summary>
    Task<List<UserLookupDto>> GetUsersAsync(int accountId);

    /// <summary>
    /// Add a business line link
    /// </summary>
    Task<(bool Success, int LinkId, string Message)> AddBusinessLineLinkAsync(
        int processDetailsId,
        int source,
        int entityId,
        int accountId,
        int createdBy);

    /// <summary>
    /// Get all risks for lookup
    /// </summary>
    Task<List<RiskLookupDto>> GetRisksAsync(int accountId);

    /// <summary>
    /// Add a risk link
    /// </summary>
    Task<(bool Success, int LinkId, string Message)> AddRiskLinkAsync(
        int processDetailsId,
        int riskElementId,
        int? riskImpactId,
        int? riskOccurrenceId,
        int accountId,
        int createdBy);

    /// <summary>
    /// Get all controls for lookup
    /// </summary>
    Task<List<ControlLookupDto>> GetControlsAsync(int accountId);

    /// <summary>
    /// Add a control link to a risk
    /// </summary>
    Task<(bool Success, int LinkId, string Message)> AddControlLinkAsync(
        int processRiskLinkId,
        int controlElementId,
        int? controlDesignEffectId,
        int? residualRiskExposure,
        int? residualRiskQuadrantId,
        int accountId,
        int createdBy);
}
