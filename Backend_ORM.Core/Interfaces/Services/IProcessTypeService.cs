using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for ProcessType operations
/// </summary>
public interface IProcessTypeService
{
    Task<ApiResponse<ProcessTypeListResponseDto>> GetProcessTypesAsync(
        int accountId,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Description",
        string sortDir = "ASC");

    Task<ApiResponse<ProcessTypeDetailDto>> GetProcessTypeByIdAsync(int accountId, int id);

    Task<ApiResponse<ProcessTypeOperationResponseDto>> CreateProcessTypeAsync(
        int accountId,
        int userId,
        CreateProcessTypeDto dto);

    Task<ApiResponse<ProcessTypeOperationResponseDto>> UpdateProcessTypeAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessTypeDto dto);

    Task<ApiResponse<bool>> DeleteProcessTypeAsync(
        int accountId,
        int id);
}
