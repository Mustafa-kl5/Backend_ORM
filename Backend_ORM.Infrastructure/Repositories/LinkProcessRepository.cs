using Backend_ORM.Core.DTOs.LinkProcess;
using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for LinkProcess operations using LINQ
/// Replaces legacy stored procedures with modern EF Core queries
/// </summary>
public class LinkProcessRepository : ILinkProcessRepository
{
    private readonly ORMContext _context;

    public LinkProcessRepository(ORMContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Get paginated list of processes with link counts
    /// Replaces: ORMLinkProcessMonitor stored procedure
    /// </summary>
    public async Task<(List<ProcessListDto> Processes, int TotalCount)> GetProcessesAsync(
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
        // Build query with hierarchy and includes
        var query = _context.OrmProcessDetails
            .Where(pd => pd.AccountId == accountId)
            .Include(pd => pd.Subject)
                .ThenInclude(s => s.Process)
                    .ThenInclude(p => p.ProcessType)
            .Include(pd => pd.OrmProcessBlLinks)
            .Include(pd => pd.OrmProcessRiskLinks)
                .ThenInclude(rl => rl.OrmProcessControlLinks)
            .AsQueryable();

        // Apply filters
        if (categoryId.HasValue)
        {
            query = query.Where(pd => pd.Subject.Process.ProcessTypeId == categoryId.Value);
        }

        if (processId.HasValue)
        {
            query = query.Where(pd => pd.Subject.ProcessId == processId.Value);
        }

        if (subProcessId.HasValue)
        {
            query = query.Where(pd => pd.SubjectId == subProcessId.Value);
        }

        if (processDetailsId.HasValue)
        {
            query = query.Where(pd => pd.Id == processDetailsId.Value);
        }

        // Get total count before paging
        var totalCount = await query.CountAsync();

        // Project to DTO
        var processQuery = query.Select(pd => new ProcessListDto
        {
            ProcessDetailsId = pd.Id,
            Category = pd.Subject.Process.ProcessType.Description ?? string.Empty,
            Process = pd.Subject.Process.Description ?? string.Empty,
            SubProcess = pd.Subject.Description ?? string.Empty,
            Details = pd.Description,
            BusinessLineCount = pd.OrmProcessBlLinks.Count,
            RiskCount = pd.OrmProcessRiskLinks.Count,
            ControlCount = pd.OrmProcessRiskLinks
                .SelectMany(rl => rl.OrmProcessControlLinks)
                .Count()
        });

        // Apply sorting
        processQuery = sortBy.ToLower() switch
        {
            "category" => sortDir.ToUpper() == "DESC"
                ? processQuery.OrderByDescending(p => p.Category)
                : processQuery.OrderBy(p => p.Category),
            "process" => sortDir.ToUpper() == "DESC"
                ? processQuery.OrderByDescending(p => p.Process)
                : processQuery.OrderBy(p => p.Process),
            "subprocess" => sortDir.ToUpper() == "DESC"
                ? processQuery.OrderByDescending(p => p.SubProcess)
                : processQuery.OrderBy(p => p.SubProcess),
            "details" => sortDir.ToUpper() == "DESC"
                ? processQuery.OrderByDescending(p => p.Details)
                : processQuery.OrderBy(p => p.Details),
            _ => processQuery.OrderBy(p => p.Category)
                .ThenBy(p => p.Process)
                .ThenBy(p => p.SubProcess)
                .ThenBy(p => p.Details)
        };

        // Apply paging
        var processes = await processQuery
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (processes, totalCount);
    }

    /// <summary>
    /// Get detailed process information with all links
    /// Replaces: GetORMLinkProcessMonitor + ORMGetLinkedBusinessLine + ORMGetLinkedControl
    /// </summary>
    public async Task<ProcessDetailDto?> GetProcessDetailAsync(int processDetailsId, int accountId)
    {
        var processDetail = await _context.OrmProcessDetails
            .Where(pd => pd.Id == processDetailsId && pd.AccountId == accountId)
            .Include(pd => pd.Subject)
                .ThenInclude(s => s.Process)
                    .ThenInclude(p => p.ProcessType)
            .Include(pd => pd.OrmProcessBlLinks)
                .ThenInclude(bl => bl.Department)
            .Include(pd => pd.OrmProcessBlLinks)
                .ThenInclude(bl => bl.Branch)
            .Include(pd => pd.OrmProcessBlLinks)
                .ThenInclude(bl => bl.Division)
            .Include(pd => pd.OrmProcessBlLinks)
                .ThenInclude(bl => bl.User)
            .Include(pd => pd.OrmProcessRiskLinks)
                .ThenInclude(rl => rl.RiskCategory)
                    .ThenInclude(rc => rc.RiskCategory)
                        .ThenInclude(cat => cat.Category)
            .Include(pd => pd.OrmProcessRiskLinks)
                .ThenInclude(rl => rl.OrmProcessControlLinks)
                    .ThenInclude(cl => cl.ControlElement)
            .FirstOrDefaultAsync();

        if (processDetail == null)
            return null;

        // Map to DTO
        var dto = new ProcessDetailDto
        {
            ProcessHierarchy = new ProcessHierarchyDto
            {
                ProcessDetailsId = processDetail.Id,
                ProcessTypeId = processDetail.Subject.Process.ProcessTypeId,
                ProcessTypeDescription = processDetail.Subject.Process.ProcessType.Description ?? string.Empty,
                ProcessId = processDetail.Subject.ProcessId,
                ProcessDescription = processDetail.Subject.Process.Description ?? string.Empty,
                SubjectId = processDetail.SubjectId,
                SubjectDescription = processDetail.Subject.Description ?? string.Empty,
                DetailsDescription = processDetail.Description
            },
            BusinessLines = processDetail.OrmProcessBlLinks.Select(bl => new BusinessLineDto
            {
                Id = bl.Id,
                Source = bl.DepartmentId.HasValue ? 1 :
                         bl.BranchId.HasValue ? 2 :
                         bl.DivisionId.HasValue ? 3 : 4,
                EntityId = bl.DepartmentId ?? bl.BranchId ?? bl.DivisionId ?? bl.UserId ?? 0,
                EntityName = bl.DepartmentId.HasValue ? (bl.Department?.DepartmentName ?? string.Empty) :
                            bl.BranchId.HasValue ? (bl.Branch?.BranchName ?? string.Empty) :
                            bl.DivisionId.HasValue ? (bl.Division?.Description ?? string.Empty) :
                            bl.UserId.HasValue ? (bl.User?.Name ?? string.Empty) : string.Empty,
                CanDelete = true // Will be determined by business logic layer
            }).ToList(),
            Risks = processDetail.OrmProcessRiskLinks.Select(rl => new RiskLinkDto
            {
                Id = rl.Id,
                RiskCategoryId = rl.RiskCategoryId,
                RiskCategory = rl.RiskCategory.RiskCategory?.Category?.Description ?? string.Empty,
                RiskElement = rl.RiskCategory.Description ?? string.Empty,
                Code = rl.RiskCategory.Code?.ToString() ?? string.Empty,
                RiskImpactId = rl.RiskImpactId,
                RiskOccurrenceId = rl.RiskOccurenceId,
                InherentRiskScore = rl.InherentRiskScore,
                CanDelete = true, // Will be determined by business logic layer
                Controls = rl.OrmProcessControlLinks.Select(cl => new ControlLinkDto
                {
                    Id = cl.Id,
                    ControlElementId = cl.ControlElementId,
                    ControlElement = cl.ControlElement.Description ?? string.Empty,
                    Code = cl.ControlElement.Code ?? string.Empty,
                    ControlDesignEffectId = cl.ControlDesignEffectId,
                    ResidualRiskExposure = cl.ResidualRiskExposure,
                    ResidualRiskQuadrantId = cl.ResidualRiskQuadrantId,
                    CanDelete = true // Will be determined by business logic layer
                }).ToList()
            }).ToList()
        };

        return dto;
    }

    /// <summary>
    /// Get business line links for a process
    /// Replaces: ORMGetLinkedBusinessLine stored procedure
    /// </summary>
    public async Task<List<BusinessLineDto>> GetBusinessLinksAsync(int processDetailsId, int accountId)
    {
        var links = await _context.OrmProcessBlLinks
            .Where(bl => bl.ProcessDetailId == processDetailsId && bl.AccountId == accountId)
            .Include(bl => bl.Department)
            .Include(bl => bl.Branch)
            .Include(bl => bl.Division)
            .Include(bl => bl.User)
            .ToListAsync();

        return links.Select(bl => new BusinessLineDto
        {
            Id = bl.Id,
            Source = bl.DepartmentId.HasValue ? 1 :
                     bl.BranchId.HasValue ? 2 :
                     bl.DivisionId.HasValue ? 3 : 4,
            EntityId = bl.DepartmentId ?? bl.BranchId ?? bl.DivisionId ?? bl.UserId ?? 0,
            EntityName = bl.DepartmentId.HasValue ? (bl.Department?.DepartmentName ?? string.Empty) :
                        bl.BranchId.HasValue ? (bl.Branch?.BranchName ?? string.Empty) :
                        bl.DivisionId.HasValue ? (bl.Division?.Description ?? string.Empty) :
                        bl.UserId.HasValue ? (bl.User?.Name ?? string.Empty) : string.Empty,
            CanDelete = true
        }).ToList();
    }

    /// <summary>
    /// Get risk links for a process
    /// Replaces: ORMGetLinkedControl stored procedure (with DetailsId parameter)
    /// </summary>
    public async Task<List<RiskLinkDto>> GetRiskLinksAsync(int processDetailsId, int accountId)
    {
        var risks = await _context.OrmProcessRiskLinks
            .Where(rl => rl.ProcessDetailId == processDetailsId && rl.AccountId == accountId)
            .Include(rl => rl.RiskCategory)
                .ThenInclude(rc => rc.RiskCategory)
                    .ThenInclude(cat => cat.Category)
            .Include(rl => rl.OrmProcessControlLinks)
                .ThenInclude(cl => cl.ControlElement)
            .ToListAsync();

        return risks.Select(rl => new RiskLinkDto
        {
            Id = rl.Id,
            RiskCategoryId = rl.RiskCategoryId,
            RiskCategory = rl.RiskCategory.RiskCategory?.Category?.Description ?? string.Empty,
            RiskElement = rl.RiskCategory.Description ?? string.Empty,
            Code = rl.RiskCategory.Code?.ToString() ?? string.Empty,
            RiskImpactId = rl.RiskImpactId,
            RiskOccurrenceId = rl.RiskOccurenceId,
            InherentRiskScore = rl.InherentRiskScore,
            CanDelete = true,
            Controls = rl.OrmProcessControlLinks.Select(cl => new ControlLinkDto
            {
                Id = cl.Id,
                ControlElementId = cl.ControlElementId,
                ControlElement = cl.ControlElement.Description ?? string.Empty,
                Code = cl.ControlElement.Code ?? string.Empty,
                ControlDesignEffectId = cl.ControlDesignEffectId,
                ResidualRiskExposure = cl.ResidualRiskExposure,
                ResidualRiskQuadrantId = cl.ResidualRiskQuadrantId,
                CanDelete = true
            }).ToList()
        }).ToList();
    }

    /// <summary>
    /// Get control links for a specific risk
    /// Replaces: ORMGetLinkedControl stored procedure (with LinkedRiskId parameter)
    /// </summary>
    public async Task<List<ControlLinkDto>> GetControlLinksAsync(int riskLinkId, int accountId)
    {
        var controls = await _context.OrmProcessControlLinks
            .Where(cl => cl.ProcessRiskLinkId == riskLinkId && cl.AccountId == accountId)
            .Include(cl => cl.ControlElement)
            .ToListAsync();

        return controls.Select(cl => new ControlLinkDto
        {
            Id = cl.Id,
            ControlElementId = cl.ControlElementId,
            ControlElement = cl.ControlElement.Description ?? string.Empty,
            Code = cl.ControlElement.Code ?? string.Empty,
            ControlDesignEffectId = cl.ControlDesignEffectId,
            ResidualRiskExposure = cl.ResidualRiskExposure,
            ResidualRiskQuadrantId = cl.ResidualRiskQuadrantId,
            CanDelete = true
        }).ToList();
    }

    /// <summary>
    /// Delete a business line link
    /// Replaces: OrmDeleteLinkedProcessBL stored procedure
    /// </summary>
    public async Task<bool> DeleteBusinessLineLinkAsync(int linkId, int processDetailsId, int accountId)
    {
        var link = await _context.OrmProcessBlLinks
            .FirstOrDefaultAsync(bl => bl.Id == linkId 
                && bl.ProcessDetailId == processDetailsId 
                && bl.AccountId == accountId);

        if (link == null)
            return false;

        _context.OrmProcessBlLinks.Remove(link);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Delete a risk link and cascade to all child records
    /// Replaces: OrmDeleteProcessLinkedRisk stored procedure
    /// 
    /// STORED PROCEDURE LOGIC:
    /// 1. Delete OrmRBAControlQuestAnswers for all controls
    /// 2. Delete OrmRbaControlAsesmnt for all controls  
    /// 3. Delete OrmProcessControlLink (all controls)
    /// 4. Delete OrmRbaProcessRiskAsesmnt (risk assessments)
    /// 5. Delete OrmProcessRiskLink (the risk itself)
    /// </summary>
    public async Task<int> DeleteRiskLinkAsync(int riskLinkId, int processDetailsId, int accountId)
    {
        // First verify the risk exists and belongs to the account
        var riskLink = await _context.OrmProcessRiskLinks
            .Include(rl => rl.OrmProcessControlLinks)
                .ThenInclude(cl => cl.OrmRbacontrolQuestAnswers)  // Step 1 data
            .Include(rl => rl.OrmProcessControlLinks)
                .ThenInclude(cl => cl.OrmRbaControlAsesmnts)      // Step 2 data
            .Include(rl => rl.OrmProcessControlLinks)
                .ThenInclude(cl => cl.OrmRbaControlProcessControls) // Additional: not in SP but needed
            .Include(rl => rl.OrmRbaProcessRiskAsesmnts)          // Step 4 data
            .FirstOrDefaultAsync(rl => rl.Id == riskLinkId 
                && rl.ProcessDetailId == processDetailsId 
                && rl.AccountId == accountId);

        if (riskLink == null)
            return 0;

        var totalDeleted = 1; // The risk itself

        // STEP 1: Delete questionnaire answers for all controls
        foreach (var control in riskLink.OrmProcessControlLinks)
        {
            if (control.OrmRbacontrolQuestAnswers.Any())
            {
                _context.OrmRbacontrolQuestAnswers.RemoveRange(control.OrmRbacontrolQuestAnswers);
                totalDeleted += control.OrmRbacontrolQuestAnswers.Count;
            }
        }

        // STEP 2: Delete control assessments for all controls
        foreach (var control in riskLink.OrmProcessControlLinks)
        {
            if (control.OrmRbaControlAsesmnts.Any())
            {
                _context.OrmRbaControlAsesmnts.RemoveRange(control.OrmRbaControlAsesmnts);
                totalDeleted += control.OrmRbaControlAsesmnts.Count;
            }
        }

        // ADDITIONAL: Delete control process controls (not in original SP, but needed to avoid FK violations)
        foreach (var control in riskLink.OrmProcessControlLinks)
        {
            if (control.OrmRbaControlProcessControls.Any())
            {
                _context.OrmRbaControlProcessControls.RemoveRange(control.OrmRbaControlProcessControls);
                totalDeleted += control.OrmRbaControlProcessControls.Count;
            }
        }

        // STEP 3: Delete all controls
        if (riskLink.OrmProcessControlLinks.Any())
        {
            totalDeleted += riskLink.OrmProcessControlLinks.Count;
            _context.OrmProcessControlLinks.RemoveRange(riskLink.OrmProcessControlLinks);
        }

        // STEP 4: Delete risk assessments
        if (riskLink.OrmRbaProcessRiskAsesmnts.Any())
        {
            _context.OrmRbaProcessRiskAsesmnts.RemoveRange(riskLink.OrmRbaProcessRiskAsesmnts);
            totalDeleted += riskLink.OrmRbaProcessRiskAsesmnts.Count;
        }

        // STEP 5: Delete the risk link itself
        _context.OrmProcessRiskLinks.Remove(riskLink);
        await _context.SaveChangesAsync();
        
        return totalDeleted;
    }

    /// <summary>
    /// Delete a control link with all child records
    /// Replaces: OrmDeleteProcessLinkedControl stored procedure
    /// 
    /// NOTE: Original SP only had "Delete from OrmProcessControlLink where Id=@Id"
    /// This would FAIL with FK violations! We've enhanced it to properly cascade delete.
    /// 
    /// ENHANCED CASCADE LOGIC:
    /// 1. Delete OrmRBAControlQuestAnswers (questionnaire answers)
    /// 2. Delete OrmRbaControlAsesmnt (control assessments)
    /// 3. Delete OrmRbaControlProcessControl (process controls)
    /// 4. Delete OrmProcessControlLink (the control itself)
    /// </summary>
    public async Task<bool> DeleteControlLinkAsync(int controlLinkId, int riskLinkId, int accountId)
    {
        // Load control with all children
        var control = await _context.OrmProcessControlLinks
            .Include(cl => cl.OrmRbacontrolQuestAnswers)
            .Include(cl => cl.OrmRbaControlAsesmnts)
            .Include(cl => cl.OrmRbaControlProcessControls)
            .FirstOrDefaultAsync(cl => cl.Id == controlLinkId 
                && cl.ProcessRiskLinkId == riskLinkId 
                && cl.AccountId == accountId);

        if (control == null)
            return false;

        // STEP 1: Delete questionnaire answers
        if (control.OrmRbacontrolQuestAnswers.Any())
        {
            _context.OrmRbacontrolQuestAnswers.RemoveRange(control.OrmRbacontrolQuestAnswers);
        }

        // STEP 2: Delete control assessments
        if (control.OrmRbaControlAsesmnts.Any())
        {
            _context.OrmRbaControlAsesmnts.RemoveRange(control.OrmRbaControlAsesmnts);
        }

        // STEP 3: Delete process controls
        if (control.OrmRbaControlProcessControls.Any())
        {
            _context.OrmRbaControlProcessControls.RemoveRange(control.OrmRbaControlProcessControls);
        }

        // STEP 4: Delete the control itself
        _context.OrmProcessControlLinks.Remove(control);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Delete a control link by ID only (for batch operations)
    /// </summary>
    public async Task<bool> DeleteControlLinkByIdAsync(int controlLinkId, int accountId)
    {
        var control = await _context.OrmProcessControlLinks
            .Include(cl => cl.OrmRbaControlAsesmnts)
            .Include(cl => cl.OrmRbaControlProcessControls)
            .Include(cl => cl.OrmRbacontrolQuestAnswers)
            .FirstOrDefaultAsync(cl => cl.Id == controlLinkId 
                && cl.AccountId == accountId);

        if (control == null)
            return false;

        // Manually cascade delete child assessments, process controls, and questionnaire answers
        if (control.OrmRbaControlAsesmnts.Any())
        {
            _context.OrmRbaControlAsesmnts.RemoveRange(control.OrmRbaControlAsesmnts);
        }

        if (control.OrmRbaControlProcessControls.Any())
        {
            _context.OrmRbaControlProcessControls.RemoveRange(control.OrmRbaControlProcessControls);
        }

        if (control.OrmRbacontrolQuestAnswers.Any())
        {
            _context.OrmRbacontrolQuestAnswers.RemoveRange(control.OrmRbacontrolQuestAnswers);
        }

        _context.OrmProcessControlLinks.Remove(control);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Check if business line link can be deleted
    /// Checks for usage in RCSA, KRI, or other modules
    /// </summary>
    public async Task<(bool CanDelete, string Reason)> CanDeleteBusinessLineLinkAsync(int linkId, int accountId)
    {
        var link = await _context.OrmProcessBlLinks
            .Include(bl => bl.OrmProcessDetailBlworks)
            .FirstOrDefaultAsync(bl => bl.Id == linkId && bl.AccountId == accountId);

        if (link == null)
            return (false, "Link not found");

        // Check if link is used in process detail BL work
        if (link.OrmProcessDetailBlworks.Any())
            return (false, "Cannot delete: used in active assessments");

        // Could add more checks for KRI, RCSA modules here
        return (true, string.Empty);
    }

    /// <summary>
    /// Check if risk link can be deleted
    /// Checks for usage in RBA assessments
    /// </summary>
    public async Task<(bool CanDelete, string Reason)> CanDeleteRiskLinkAsync(int riskLinkId, int accountId)
    {
        var riskLink = await _context.OrmProcessRiskLinks
            .Include(rl => rl.OrmRbaProcessRiskAsesmnts)
            .FirstOrDefaultAsync(rl => rl.Id == riskLinkId && rl.AccountId == accountId);

        if (riskLink == null)
            return (false, "Risk link not found");

        // Check if used in RBA assessments
        if (riskLink.OrmRbaProcessRiskAsesmnts.Any())
            return (false, "Risk is used in active RBA assessment");

        return (true, string.Empty);
    }

    /// <summary>
    /// Check if control link can be deleted
    /// Checks for usage in RBA control assessments and RCSA
    /// </summary>
    public async Task<(bool CanDelete, string Reason)> CanDeleteControlLinkAsync(int controlLinkId, int accountId)
    {
        var control = await _context.OrmProcessControlLinks
            .Include(cl => cl.OrmRbaControlAsesmnts)
            .Include(cl => cl.OrmRbaControlProcessControls)
            .FirstOrDefaultAsync(cl => cl.Id == controlLinkId && cl.AccountId == accountId);

        if (control == null)
            return (false, "Control link not found");

        // Check if used in RBA control assessments
        if (control.OrmRbaControlAsesmnts.Any())
            return (false, "Control is used in active RBA control assessment");

        // Check if used in RBA process controls
        if (control.OrmRbaControlProcessControls.Any())
            return (false, "Control is used in active RCSA assessment");

        return (true, string.Empty);
    }

    /// <summary>
    /// Get count of remaining business line links
    /// </summary>
    public async Task<int> GetBusinessLinksCountAsync(int processDetailsId, int accountId)
    {
        return await _context.OrmProcessBlLinks
            .CountAsync(bl => bl.ProcessDetailId == processDetailsId && bl.AccountId == accountId);
    }

    /// <summary>
    /// Get count of remaining controls for a risk
    /// </summary>
    public async Task<int> GetControlLinksCountAsync(int riskLinkId, int accountId)
    {
        return await _context.OrmProcessControlLinks
            .CountAsync(cl => cl.ProcessRiskLinkId == riskLinkId && cl.AccountId == accountId);
    }

    /// <summary>
    /// Get all departments for lookup
    /// </summary>
    public async Task<List<DepartmentLookupDto>> GetDepartmentsAsync(int accountId)
    {
        return await _context.GrcDepartments
            .Where(d => d.AccountId == accountId)
            .OrderBy(d => d.DepartmentName)
            .Select(d => new DepartmentLookupDto
            {
                Id = d.DepartmentId,
                Name = d.DepartmentName
            })
            .ToListAsync();
    }

    /// <summary>
    /// Get all branches for lookup
    /// </summary>
    public async Task<List<BranchLookupDto>> GetBranchesAsync(int accountId)
    {
        return await _context.GrcBranches
            .Where(b => b.AccountId == accountId)
            .OrderBy(b => b.BranchName)
            .Select(b => new BranchLookupDto
            {
                BranchId = b.BranchId,
                BranchCode = b.BranchCode,
                BranchName = b.BranchName,
                City = b.City
            })
            .ToListAsync();
    }

    /// <summary>
    /// Get all divisions for lookup
    /// </summary>
    public async Task<List<DivisionLookupDto>> GetDivisionsAsync(int accountId)
    {
        return await _context.Divisions
            .Where(d => d.AccountId == accountId)
            .OrderBy(d => d.Description)
            .Select(d => new DivisionLookupDto
            {
                Id = d.Id,
                Description = d.Description,
                DepartmentId = d.DepartmentId
            })
            .ToListAsync();
    }

    /// <summary>
    /// Get all users for lookup
    /// </summary>
    public async Task<List<UserLookupDto>> GetUsersAsync(int accountId)
    {
        return await _context.GrcUsers
            .Where(u => u.AccountId == accountId && u.Deactivate != true)
            .OrderBy(u => u.Name)
            .Select(u => new UserLookupDto
            {
                UserId = u.UserId,
                Name = u.Name,
                UserLogin = u.UserLogin,
                EmailAddress = u.EmailAddress,
                FirstName = _context.UserDetails
                    .Where(ud => ud.UserId == u.UserId && ud.AccountId == accountId)
                    .Select(ud => ud.FirstName)
                    .FirstOrDefault(),
                LastName = _context.UserDetails
                    .Where(ud => ud.UserId == u.UserId && ud.AccountId == accountId)
                    .Select(ud => ud.LastName)
                    .FirstOrDefault(),
                DisplayName = u.Name // Will be computed later
            })
            .ToListAsync();
    }

    /// <summary>
    /// Add a business line link
    /// </summary>
    public async Task<(bool Success, int LinkId, string Message)> AddBusinessLineLinkAsync(
        int processDetailsId,
        int source,
        int entityId,
        int accountId,
        int createdBy)
    {
        try
        {
            // Check if process exists
            var processExists = await _context.OrmProcessDetails
                .AnyAsync(pd => pd.Id == processDetailsId && pd.AccountId == accountId);

            if (!processExists)
                return (false, 0, "Process not found");

        // Check if link already exists based on source type
        OrmProcessBlLink? existingLink = source switch
        {
            1 => await _context.OrmProcessBlLinks.FirstOrDefaultAsync(bl =>
                bl.ProcessDetailId == processDetailsId &&
                bl.DepartmentId == entityId &&
                bl.AccountId == accountId),
            2 => await _context.OrmProcessBlLinks.FirstOrDefaultAsync(bl =>
                bl.ProcessDetailId == processDetailsId &&
                bl.BranchId == entityId &&
                bl.AccountId == accountId),
            3 => await _context.OrmProcessBlLinks.FirstOrDefaultAsync(bl =>
                bl.ProcessDetailId == processDetailsId &&
                bl.DivisionId == entityId &&
                bl.AccountId == accountId),
            4 => await _context.OrmProcessBlLinks.FirstOrDefaultAsync(bl =>
                bl.ProcessDetailId == processDetailsId &&
                bl.UserId == entityId &&
                bl.AccountId == accountId),
            _ => null
        };

        if (existingLink != null)
        {
            var typeName = source switch
            {
                1 => "Department",
                2 => "Branch",
                3 => "Division",
                4 => "User",
                _ => "Entity"
            };
            return (false, 0, $"This {typeName} is already linked to this process (Link ID: {existingLink.Id})");
        }

        // Validate entity exists based on source type
        bool entityExists = source switch
        {
            1 => await _context.GrcDepartments.AnyAsync(d => d.DepartmentId == entityId && d.AccountId == accountId),
            2 => await _context.GrcBranches.AnyAsync(b => b.BranchId == entityId && b.AccountId == accountId),
            3 => await _context.Divisions.AnyAsync(d => d.Id == entityId && d.AccountId == accountId),
            4 => await _context.GrcUsers.AnyAsync(u => u.UserId == entityId && u.AccountId == accountId),
            _ => false
        };

        if (!entityExists)
            return (false, 0, "Selected entity not found");

        // Create new link with appropriate field set
        var newLink = new OrmProcessBlLink
        {
            ProcessDetailId = processDetailsId,
            DepartmentId = source == 1 ? entityId : null,
            BranchId = source == 2 ? entityId : null,
            DivisionId = source == 3 ? entityId : null,
            UserId = source == 4 ? entityId : null,
            AccountId = accountId,
            CreatedBy = createdBy,
            CreationDate = DateTime.Now
        };

        _context.OrmProcessBlLinks.Add(newLink);
        await _context.SaveChangesAsync();

        return (true, newLink.Id, "Business unit link added successfully");
        }
        catch (Exception ex)
        {
            return (false, 0, $"Error adding business unit link: {ex.Message}");
        }
    }

    /// <summary>
    /// Get all risks for lookup
    /// </summary>
    public async Task<List<RiskLookupDto>> GetRisksAsync(int accountId)
    {
        return await _context.OrmRiskElements
            .Where(r => r.AccountId == accountId)
            .OrderBy(r => r.Description)
            .Select(r => new RiskLookupDto
            {
                Id = r.Id,
                RiskCategoryId = r.RiskCategoryId,
                RiskCategoryDescription = _context.OrmRiskCategories
                    .Where(rc => rc.Id == r.RiskCategoryId)
                    .Select(rc => rc.Description)
                    .FirstOrDefault() ?? "Unknown",
                Code = r.Code,
                Description = r.Description,
                RiskDetails = r.RiskDetails
            })
            .ToListAsync();
    }

    /// <summary>
    /// Add a risk link
    /// </summary>
    public async Task<(bool Success, int LinkId, string Message)> AddRiskLinkAsync(
        int processDetailsId,
        int riskElementId,
        int? riskImpactId,
        int? riskOccurrenceId,
        int accountId,
        int createdBy)
    {
        try
        {
            // Check if process exists
            var processExists = await _context.OrmProcessDetails
                .AnyAsync(pd => pd.Id == processDetailsId && pd.AccountId == accountId);

            if (!processExists)
                return (false, 0, "Process not found");

            // Check if link already exists
            var existingLink = await _context.OrmProcessRiskLinks
                .Include(rl => rl.RiskCategory)
                .FirstOrDefaultAsync(rl =>
                    rl.ProcessDetailId == processDetailsId &&
                    rl.RiskCategoryId == riskElementId &&
                    rl.AccountId == accountId);

            if (existingLink != null)
            {
                var riskDescription = existingLink.RiskCategory?.Description ?? "Unknown Risk";
                return (false, 0, $"This risk '{riskDescription}' is already linked to this process (Link ID: {existingLink.Id})");
            }

            // Validate risk element exists
            var riskExists = await _context.OrmRiskElements
                .AnyAsync(r => r.Id == riskElementId && r.AccountId == accountId);

            if (!riskExists)
                return (false, 0, "Selected risk not found");

            // Create new risk link
            var newLink = new OrmProcessRiskLink
            {
                ProcessDetailId = processDetailsId,
                RiskCategoryId = riskElementId,
                RiskImpactId = riskImpactId,
                RiskOccurenceId = riskOccurrenceId,
                AccountId = accountId,
                CreatedBy = createdBy,
                CreationDate = DateTime.Now
            };

            _context.OrmProcessRiskLinks.Add(newLink);
            await _context.SaveChangesAsync();

            return (true, newLink.Id, "Risk link added successfully");
        }
        catch (Exception ex)
        {
            return (false, 0, $"Error adding risk link: {ex.Message}");
        }
    }

    /// <summary>
    /// Get all controls for lookup
    /// </summary>
    public async Task<List<ControlLookupDto>> GetControlsAsync(int accountId)
    {
        return await _context.OrmControlCategoryElements
            .Where(c => c.AccountId == accountId)
            .OrderBy(c => c.Description)
            .Select(c => new ControlLookupDto
            {
                Id = c.Id,
                Code = c.Code ?? string.Empty,
                Description = c.Description ?? string.Empty,
                ControlCategoryId = c.ControlCategoryId,
                ControlCategoryDescription = _context.OrmControlCategories
                    .Where(cc => cc.Id == c.ControlCategoryId)
                    .Select(cc => cc.Description)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }

    /// <summary>
    /// Add a control link to a risk
    /// </summary>
    public async Task<(bool Success, int LinkId, string Message)> AddControlLinkAsync(
        int processRiskLinkId,
        int controlElementId,
        int? controlDesignEffectId,
        int? residualRiskExposure,
        int? residualRiskQuadrantId,
        int accountId,
        int createdBy)
    {
        try
        {
            // Check if risk link exists
            var riskLinkExists = await _context.OrmProcessRiskLinks
                .AnyAsync(rl => rl.Id == processRiskLinkId && rl.AccountId == accountId);

            if (!riskLinkExists)
                return (false, 0, "Risk link not found");

            // Check if control link already exists
            var existingLink = await _context.OrmProcessControlLinks
                .Include(cl => cl.ControlElement)
                .FirstOrDefaultAsync(cl =>
                    cl.ProcessRiskLinkId == processRiskLinkId &&
                    cl.ControlElementId == controlElementId &&
                    cl.AccountId == accountId);

            if (existingLink != null)
            {
                var controlDescription = existingLink.ControlElement?.Description ?? "Unknown Control";
                return (false, 0, $"This control '{controlDescription}' is already linked to this risk (Link ID: {existingLink.Id})");
            }

            // Validate control element exists
            var controlExists = await _context.OrmControlCategoryElements
                .AnyAsync(c => c.Id == controlElementId && c.AccountId == accountId);

            if (!controlExists)
                return (false, 0, "Selected control not found");

            // Create new control link
            var newLink = new OrmProcessControlLink
            {
                ProcessRiskLinkId = processRiskLinkId,
                ControlElementId = controlElementId,
                ControlDesignEffectId = controlDesignEffectId,
                ResidualRiskExposure = residualRiskExposure,
                ResidualRiskQuadrantId = residualRiskQuadrantId,
                AccountId = accountId,
                CreatedBy = createdBy,
                CreationDate = DateTime.Now
            };

            _context.OrmProcessControlLinks.Add(newLink);
            await _context.SaveChangesAsync();

            return (true, newLink.Id, "Control link added successfully");
        }
        catch (Exception ex)
        {
            return (false, 0, $"Error adding control link: {ex.Message}");
        }
    }
}
