using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service implementation for ProcessType operations
/// Handles business logic and validation
/// </summary>
public class ProcessTypeService : IProcessTypeService
{
    private readonly IProcessTypeRepository _repository;
    private readonly ILogger<ProcessTypeService> _logger;

    public ProcessTypeService(
        IProcessTypeRepository repository,
        ILogger<ProcessTypeService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<ApiResponse<ProcessTypeListResponseDto>> GetProcessTypesAsync(
        int accountId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        try
        {
            var (processTypes, totalCount) = await _repository.GetProcessTypesAsync(
                accountId, pageNumber, pageSize, sortBy, sortDir);

            var processTypeList = processTypes.Select(pt => new ProcessTypeListDto
            {
                Id = pt.Id,
                Code = pt.Code,
                Description = pt.Description ?? string.Empty,
                CreationDate = pt.CreationDate,
                ProcessCount = pt.OrmProcesses?.Count ?? 0
            }).ToList();

            var response = new ProcessTypeListResponseDto
            {
                ProcessTypes = processTypeList,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return ApiResponse<ProcessTypeListResponseDto>.SuccessResponse(
                response,
                "Process types retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process types for account {AccountId}", accountId);
            return ApiResponse<ProcessTypeListResponseDto>.ErrorResponse(
                "Failed to retrieve process types",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessTypeDetailDto>> GetProcessTypeByIdAsync(int accountId, int id)
    {
        try
        {
            var processType = await _repository.GetProcessTypeByIdAsync(accountId, id);

            if (processType == null)
            {
                return ApiResponse<ProcessTypeDetailDto>.ErrorResponse(
                    "Process type not found",
                    new List<string> { $"Process type with ID {id} does not exist" });
            }

            var processTypeDetail = new ProcessTypeDetailDto
            {
                Id = processType.Id,
                AccountId = processType.AccountId,
                Code = processType.Code,
                Description = processType.Description ?? string.Empty,
                CreatedBy = processType.CreatedBy,
                CreationDate = processType.CreationDate,
                LastUpdatedBy = processType.LastUpdatedBy,
                LastUpdatedDate = processType.LastUpdatedDate,
                ProcessCount = processType.OrmProcesses?.Count ?? 0
            };

            return ApiResponse<ProcessTypeDetailDto>.SuccessResponse(
                processTypeDetail,
                "Process type retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process type {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessTypeDetailDto>.ErrorResponse(
                "Failed to retrieve process type",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessTypeOperationResponseDto>> CreateProcessTypeAsync(
        int accountId,
        int userId,
        CreateProcessTypeDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Check for duplicates
            var exists = await _repository.ProcessTypeExistsAsync(accountId, dto.Description);
            if (exists)
            {
                return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                    "Duplicate process type",
                    new List<string> { $"A process type with description '{dto.Description}' already exists" });
            }

            // Get next code
            var nextCode = await _repository.GetNextCodeAsync(accountId);

            // Create entity
            var processType = new OrmProcessType
            {
                AccountId = accountId,
                Code = nextCode,
                Description = dto.Description.Trim(),
                CreatedBy = userId,
                CreationDate = DateTime.Now
            };

            var newId = await _repository.CreateProcessTypeAsync(processType);

            var response = new ProcessTypeOperationResponseDto
            {
                Id = newId,
                Message = "Process type created successfully"
            };

            return ApiResponse<ProcessTypeOperationResponseDto>.SuccessResponse(
                response,
                "Process type created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating process type for account {AccountId}", accountId);
            return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                "Failed to create process type",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessTypeOperationResponseDto>> UpdateProcessTypeAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessTypeDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Check if exists
            var processType = await _repository.GetProcessTypeByIdAsync(accountId, id);
            if (processType == null)
            {
                return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                    "Process type not found",
                    new List<string> { $"Process type with ID {id} does not exist" });
            }

            // Check for duplicates (excluding current record)
            var exists = await _repository.ProcessTypeExistsAsync(accountId, dto.Description, id);
            if (exists)
            {
                return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                    "Duplicate process type",
                    new List<string> { $"A process type with description '{dto.Description}' already exists" });
            }

            // Update entity
            processType.Description = dto.Description.Trim();
            processType.LastUpdatedBy = userId;
            processType.LastUpdatedDate = DateTime.Now;

            await _repository.UpdateProcessTypeAsync(processType);

            var response = new ProcessTypeOperationResponseDto
            {
                Id = id,
                Message = "Process type updated successfully"
            };

            return ApiResponse<ProcessTypeOperationResponseDto>.SuccessResponse(
                response,
                "Process type updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating process type {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessTypeOperationResponseDto>.ErrorResponse(
                "Failed to update process type",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<bool>> DeleteProcessTypeAsync(int accountId, int id)
    {
        try
        {
            // Check if exists
            var processType = await _repository.GetProcessTypeByIdAsync(accountId, id);
            if (processType == null)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Process type not found",
                    new List<string> { $"Process type with ID {id} does not exist" });
            }

            // Check for related processes
            var hasProcesses = await _repository.HasProcessesAsync(accountId, id);
            if (hasProcesses)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Cannot delete process type",
                    new List<string> { "This process type has associated processes and cannot be deleted" });
            }

            var result = await _repository.DeleteProcessTypeAsync(accountId, id);

            if (!result)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Failed to delete process type",
                    new List<string> { "An error occurred while deleting the process type" });
            }

            return ApiResponse<bool>.SuccessResponse(true, "Process type deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting process type {Id} for account {AccountId}", id, accountId);
            return ApiResponse<bool>.ErrorResponse(
                "Failed to delete process type",
                new List<string> { ex.Message });
        }
    }
}
