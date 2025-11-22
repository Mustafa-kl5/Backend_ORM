using Backend_ORM.Core.Interfaces.Repositories;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for ProcessDetail operations using LINQ
/// Implements proper multi-tenancy and duplicate checking
/// </summary>
public class ProcessDetailRepository : IProcessDetailRepository
{
    private readonly ORMContext _context;

    public ProcessDetailRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<(List<OrmProcessDetail> processDetails, int totalCount)> GetProcessDetailsAsync(
        int accountId,
        int? subjectId,
        int pageNumber,
        int pageSize,
        string sortBy,
        string sortDir)
    {
        // Build query with includes
        var query = _context.OrmProcessDetails
            .Where(pd => pd.AccountId == accountId)
            .Include(pd => pd.Subject)
            .AsQueryable();

        // Apply filter
        if (subjectId.HasValue)
        {
            query = query.Where(pd => pd.SubjectId == subjectId.Value);
        }

        // Get total count
        var totalCount = await query.CountAsync();

        // Apply sorting
        query = sortBy.ToLower() switch
        {
            "description" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pd => pd.Description)
                : query.OrderBy(pd => pd.Description),
            "subject" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pd => pd.Subject.Description)
                : query.OrderBy(pd => pd.Subject.Description),
            "creationdate" => sortDir.ToUpper() == "DESC"
                ? query.OrderByDescending(pd => pd.CreationDate)
                : query.OrderBy(pd => pd.CreationDate),
            _ => query.OrderBy(pd => pd.Description)
        };

        // Apply pagination
        var processDetails = await query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (processDetails, totalCount);
    }

    public async Task<OrmProcessDetail?> GetProcessDetailByIdAsync(int accountId, int id)
    {
        return await _context.OrmProcessDetails
            .Include(pd => pd.Subject)
            .FirstOrDefaultAsync(pd => pd.AccountId == accountId && pd.Id == id);
    }

    public async Task<bool> ProcessDetailExistsAsync(int accountId, int subjectId, string description, int? excludeId = null)
    {
        // FIXED: Added AccountId to duplicate check (Critical Bug - Level 4)
        var query = _context.OrmProcessDetails
            .Where(pd => pd.AccountId == accountId &&
                         pd.SubjectId == subjectId &&
                         pd.Description != null &&
                         pd.Description.ToLower().Trim() == description.ToLower().Trim());

        if (excludeId.HasValue)
        {
            query = query.Where(pd => pd.Id != excludeId.Value);
        }

        return await query.AnyAsync();
    }

    public async Task<int> CreateProcessDetailAsync(OrmProcessDetail processDetail)
    {
        _context.OrmProcessDetails.Add(processDetail);
        await _context.SaveChangesAsync();
        return processDetail.Id;
    }

    public async Task<bool> UpdateProcessDetailAsync(OrmProcessDetail processDetail)
    {
        _context.OrmProcessDetails.Update(processDetail);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<bool> DeleteProcessDetailAsync(int accountId, int id)
    {
        // FIXED: Added AccountId check (Critical Bug - Level 4)
        var processDetail = await _context.OrmProcessDetails
            .FirstOrDefaultAsync(pd => pd.Id == id && pd.AccountId == accountId);

        if (processDetail == null)
            return false;

        _context.OrmProcessDetails.Remove(processDetail);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
