using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service implementation for SubProcess operations
/// Handles business logic and validation
/// </summary>
public class SubProcessService : ISubProcessService
{
    private readonly ISubProcessRepository _repository;
    private readonly IProcessRepository _processRepository;
    private readonly ILogger<SubProcessService> _logger;

    public SubProcessService(
        ISubProcessRepository repository,
        IProcessRepository processRepository,
        ILogger<SubProcessService> logger)
    {
        _repository = repository;
        _processRepository = processRepository;
        _logger = logger;
    }

    public async Task<ApiResponse<SubProcessLevelTwoListResponseDto>> GetSubProcessesAsync(
        int accountId,
        int? processId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        try
        {
            var (subProcesses, totalCount) = await _repository.GetSubProcessesAsync(
                accountId, processId, pageNumber, pageSize, sortBy, sortDir);

            var subProcessList = subProcesses.Select(sp => new SubProcessLevelTwoListDto
            {
                Id = sp.Id,
                ProcessId = sp.ProcessId,
                ProcessDescription = sp.Process?.Description ?? string.Empty,
                Description = sp.Description ?? string.Empty,
                CreationDate = sp.CreationDate,
                DetailsCount = sp.OrmProcessDetails?.Count ?? 0
            }).ToList();

            var response = new SubProcessLevelTwoListResponseDto
            {
                SubProcesses = subProcessList,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return ApiResponse<SubProcessLevelTwoListResponseDto>.SuccessResponse(
                response,
                "Sub-processes retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving sub-processes for account {AccountId}", accountId);
            return ApiResponse<SubProcessLevelTwoListResponseDto>.ErrorResponse(
                "Failed to retrieve sub-processes",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<SubProcessLevelTwoDetailDto>> GetSubProcessByIdAsync(int accountId, int id)
    {
        try
        {
            var subProcess = await _repository.GetSubProcessByIdAsync(accountId, id);

            if (subProcess == null)
            {
                return ApiResponse<SubProcessLevelTwoDetailDto>.ErrorResponse(
                    "Sub-process not found",
                    new List<string> { $"Sub-process with ID {id} does not exist" });
            }

            var subProcessDetail = new SubProcessLevelTwoDetailDto
            {
                Id = subProcess.Id,
                AccountId = subProcess.AccountId,
                ProcessId = subProcess.ProcessId,
                ProcessDescription = subProcess.Process?.Description ?? string.Empty,
                Description = subProcess.Description ?? string.Empty,
                CreatedBy = subProcess.CreatedBy,
                CreationDate = subProcess.CreationDate,
                UpdatedBy = subProcess.UpdatedBy,
                UpdatedDate = subProcess.UpdatedDate,
                DetailsCount = subProcess.OrmProcessDetails?.Count ?? 0
            };

            return ApiResponse<SubProcessLevelTwoDetailDto>.SuccessResponse(
                subProcessDetail,
                "Sub-process retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving sub-process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<SubProcessLevelTwoDetailDto>.ErrorResponse(
                "Failed to retrieve sub-process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<SubProcessLevelTwoOperationResponseDto>> CreateSubProcessAsync(
        int accountId,
        int userId,
        CreateSubProcessDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Validate Process exists
            var process = await _processRepository.GetProcessByIdAsync(accountId, dto.ProcessId);
            if (process == null)
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Process not found",
                    new List<string> { $"Process with ID {dto.ProcessId} does not exist" });
            }

            // Check for duplicates
            var exists = await _repository.SubProcessExistsAsync(accountId, dto.ProcessId, dto.Description);
            if (exists)
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Duplicate sub-process",
                    new List<string> { $"A sub-process with description '{dto.Description}' already exists for this process" });
            }

            // Create entity
            var subProcess = new OrmProcessSubject
            {
                AccountId = accountId,
                ProcessId = dto.ProcessId,
                Description = dto.Description.Trim(),
                CreatedBy = userId,
                CreationDate = DateTime.Now
            };

            var newId = await _repository.CreateSubProcessAsync(subProcess);

            var response = new SubProcessLevelTwoOperationResponseDto
            {
                Id = newId,
                Message = "Sub-process created successfully"
            };

            return ApiResponse<SubProcessLevelTwoOperationResponseDto>.SuccessResponse(
                response,
                "Sub-process created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating sub-process for account {AccountId}", accountId);
            return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                "Failed to create sub-process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<SubProcessLevelTwoOperationResponseDto>> UpdateSubProcessAsync(
        int accountId,
        int userId,
        int id,
        UpdateSubProcessDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Check if exists
            var subProcess = await _repository.GetSubProcessByIdAsync(accountId, id);
            if (subProcess == null)
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Sub-process not found",
                    new List<string> { $"Sub-process with ID {id} does not exist" });
            }

            // Validate Process exists
            var process = await _processRepository.GetProcessByIdAsync(accountId, dto.ProcessId);
            if (process == null)
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Process not found",
                    new List<string> { $"Process with ID {dto.ProcessId} does not exist" });
            }

            // Check for duplicates (excluding current record)
            var exists = await _repository.SubProcessExistsAsync(accountId, dto.ProcessId, dto.Description, id);
            if (exists)
            {
                return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Duplicate sub-process",
                    new List<string> { $"A sub-process with description '{dto.Description}' already exists for this process" });
            }

            // Update entity
            subProcess.ProcessId = dto.ProcessId;
            subProcess.Description = dto.Description.Trim();
            subProcess.UpdatedBy = userId;
            subProcess.UpdatedDate = DateTime.Now;

            await _repository.UpdateSubProcessAsync(subProcess);

            var response = new SubProcessLevelTwoOperationResponseDto
            {
                Id = id,
                Message = "Sub-process updated successfully"
            };

            return ApiResponse<SubProcessLevelTwoOperationResponseDto>.SuccessResponse(
                response,
                "Sub-process updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating sub-process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<SubProcessLevelTwoOperationResponseDto>.ErrorResponse(
                "Failed to update sub-process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<bool>> DeleteSubProcessAsync(int accountId, int id)
    {
        try
        {
            // Check if exists
            var subProcess = await _repository.GetSubProcessByIdAsync(accountId, id);
            if (subProcess == null)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Sub-process not found",
                    new List<string> { $"Sub-process with ID {id} does not exist" });
            }

            // Check for related process details
            var hasProcessDetails = await _repository.HasProcessDetailsAsync(accountId, id);
            if (hasProcessDetails)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Cannot delete sub-process",
                    new List<string> { "This sub-process has associated process details and cannot be deleted" });
            }

            var result = await _repository.DeleteSubProcessAsync(accountId, id);

            if (!result)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Failed to delete sub-process",
                    new List<string> { "An error occurred while deleting the sub-process" });
            }

            return ApiResponse<bool>.SuccessResponse(true, "Sub-process deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting sub-process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<bool>.ErrorResponse(
                "Failed to delete sub-process",
                new List<string> { ex.Message });
        }
    }
}
