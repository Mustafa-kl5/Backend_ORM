using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for Process operations using LINQ
/// Implements proper multi-tenancy and duplicate checking
/// </summary>
public class ProcessRepository : IProcessRepository
{
    private readonly ORMContext _context;

    public ProcessRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<(List<OrmProcess> processes, int totalCount)> GetProcessesAsync(
        int accountId,
        int? processTypeId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        // Build query with includes
        var query = _context.OrmProcesses
            .Where(p => p.AccountId == accountId)
            .Include(p => p.ProcessType)
            .Include(p => p.OrmProcessSubjects)
            .AsQueryable();

        // Apply filter
        if (processTypeId.HasValue)
        {
            query = query.Where(p => p.ProcessTypeId == processTypeId.Value);
        }

        // Get total count
        var totalCount = await query.CountAsync();

        // Apply sorting
        query = sortBy.ToLower() switch
        {
            "description" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(p => p.Description)
                : query.OrderBy(p => p.Description),
            "processtype" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(p => p.ProcessType.Description)
                : query.OrderBy(p => p.ProcessType.Description),
            "creationdate" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(p => p.CreationDate)
                : query.OrderBy(p => p.CreationDate),
            _ => query.OrderBy(p => p.Description)
        };

        // Apply pagination
        var processes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (processes, totalCount);
    }

    public async Task<OrmProcess?> GetProcessByIdAsync(int accountId, int id)
    {
        return await _context.OrmProcesses
            .Include(p => p.ProcessType)
            .Include(p => p.OrmProcessSubjects)
            .FirstOrDefaultAsync(p => p.AccountId == accountId && p.Id == id);
    }

    public async Task<bool> ProcessExistsAsync(int accountId, int processTypeId, string description, int? excludeId = null)
    {
        // FIXED: Added AccountId to duplicate check (Critical Bug - Level 2)
        var query = _context.OrmProcesses
            .Where(p => p.AccountId == accountId &&
                        p.ProcessTypeId == processTypeId &&
                        p.Description != null &&
                        p.Description.ToLower().Trim() == description.ToLower().Trim());

        if (excludeId.HasValue)
        {
            query = query.Where(p => p.Id != excludeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<int> CreateProcessAsync(OrmProcess process)
    {
        _context.OrmProcesses.Add(process);
        await _context.SaveChangesAsync();
        return process.Id;
    }

    public async Task<bool> UpdateProcessAsync(OrmProcess process)
    {
        _context.OrmProcesses.Update(process);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteProcessAsync(int accountId, int id)
    {
        // FIXED: Added AccountId check (Critical Bug - Level 2)
        var process = await _context.OrmProcesses
            .FirstOrDefaultAsync(p => p.Id == id && p.AccountId == accountId);

        if (process == null)
            return false;

        _context.OrmProcesses.Remove(process);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> HasSubProcessesAsync(int accountId, int processId)
    {
        return await _context.OrmProcessSubjects
            .AnyAsync(ps => ps.AccountId == accountId && ps.ProcessId == processId);
    }
}
