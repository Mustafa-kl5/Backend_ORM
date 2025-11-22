using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;

namespace Backend_ORM.Core.Interfaces.Services;

/// <summary>
/// Service interface for Process Detail operations
/// </summary>
public interface IProcessDetailService
{
    Task<ApiResponse<ProcessDetailListResponseDto>> GetProcessDetailsAsync(
        int accountId,
        int? subjectId = null,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Description",
        string sortDir = "ASC");

    Task<ApiResponse<ProcessDetailItemDto>> GetProcessDetailByIdAsync(int accountId, int id);

    Task<ApiResponse<ProcessDetailOperationResponseDto>> CreateProcessDetailAsync(
        int accountId,
        int userId,
        CreateProcessDetailDto dto);

    Task<ApiResponse<ProcessDetailOperationResponseDto>> UpdateProcessDetailAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessDetailDto dto);

    Task<ApiResponse<bool>> DeleteProcessDetailAsync(
        int accountId,
        int id);
}
