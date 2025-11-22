using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for SubProcess operations using LINQ
/// Implements proper multi-tenancy and duplicate checking
/// </summary>
public class SubProcessRepository : ISubProcessRepository
{
    private readonly ORMContext _context;

    public SubProcessRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<(List<OrmProcessSubject> subProcesses, int totalCount)> GetSubProcessesAsync(
        int accountId,
        int? processId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        // Build query with includes
        var query = _context.OrmProcessSubjects
            .Where(sp => sp.AccountId == accountId)
            .Include(sp => sp.Process)
            .Include(sp => sp.OrmProcessDetails)
            .AsQueryable();

        // Apply filter
        if (processId.HasValue)
        {
            query = query.Where(sp => sp.ProcessId == processId.Value);
        }

        // Get total count
        var totalCount = await query.CountAsync();

        // Apply sorting
        query = sortBy.ToLower() switch
        {
            "description" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(sp => sp.Description)
                : query.OrderBy(sp => sp.Description),
            "process" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(sp => sp.Process.Description)
                : query.OrderBy(sp => sp.Process.Description),
            "creationdate" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(sp => sp.CreationDate)
                : query.OrderBy(sp => sp.CreationDate),
            _ => query.OrderBy(sp => sp.Description)
        };

        // Apply pagination
        var subProcesses = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (subProcesses, totalCount);
    }

    public async Task<OrmProcessSubject?> GetSubProcessByIdAsync(int accountId, int id)
    {
        return await _context.OrmProcessSubjects
            .Include(sp => sp.Process)
            .Include(sp => sp.OrmProcessDetails)
            .FirstOrDefaultAsync(sp => sp.AccountId == accountId && sp.Id == id);
    }

    public async Task<bool> SubProcessExistsAsync(int accountId, int processId, string description, int? excludeId = null)
    {
        // FIXED: Added AccountId to duplicate check (Critical Bug - Level 3)
        var query = _context.OrmProcessSubjects
            .Where(sp => sp.AccountId == accountId &&
                         sp.ProcessId == processId &&
                         sp.Description != null &&
                         sp.Description.ToLower().Trim() == description.ToLower().Trim());

        if (excludeId.HasValue)
        {
            query = query.Where(sp => sp.Id != excludeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<int> CreateSubProcessAsync(OrmProcessSubject subProcess)
    {
        _context.OrmProcessSubjects.Add(subProcess);
        await _context.SaveChangesAsync();
        return subProcess.Id;
    }

    public async Task<bool> UpdateSubProcessAsync(OrmProcessSubject subProcess)
    {
        _context.OrmProcessSubjects.Update(subProcess);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteSubProcessAsync(int accountId, int id)
    {
        // FIXED: Added AccountId check (Critical Bug - Level 3)
        var subProcess = await _context.OrmProcessSubjects
            .FirstOrDefaultAsync(sp => sp.Id == id && sp.AccountId == accountId);

        if (subProcess == null)
            return false;

        _context.OrmProcessSubjects.Remove(subProcess);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> HasProcessDetailsAsync(int accountId, int subjectId)
    {
        return await _context.OrmProcessDetails
            .AnyAsync(pd => pd.AccountId == accountId && pd.SubjectId == subjectId);
    }
}
