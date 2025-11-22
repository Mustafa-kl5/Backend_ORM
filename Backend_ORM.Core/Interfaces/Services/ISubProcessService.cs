using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for SubProcess operations
/// </summary>
public interface ISubProcessService
{
    Task<ApiResponse<SubProcessLevelTwoListResponseDto>> GetSubProcessesAsync(
        int accountId,
        int? processId = null,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Description",
        string sortDir = "ASC");

    Task<ApiResponse<SubProcessLevelTwoDetailDto>> GetSubProcessByIdAsync(int accountId, int id);

    Task<ApiResponse<SubProcessLevelTwoOperationResponseDto>> CreateSubProcessAsync(
        int accountId,
        int userId,
        CreateSubProcessDto dto);

    Task<ApiResponse<SubProcessLevelTwoOperationResponseDto>> UpdateSubProcessAsync(
        int accountId,
        int userId,
        int id,
        UpdateSubProcessDto dto);

    Task<ApiResponse<bool>> DeleteSubProcessAsync(
        int accountId,
        int id);
}
