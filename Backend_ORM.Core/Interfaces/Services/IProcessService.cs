using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for Process operations (Level 2)
/// </summary>
public interface IProcessService
{
    Task<ApiResponse<ProcessLevelTwoListResponseDto>> GetProcessesAsync(
        int accountId,
        int? processTypeId = null,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Description",
        string sortDir = "ASC");

    Task<ApiResponse<ProcessLevelTwoDetailDto>> GetProcessByIdAsync(int accountId, int id);

    Task<ApiResponse<ProcessLevelTwoOperationResponseDto>> CreateProcessAsync(
        int accountId,
        int userId,
        CreateProcessLevelTwoDto dto);

    Task<ApiResponse<ProcessLevelTwoOperationResponseDto>> UpdateProcessAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessLevelTwoDto dto);

    Task<ApiResponse<bool>> DeleteProcessAsync(
        int accountId,
        int id);
}
