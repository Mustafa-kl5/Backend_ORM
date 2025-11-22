using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.DTOs.Process;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.Extensions.Logging;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service implementation for Process operations
/// Handles business logic and validation
/// </summary>
public class ProcessService : IProcessService
{
    private readonly IProcessRepository _repository;
    private readonly IProcessTypeRepository _processTypeRepository;
    private readonly ILogger<ProcessService> _logger;

    public ProcessService(
        IProcessRepository repository,
        IProcessTypeRepository processTypeRepository,
        ILogger<ProcessService> logger)
    {
        _repository = repository;
        _processTypeRepository = processTypeRepository;
        _logger = logger;
    }

    public async Task<ApiResponse<ProcessLevelTwoListResponseDto>> GetProcessesAsync(
        int accountId,
        int? processTypeId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        try
        {
            var (processes, totalCount) = await _repository.GetProcessesAsync(
                accountId, processTypeId, pageNumber, pageSize, sortBy, sortDir);

            var processList = processes.Select(p => new ProcessLevelTwoListDto
            {
                Id = p.Id,
                ProcessTypeId = p.ProcessTypeId,
                ProcessTypeDescription = p.ProcessType?.Description ?? string.Empty,
                Description = p.Description ?? string.Empty,
                AttachedFile = p.AttachedFile,
                CreationDate = p.CreationDate,
                SubProcessCount = p.OrmProcessSubjects?.Count ?? 0
            }).ToList();

            var response = new ProcessLevelTwoListResponseDto
            {
                Processes = processList,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return ApiResponse<ProcessLevelTwoListResponseDto>.SuccessResponse(
                response,
                "Processes retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving processes for account {AccountId}", accountId);
            return ApiResponse<ProcessLevelTwoListResponseDto>.ErrorResponse(
                "Failed to retrieve processes",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessLevelTwoDetailDto>> GetProcessByIdAsync(int accountId, int id)
    {
        try
        {
            var process = await _repository.GetProcessByIdAsync(accountId, id);

            if (process == null)
            {
                return ApiResponse<ProcessLevelTwoDetailDto>.ErrorResponse(
                    "Process not found",
                    new List<string> { $"Process with ID {id} does not exist" });
            }

            var processDetail = new ProcessLevelTwoDetailDto
            {
                Id = process.Id,
                AccountId = process.AccountId,
                ProcessTypeId = process.ProcessTypeId,
                ProcessTypeDescription = process.ProcessType?.Description ?? string.Empty,
                Description = process.Description ?? string.Empty,
                AttachedFile = process.AttachedFile,
                CreatedBy = process.CreatedBy,
                CreationDate = process.CreationDate,
                LastUpdatedBy = process.LastUpdatedBy,
                LastUpdatedDate = process.LastUpdatedDate,
                SubProcessCount = process.OrmProcessSubjects?.Count ?? 0
            };

            return ApiResponse<ProcessLevelTwoDetailDto>.SuccessResponse(
                processDetail,
                "Process retrieved successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessLevelTwoDetailDto>.ErrorResponse(
                "Failed to retrieve process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessLevelTwoOperationResponseDto>> CreateProcessAsync(
        int accountId,
        int userId,
        CreateProcessLevelTwoDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Validate ProcessType exists
            var processType = await _processTypeRepository.GetProcessTypeByIdAsync(accountId, dto.ProcessTypeId);
            if (processType == null)
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Process type not found",
                    new List<string> { $"Process type with ID {dto.ProcessTypeId} does not exist" });
            }

            // Check for duplicates
            var exists = await _repository.ProcessExistsAsync(accountId, dto.ProcessTypeId, dto.Description);
            if (exists)
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Duplicate process",
                    new List<string> { $"A process with description '{dto.Description}' already exists for this process type" });
            }

            // Create entity
            var process = new OrmProcess
            {
                AccountId = accountId,
                ProcessTypeId = dto.ProcessTypeId,
                Description = dto.Description.Trim(),
                AttachedFile = dto.AttachedFile,
                CreatedBy = userId,
                CreationDate = DateTime.Now
            };

            var newId = await _repository.CreateProcessAsync(process);

            var response = new ProcessLevelTwoOperationResponseDto
            {
                Id = newId,
                Message = "Process created successfully"
            };

            return ApiResponse<ProcessLevelTwoOperationResponseDto>.SuccessResponse(
                response,
                "Process created successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating process for account {AccountId}", accountId);
            return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                "Failed to create process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<ProcessLevelTwoOperationResponseDto>> UpdateProcessAsync(
        int accountId,
        int userId,
        int id,
        UpdateProcessLevelTwoDto dto)
    {
        try
        {
            // Validate description
            if (string.IsNullOrWhiteSpace(dto.Description))
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Validation failed",
                    new List<string> { "Description is required" });
            }

            // Check if exists
            var process = await _repository.GetProcessByIdAsync(accountId, id);
            if (process == null)
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Process not found",
                    new List<string> { $"Process with ID {id} does not exist" });
            }

            // Validate ProcessType exists
            var processType = await _processTypeRepository.GetProcessTypeByIdAsync(accountId, dto.ProcessTypeId);
            if (processType == null)
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Process type not found",
                    new List<string> { $"Process type with ID {dto.ProcessTypeId} does not exist" });
            }

            // Check for duplicates (excluding current record)
            var exists = await _repository.ProcessExistsAsync(accountId, dto.ProcessTypeId, dto.Description, id);
            if (exists)
            {
                return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                    "Duplicate process",
                    new List<string> { $"A process with description '{dto.Description}' already exists for this process type" });
            }

            // Update entity
            process.ProcessTypeId = dto.ProcessTypeId;
            process.Description = dto.Description.Trim();
            process.AttachedFile = dto.AttachedFile;
            process.LastUpdatedBy = userId;
            process.LastUpdatedDate = DateTime.Now;

            await _repository.UpdateProcessAsync(process);

            var response = new ProcessLevelTwoOperationResponseDto
            {
                Id = id,
                Message = "Process updated successfully"
            };

            return ApiResponse<ProcessLevelTwoOperationResponseDto>.SuccessResponse(
                response,
                "Process updated successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<ProcessLevelTwoOperationResponseDto>.ErrorResponse(
                "Failed to update process",
                new List<string> { ex.Message });
        }
    }

    public async Task<ApiResponse<bool>> DeleteProcessAsync(int accountId, int id)
    {
        try
        {
            // Check if exists
            var process = await _repository.GetProcessByIdAsync(accountId, id);
            if (process == null)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Process not found",
                    new List<string> { $"Process with ID {id} does not exist" });
            }

            // Check for related sub-processes
            var hasSubProcesses = await _repository.HasSubProcessesAsync(accountId, id);
            if (hasSubProcesses)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Cannot delete process",
                    new List<string> { "This process has associated sub-processes and cannot be deleted" });
            }

            var result = await _repository.DeleteProcessAsync(accountId, id);

            if (!result)
            {
                return ApiResponse<bool>.ErrorResponse(
                    "Failed to delete process",
                    new List<string> { "An error occurred while deleting the process" });
            }

            return ApiResponse<bool>.SuccessResponse(true, "Process deleted successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting process {Id} for account {AccountId}", id, accountId);
            return ApiResponse<bool>.ErrorResponse(
                "Failed to delete process",
                new List<string> { ex.Message });
        }
    }
}
