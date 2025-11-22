using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Core.Interfaces.Services;

namespace Backend_ORM.Services.Services;

/// <summary>
/// Service implementation for LinkProcess business logic
/// Handles validation, business rules, and coordinates repository operations
/// </summary>
public class LinkProcessService : ILinkProcessService
{
    private readonly ILinkProcessRepository _repository;

    public LinkProcessService(ILinkProcessRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get paginated list of processes with link counts
    /// </summary>
    public async Task<ApiResponse<ProcessListResponseDto>> GetProcessesAsync(
        int accountId,
        int? categoryId = null,
        int? processId = null,
        int? subProcessId = null,
        int? processDetailsId = null,
        int pageNumber = 1,
        int pageSize = 50,
        string sortBy = "Category",
        string sortDir = "ASC")
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<ProcessListResponseDto>.ErrorResponse("Invalid account ID");

            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 1 || pageSize > 1000)
                pageSize = 50;

            var validSortColumns = new[] { "category", "process", "subprocess", "details" };
            if (!validSortColumns.Contains(sortBy.ToLower()))
                sortBy = "Category";

            if (!new[] { "ASC", "DESC" }.Contains(sortDir.ToUpper()))
                sortDir = "ASC";

            // Get data from repository
            var (processes, totalCount) = await _repository.GetProcessesAsync(
                accountId, categoryId, processId, subProcessId, processDetailsId,
                pageNumber, pageSize, sortBy, sortDir);

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var responseData = new ProcessListResponseDto
            {
                Processes = processes,
                TotalRecords = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };

