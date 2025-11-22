using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service implementation for ProcessDetail operations
/// Handles business logic and validation
/// </summary>
public class ProcessDetailService : IProcessDetailService
{
    private readonly IProcessDetailRepository _repository;
    private readonly ISubProcessRepository _subProcessRepository;
    private readonly ILogger<ProcessDetailService> _logger;

    public ProcessDetailService(
        IProcessDetailRepository repository,
        ISubProcessRepository subProcessRepository,
        ILogger<ProcessDetailService> logger)
    {
        _repository = repository;
        _subProcessRepository = subProcessRepository;
        _logger = logger;
    }

    public async Task<ApiResponse<ProcessDetailListResponseDto>> GetProcessDetailsAsync(
        int accountId,
        int? subjectId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        try
        {
            var (processDetails, totalCount) = await _repository.GetProcessDetailsAsync(
                accountId, subjectId, pageNumber, pageSize, sortBy, sortDir);

            var processDetailList = processDetails.Select(pd => new ProcessDetailListDto
            {
                Id = pd.Id,
                SubjectId = pd.SubjectId,
                SubjectDescription = pd.Subject?.Description ?? string.Empty,
                Description = pd.Description ?? string.Empty,
                CreationDate = pd.CreationDate
            }).ToList();

            var response = new ProcessDetailListResponseDto
            {
                ProcessDetails = processDetailList,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return ApiResponse<ProcessDetailListResponseDto>.SuccessResponse(
                response,
                "Process details retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process details for account {AccountId}", accountId);
            return ApiResponse<ProcessDetailListResponseDto>.ErrorResponse(
                "Failed to retrieve process details",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessDetailItemDto>> GetProcessDetailByIdAsync(int accountId, int id)
    {
        try
        {
            var processDetail = await _repository.GetProcessDetailByIdAsync(accountId, id);

            if (processDetail == null)
            {
                return ApiResponse<ProcessDetailItemDto>.ErrorResponse(
                    "Process detail not found",
                    new List<string> { $"Process detail with ID {id} does not exist" });
            }

            var processDetailItem = new ProcessDetailItemDto
            {
                Id = processDetail.Id,
                AccountId = processDetail.AccountId,
                SubjectId = processDetail.SubjectId,
                SubjectDescription = processDetail.Subject?.Description ?? string.Empty,
                Description = processDetail.Description ?? string.Empty,
                CreatedBy = processDetail.CreatedBy,
                CreationDate = processDetail.CreationDate,
                UpdatedBy = processDetail.UpdatedBy,
                UpdatedDate = processDetail.UpdatedDate
            };

            return ApiResponse<ProcessDetailItemDto>.SuccessResponse(
                processDetailItem,
                "Process detail retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process detail {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessDetailItemDto>.ErrorResponse(
                "Failed to retrieve process detail",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessDetailOperationResponseDto>> CreateProcessDetailAsync(
        int accountId,
        int userId,
        CreateProcessDetailDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Validate SubProcess exists
            var subProcess = await _subProcessRepository.GetSubProcessByIdAsync(accountId, dto.SubjectId);
            if (subProcess == null)
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Sub-process not found",
                    new List<string> { $"Sub-process with ID {dto.SubjectId} does not exist" });
            }

            // Check for duplicates
            var exists = await _repository.ProcessDetailExistsAsync(accountId, dto.SubjectId, dto.Description);
            if (exists)
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Duplicate process detail",
                    new List<string> { $"A process detail with description '{dto.Description}' already exists for this sub-process" });
            }

            // Create entity
            var processDetail = new OrmProcessDetail
            {
                AccountId = accountId,
                SubjectId = dto.SubjectId,
                Description = dto.Description.Trim(),
                CreatedBy = userId,
                CreationDate = DateTime.Now
            };

            var newId = await _repository.CreateProcessDetailAsync(processDetail);

            var response = new ProcessDetailOperationResponseDto
            {
                Id = newId,
                Message = "Process detail created successfully"
            };

            return ApiResponse<ProcessDetailOperationResponseDto>.SuccessResponse(
                response,
                "Process detail created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating process detail for account {AccountId}", accountId);
            return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                "Failed to create process detail",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessDetailOperationResponseDto>> UpdateProcessDetailAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessDetailDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Check if exists
            var processDetail = await _repository.GetProcessDetailByIdAsync(accountId, id);
            if (processDetail == null)
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Process detail not found",
                    new List<string> { $"Process detail with ID {id} does not exist" });
            }

            // Validate SubProcess exists
            var subProcess = await _subProcessRepository.GetSubProcessByIdAsync(accountId, dto.SubjectId);
            if (subProcess == null)
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Sub-process not found",
                    new List<string> { $"Sub-process with ID {dto.SubjectId} does not exist" });
            }

            // Check for duplicates (excluding current record)
            var exists = await _repository.ProcessDetailExistsAsync(accountId, dto.SubjectId, dto.Description, id);
            if (exists)
            {
                return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                    "Duplicate process detail",
                    new List<string> { $"A process detail with description '{dto.Description}' already exists for this sub-process" });
            }

            // Update entity
            processDetail.SubjectId = dto.SubjectId;
            processDetail.Description = dto.Description.Trim();
            processDetail.UpdatedBy = userId;
            processDetail.UpdatedDate = DateTime.Now;

            await _repository.UpdateProcessDetailAsync(processDetail);

            var response = new ProcessDetailOperationResponseDto
            {
                Id = id,
                Message = "Process detail updated successfully"
            };

            return ApiResponse<ProcessDetailOperationResponseDto>.SuccessResponse(
                response,
                "Process detail updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating process detail {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessDetailOperationResponseDto>.ErrorResponse(
                "Failed to update process detail",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<bool>> DeleteProcessDetailAsync(int accountId, int id)
    {
        try
        {
            // Check if exists
            var processDetail = await _repository.GetProcessDetailByIdAsync(accountId, id);
            if (processDetail == null)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Process detail not found",
                    new List<string> { $"Process detail with ID {id} does not exist" });
            }

            var result = await _repository.DeleteProcessDetailAsync(accountId, id);

            if (!result)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Failed to delete process detail",
                    new List<string> { "An error occurred while deleting the process detail" });
            }

            return ApiResponse<bool>.SuccessResponse(true, "Process detail deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting process detail {Id} for account {AccountId}", id, accountId);
            return ApiResponse<bool>.ErrorResponse(
                "Failed to delete process detail",
                new List<string> { ex.Message });
        }
    }
}
