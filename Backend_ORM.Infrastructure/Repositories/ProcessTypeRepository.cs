using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for ProcessType operations using LINQ
/// Implements proper multi-tenancy and duplicate checking
/// </summary>
public class ProcessTypeRepository : IProcessTypeRepository
{
    private readonly ORMContext _context;

    public ProcessTypeRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<(List<OrmProcessType> processTypes, int totalCount)> GetProcessTypesAsync(
        int accountId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        // Build query with counts
        var query = _context.OrmProcessTypes
            .Where(pt => pt.AccountId == accountId)
            .Include(pt => pt.OrmProcesses)
            .AsQueryable();

        // Get total count
        var totalCount = await query.CountAsync();

        // Apply sorting
        query = sortBy.ToLower() switch
        {
            "code" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pt => pt.Code)
                : query.OrderBy(pt => pt.Code),
            "description" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pt => pt.Description)
                : query.OrderBy(pt => pt.Description),
            "creationdate" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pt => pt.CreationDate)
                : query.OrderBy(pt => pt.CreationDate),
            _ => query.OrderBy(pt => pt.Description)
        };

        // Apply pagination
        var processTypes = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (processTypes, totalCount);
    }

    public async Task<OrmProcessType?> GetProcessTypeByIdAsync(int accountId, int id)
    {
        return await _context.OrmProcessTypes
            .Include(pt => pt.OrmProcesses)
            .FirstOrDefaultAsync(pt => pt.AccountId == accountId && pt.Id == id);
    }

    public async Task<bool> ProcessTypeExistsAsync(int accountId, string description, int? excludeId = null)
    {
        // FIXED: Added AccountId to duplicate check (Critical Bug #3)
        var query = _context.OrmProcessTypes
            .Where(pt => pt.AccountId == accountId &&
                         pt.Description.ToLower().Trim() == description.ToLower().Trim());

        if (excludeId.HasValue)
        {
            query = query.Where(pt => pt.Id != excludeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<int> GetNextCodeAsync(int accountId)
    {
        // FIXED: Use correct table and filter by AccountId (Critical Bug #4)
        var maxCode = await _context.OrmProcessTypes
            .Where(pt => pt.AccountId == accountId)
            .MaxAsync(pt => (int?)pt.Code) ?? 0;

        return maxCode + 1;
    }

    public async Task<int> CreateProcessTypeAsync(OrmProcessType processType)
    {
        _context.OrmProcessTypes.Add(processType);
        await _context.SaveChangesAsync();
        return processType.Id;
    }

    public async Task<bool> UpdateProcessTypeAsync(OrmProcessType processType)
    {
        _context.OrmProcessTypes.Update(processType);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteProcessTypeAsync(int accountId, int id)
    {
        // FIXED: Added AccountId check (Critical Bug #2)
        var processType = await _context.OrmProcessTypes
            .FirstOrDefaultAsync(pt => pt.Id == id && pt.AccountId == accountId);

        if (processType == null)
            return false;

        _context.OrmProcessTypes.Remove(processType);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> HasProcessesAsync(int accountId, int processTypeId)
    {
        return await _context.OrmProcesses
            .AnyAsync(p => p.AccountId == accountId && p.ProcessTypeId == processTypeId);
    }
}