            return ApiResponse<ProcessListResponseDto>.SuccessResponse(
                responseData,
                processes.Any() ? "Processes retrieved successfully" : "No processes found"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<ProcessListResponseDto>.ErrorResponse(
                "Failed to retrieve processes",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get detailed process information with all links
    /// </summary>
    public async Task<ApiResponse<ProcessDetailDto>> GetProcessDetailAsync(int processDetailsId, int accountId)
    {
        try
        {
            // Validation
            if (processDetailsId <= 0)
                return ApiResponse<ProcessDetailDto>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<ProcessDetailDto>.ErrorResponse("Invalid account ID");

            // Get data from repository
            var processDetail = await _repository.GetProcessDetailAsync(processDetailsId, accountId);

            if (processDetail == null)
                return ApiResponse<ProcessDetailDto>.ErrorResponse("Process not found");

            // Apply business rules to determine CanDelete flags
            await ApplyCanDeleteFlags(processDetail, accountId);

            return ApiResponse<ProcessDetailDto>.SuccessResponse(
                processDetail,
                "Process details retrieved successfully"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<ProcessDetailDto>.ErrorResponse(
                "Failed to retrieve process details",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get business line links for a process
    /// </summary>
    public async Task<ApiResponse<List<BusinessLineDto>>> GetBusinessLinksAsync(int processDetailsId, int accountId)
    {
        try
        {
            if (processDetailsId <= 0)
                return ApiResponse<List<BusinessLineDto>>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<List<BusinessLineDto>>.ErrorResponse("Invalid account ID");

            var businessLines = await _repository.GetBusinessLinksAsync(processDetailsId, accountId);

            // Check CanDelete for each business line
            foreach (var bl in businessLines)
            {
                var (canDelete, _) = await _repository.CanDeleteBusinessLineLinkAsync(bl.Id, accountId);
                bl.CanDelete = canDelete;
            }

            return ApiResponse<List<BusinessLineDto>>.SuccessResponse(
                businessLines,
                businessLines.Any() ? "Business line links retrieved successfully" : "No business line links found"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<BusinessLineDto>>.ErrorResponse(
                "Failed to retrieve business line links",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get risk links for a process with controls
    /// </summary>
    public async Task<ApiResponse<List<RiskLinkDto>>> GetRiskLinksAsync(int processDetailsId, int accountId)
    {
        try
        {
            if (processDetailsId <= 0)
                return ApiResponse<List<RiskLinkDto>>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<List<RiskLinkDto>>.ErrorResponse("Invalid account ID");

            var risks = await _repository.GetRiskLinksAsync(processDetailsId, accountId);

            // Check CanDelete for each risk and control
            foreach (var risk in risks)
            {
                var (canDelete, _) = await _repository.CanDeleteRiskLinkAsync(risk.Id, accountId);
                risk.CanDelete = canDelete;

                foreach (var control in risk.Controls)
                {
                    var (canDeleteControl, _) = await _repository.CanDeleteControlLinkAsync(control.Id, accountId);
                    control.CanDelete = canDeleteControl;
                }
            }

            return ApiResponse<List<RiskLinkDto>>.SuccessResponse(
                risks,
                risks.Any() ? "Risk links retrieved successfully" : "No risk links found"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<RiskLinkDto>>.ErrorResponse(
                "Failed to retrieve risk links",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Delete a business line link
    /// </summary>
    public async Task<ApiResponse<DeleteResponseDto>> DeleteBusinessLineLinkAsync(
        int linkId, int processDetailsId, int accountId)
    {
        try
        {
            // Validation
            if (linkId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid link ID");

            if (processDetailsId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid account ID");

            // Check if can delete
            var (canDelete, reason) = await _repository.CanDeleteBusinessLineLinkAsync(linkId, accountId);
            if (!canDelete)
                return ApiResponse<DeleteResponseDto>.ErrorResponse(reason);

            // Delete the link
            var deleted = await _repository.DeleteBusinessLineLinkAsync(linkId, processDetailsId, accountId);
            if (!deleted)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Business line link not found");

            // Get remaining count
            var remainingCount = await _repository.GetBusinessLinksCountAsync(processDetailsId, accountId);

            var response = new DeleteResponseDto
            {
                Deleted = true,
                RemainingLinks = remainingCount,
                TotalDeleted = 1
            };

            return ApiResponse<DeleteResponseDto>.SuccessResponse(
                response,
                "Business line link deleted successfully"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<DeleteResponseDto>.ErrorResponse(
                "Failed to delete business line link",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Delete a risk link (cascades to controls)
    /// </summary>
    public async Task<ApiResponse<DeleteResponseDto>> DeleteRiskLinkAsync(
        int riskLinkId, int processDetailsId, int accountId)
    {
        try
        {
            // Validation
            if (riskLinkId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid risk link ID");

            if (processDetailsId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid account ID");

            // Check if can delete
            var (canDelete, reason) = await _repository.CanDeleteRiskLinkAsync(riskLinkId, accountId);
            if (!canDelete)
                return ApiResponse<DeleteResponseDto>.ErrorResponse(reason);

            // Delete the risk (and cascade controls)
            var totalDeleted = await _repository.DeleteRiskLinkAsync(riskLinkId, processDetailsId, accountId);
            if (totalDeleted == 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Risk link not found");

            var response = new DeleteResponseDto
            {
                Deleted = true,
                RemainingLinks = 0, // Not tracking for risks
                TotalDeleted = totalDeleted
            };

            return ApiResponse<DeleteResponseDto>.SuccessResponse(
                response,
                $"Risk link and {totalDeleted - 1} control(s) deleted successfully"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<DeleteResponseDto>.ErrorResponse(
                "Failed to delete risk link",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Delete a control link
    /// </summary>
    public async Task<ApiResponse<DeleteResponseDto>> DeleteControlLinkAsync(
        int controlLinkId, int riskLinkId, int accountId)
    {
        try
        {
            // Validation
            if (controlLinkId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid control link ID");

            if (riskLinkId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid risk link ID");

            if (accountId <= 0)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Invalid account ID");

            // Check if can delete
            var (canDelete, reason) = await _repository.CanDeleteControlLinkAsync(controlLinkId, accountId);
            if (!canDelete)
                return ApiResponse<DeleteResponseDto>.ErrorResponse(reason);

            // Delete the control
            var deleted = await _repository.DeleteControlLinkAsync(controlLinkId, riskLinkId, accountId);
            if (!deleted)
                return ApiResponse<DeleteResponseDto>.ErrorResponse("Control link not found");

            // Get remaining count
            var remainingCount = await _repository.GetControlLinksCountAsync(riskLinkId, accountId);

            var response = new DeleteResponseDto
            {
                Deleted = true,
                RemainingLinks = remainingCount,
                TotalDeleted = 1
            };

            return ApiResponse<DeleteResponseDto>.SuccessResponse(
                response,
                "Control link deleted successfully"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<DeleteResponseDto>.ErrorResponse(
                "Failed to delete control link",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Batch delete multiple links
    /// </summary>
    public async Task<ApiResponse<BatchDeleteResponseDto>> BatchDeleteAsync(
        BatchDeleteRequestDto request, int accountId)
    {
        try
        {
            // Validation
            if (request == null)
                return ApiResponse<BatchDeleteResponseDto>.ErrorResponse("Invalid request");

            if (request.ProcessDetailsId <= 0)
                return ApiResponse<BatchDeleteResponseDto>.ErrorResponse("Invalid process details ID");

            if (accountId <= 0)
                return ApiResponse<BatchDeleteResponseDto>.ErrorResponse("Invalid account ID");

            var response = new BatchDeleteResponseDto();

            // Delete business line links
            foreach (var blId in request.BusinessLineIds)
            {
                try
                {
                    var (canDelete, reason) = await _repository.CanDeleteBusinessLineLinkAsync(blId, accountId);
                    if (!canDelete)
                    {
                        response.Failures.Add(new DeleteFailureDto
                        {
                            Type = "BusinessLine",
                            Id = blId,
                            Reason = reason
                        });
                        continue;
                    }

                    var deleted = await _repository.DeleteBusinessLineLinkAsync(blId, request.ProcessDetailsId, accountId);
                    if (deleted)
                    {
                        response.BusinessLinesDeleted++;
                        response.TotalDeleted++;
                    }
                }
                catch (Exception ex)
                {
                    response.Failures.Add(new DeleteFailureDto
                    {
                        Type = "BusinessLine",
                        Id = blId,
                        Reason = ex.Message
                    });
                }
            }

            // Delete risk links (will cascade to controls)
            foreach (var riskId in request.RiskIds)
            {
                try
                {
                    var (canDelete, reason) = await _repository.CanDeleteRiskLinkAsync(riskId, accountId);
                    if (!canDelete)
                    {
                        response.Failures.Add(new DeleteFailureDto
                        {
                            Type = "Risk",
                            Id = riskId,
                            Reason = reason
                        });
                        continue;
                    }

                    var totalDeleted = await _repository.DeleteRiskLinkAsync(riskId, request.ProcessDetailsId, accountId);
                    if (totalDeleted > 0)
                    {
                        response.RisksDeleted++;
                        response.ControlsDeleted += (totalDeleted - 1); // Cascade deleted controls
                        response.TotalDeleted += totalDeleted;
                    }
                }
                catch (Exception ex)
                {
                    response.Failures.Add(new DeleteFailureDto
                    {
                        Type = "Risk",
                        Id = riskId,
                        Reason = ex.Message
                    });
                }
            }

            // Delete control links (only if not already deleted by risk cascade)
            foreach (var controlId in request.ControlIds)
            {
                try
                {
                    var (canDelete, reason) = await _repository.CanDeleteControlLinkAsync(controlId, accountId);
                    if (!canDelete)
                    {
                        response.Failures.Add(new DeleteFailureDto
                        {
                            Type = "Control",
                            Id = controlId,
                            Reason = reason
                        });
                        continue;
                    }

                    // Use the new DeleteControlLinkByIdAsync method that doesn't require riskLinkId
                    var deleted = await _repository.DeleteControlLinkByIdAsync(controlId, accountId);
                    if (deleted)
                    {
                        response.ControlsDeleted++;
                        response.TotalDeleted++;
                    }
                }
                catch (Exception ex)
                {
                    response.Failures.Add(new DeleteFailureDto
                    {
                        Type = "Control",
                        Id = controlId,
                        Reason = ex.Message
                    });
                }
            }

            if (response.Failures.Any())
            {
                return ApiResponse<BatchDeleteResponseDto>.SuccessResponse(
                    response,
                    $"Batch delete partially completed. {response.TotalDeleted} deleted, {response.Failures.Count} failed"
                );
            }

            return ApiResponse<BatchDeleteResponseDto>.SuccessResponse(
                response,
                $"Batch delete completed successfully. Total deleted: {response.TotalDeleted}"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<BatchDeleteResponseDto>.ErrorResponse(
                "Failed to execute batch delete",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Helper method to apply CanDelete flags to process detail DTO
    /// </summary>
    private async Task ApplyCanDeleteFlags(ProcessDetailDto processDetail, int accountId)
    {
        // Check business lines
        foreach (var bl in processDetail.BusinessLines)
        {
            var (canDelete, _) = await _repository.CanDeleteBusinessLineLinkAsync(bl.Id, accountId);
            bl.CanDelete = canDelete;
        }

        // Check risks and controls
        foreach (var risk in processDetail.Risks)
        {
            var (canDelete, _) = await _repository.CanDeleteRiskLinkAsync(risk.Id, accountId);
            risk.CanDelete = canDelete;

            foreach (var control in risk.Controls)
            {
                var (canDeleteControl, _) = await _repository.CanDeleteControlLinkAsync(control.Id, accountId);
                control.CanDelete = canDeleteControl;
            }
        }
    }

    /// <summary>
    /// Get all departments for lookup
    /// </summary>
    public async Task<ApiResponse<List<DepartmentLookupDto>>> GetDepartmentsAsync(int accountId)
    {
        try
        {
            if (accountId <= 0)
                return ApiResponse<List<DepartmentLookupDto>>.ErrorResponse("Invalid account ID");

            var departments = await _repository.GetDepartmentsAsync(accountId);
            return ApiResponse<List<DepartmentLookupDto>>.SuccessResponse(
                departments,
                $"Retrieved {departments.Count} departments"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<DepartmentLookupDto>>.ErrorResponse(
                "Failed to retrieve departments",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get all branches for lookup
    /// </summary>
    public async Task<ApiResponse<List<BranchLookupDto>>> GetBranchesAsync(int accountId)
    {
        try
        {
            if (accountId <= 0)
                return ApiResponse<List<BranchLookupDto>>.ErrorResponse("Invalid account ID");

            var branches = await _repository.GetBranchesAsync(accountId);
            return ApiResponse<List<BranchLookupDto>>.SuccessResponse(
                branches,
                $"Retrieved {branches.Count} branches"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<BranchLookupDto>>.ErrorResponse(
                "Failed to retrieve branches",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get all divisions for lookup
    /// </summary>
    public async Task<ApiResponse<List<DivisionLookupDto>>> GetDivisionsAsync(int accountId)
    {
        try
        {
            if (accountId <= 0)
                return ApiResponse<List<DivisionLookupDto>>.ErrorResponse("Invalid account ID");

            var divisions = await _repository.GetDivisionsAsync(accountId);
            return ApiResponse<List<DivisionLookupDto>>.SuccessResponse(
                divisions,
                $"Retrieved {divisions.Count} divisions"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<DivisionLookupDto>>.ErrorResponse(
                "Failed to retrieve divisions",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get all users for lookup
    /// </summary>
    public async Task<ApiResponse<List<UserLookupDto>>> GetUsersAsync(int accountId)
    {
        try
        {
            if (accountId <= 0)
                return ApiResponse<List<UserLookupDto>>.ErrorResponse("Invalid account ID");

            var users = await _repository.GetUsersAsync(accountId);
            
            // Compute DisplayName
            foreach (var user in users)
            {
                user.DisplayName = !string.IsNullOrEmpty(user.FirstName) || !string.IsNullOrEmpty(user.LastName)
                    ? $"{user.FirstName} {user.LastName}".Trim()
                    : user.Name;
            }

            return ApiResponse<List<UserLookupDto>>.SuccessResponse(
                users,
                $"Retrieved {users.Count} users"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<UserLookupDto>>.ErrorResponse(
                "Failed to retrieve users",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Add a business line link
    /// </summary>
    public async Task<ApiResponse<AddBusinessLineResponseDto>> AddBusinessLineLinkAsync(
        AddBusinessLineDto request,
        int accountId,
        int createdBy)
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse("Invalid account ID");

            if (request.ProcessDetailsId <= 0)
                return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse("Invalid process details ID");

            if (request.EntityId <= 0)
                return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse("Invalid entity ID");

            if (request.Source < 1 || request.Source > 4)
                return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse("Invalid source type. Must be 1-4 (Department/Branch/Division/User)");

            // Add link
            var (success, linkId, message) = await _repository.AddBusinessLineLinkAsync(
                request.ProcessDetailsId,
                request.Source,
                request.EntityId,
                accountId,
                createdBy
            );

            if (!success)
                return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse(message);

            var response = new AddBusinessLineResponseDto
            {
                LinkId = linkId,
                Message = message
            };

            return ApiResponse<AddBusinessLineResponseDto>.SuccessResponse(response, message);
        }
        catch (Exception ex)
        {
            return ApiResponse<AddBusinessLineResponseDto>.ErrorResponse(
                "Failed to add business line link",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get all risks for lookup
    /// </summary>
    public async Task<ApiResponse<List<RiskLookupDto>>> GetRisksAsync(int accountId)
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<List<RiskLookupDto>>.ErrorResponse("Invalid account ID");

            var risks = await _repository.GetRisksAsync(accountId);

            return ApiResponse<List<RiskLookupDto>>.SuccessResponse(
                risks,
                $"Retrieved {risks.Count} risks"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<RiskLookupDto>>.ErrorResponse(
                "Failed to retrieve risks",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Add a risk link
    /// </summary>
    public async Task<ApiResponse<AddRiskLinkResponseDto>> AddRiskLinkAsync(
        AddRiskLinkDto request,
        int accountId,
        int createdBy)
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<AddRiskLinkResponseDto>.ErrorResponse("Invalid account ID");

            if (request.ProcessDetailsId <= 0)
                return ApiResponse<AddRiskLinkResponseDto>.ErrorResponse("Invalid process details ID");

            if (request.RiskElementId <= 0)
                return ApiResponse<AddRiskLinkResponseDto>.ErrorResponse("Invalid risk element ID");

            // Add link
            var (success, linkId, message) = await _repository.AddRiskLinkAsync(
                request.ProcessDetailsId,
                request.RiskElementId,
                request.RiskImpactId,
                request.RiskOccurrenceId,
                accountId,
                createdBy
            );

            if (!success)
                return ApiResponse<AddRiskLinkResponseDto>.ErrorResponse(message);

            var response = new AddRiskLinkResponseDto
            {
                LinkId = linkId,
                Message = message
            };

            return ApiResponse<AddRiskLinkResponseDto>.SuccessResponse(response, message);
        }
        catch (Exception ex)
        {
            return ApiResponse<AddRiskLinkResponseDto>.ErrorResponse(
                "Failed to add risk link",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Get all controls for lookup
    /// </summary>
    public async Task<ApiResponse<List<ControlLookupDto>>> GetControlsAsync(int accountId)
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<List<ControlLookupDto>>.ErrorResponse("Invalid account ID");

            var controls = await _repository.GetControlsAsync(accountId);

            return ApiResponse<List<ControlLookupDto>>.SuccessResponse(
                controls,
                $"Retrieved {controls.Count} controls"
            );
        }
        catch (Exception ex)
        {
            return ApiResponse<List<ControlLookupDto>>.ErrorResponse(
                "Failed to retrieve controls",
                ex.Message
            );
        }
    }

    /// <summary>
    /// Add a control link to a risk
    /// </summary>
    public async Task<ApiResponse<AddControlLinkResponseDto>> AddControlLinkAsync(
        AddControlLinkDto request,
        int accountId,
        int createdBy)
    {
        try
        {
            // Validation
            if (accountId <= 0)
                return ApiResponse<AddControlLinkResponseDto>.ErrorResponse("Invalid account ID");

            if (request.ProcessRiskLinkId <= 0)
                return ApiResponse<AddControlLinkResponseDto>.ErrorResponse("Invalid risk link ID");

            if (request.ControlElementId <= 0)
                return ApiResponse<AddControlLinkResponseDto>.ErrorResponse("Invalid control element ID");

            // Add link
            var (success, linkId, message) = await _repository.AddControlLinkAsync(
                request.ProcessRiskLinkId,
                request.ControlElementId,
                request.ControlDesignEffectId,
                request.ResidualRiskExposure,
                request.ResidualRiskQuadrantId,
                accountId,
                createdBy
            );

            if (!success)
                return ApiResponse<AddControlLinkResponseDto>.ErrorResponse(message);

            var response = new AddControlLinkResponseDto
            {
                LinkId = linkId,
                Message = message
            };

            return ApiResponse<AddControlLinkResponseDto>.SuccessResponse(response, message);
        }
        catch (Exception ex)
        {
            return ApiResponse<AddControlLinkResponseDto>.ErrorResponse(
                "Failed to add control link",
                ex.Message
            );
        }
    }
}

