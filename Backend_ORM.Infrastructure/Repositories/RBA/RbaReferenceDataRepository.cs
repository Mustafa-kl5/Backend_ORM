using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories.RBA;

public class RbaReferenceDataRepository : IRbaReferenceDataRepository
{
    private readonly ORMContext _context;

    public RbaReferenceDataRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ImpactLevelDto>> GetImpactLevelsAsync(int accountId, bool includeFinancial = false)
    {
        return await _context.OrmRiskImpacts
            .Where(i => i.AccountId == accountId)
            .Select(i => new ImpactLevelDto
            {
                Id = i.Id,
                Description = i.Description,
                Weight = i.Weight,
                FinancialImpact = includeFinancial ? i.FinancialImpact : null
            })
            .OrderBy(i => i.Weight)
            .ToListAsync();
    }

    public async Task<ImpactLevelDto?> GetImpactByAmountAsync(int accountId, decimal amount)
    {
        return await _context.OrmRiskImpacts
            .Where(i => i.AccountId == accountId && i.FinancialImpact.HasValue && i.FinancialImpact.Value <= (int)amount)
            .OrderByDescending(i => i.FinancialImpact)
            .Select(i => new ImpactLevelDto
            {
                Id = i.Id,
                Description = i.Description,
                Weight = i.Weight,
                FinancialImpact = i.FinancialImpact
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<OccurrenceLevelDto>> GetOccurrenceLevelsAsync(int accountId, bool includeMultipliers = false)
    {
        return await _context.OrmRiskOccurences
            .Where(o => o.AccountId == accountId)
            .Select(o => new OccurrenceLevelDto
            {
                Id = o.Id,
                Description = o.Description,
                Weight = o.Weight,
                Multiplier = includeMultipliers ? o.Multiplier : null
            })
            .OrderBy(o => o.Weight)
            .ToListAsync();
    }

    public async Task<InherentRiskScoreDto?> GetInherentScoreByValueAsync(int accountId, int score)
    {
        return await _context.OrmInherentRiskScores
            .Where(s => s.AccountId == accountId && s.UpperValue >= score)
            .OrderBy(s => s.UpperValue)
            .Select(s => new InherentRiskScoreDto
            {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                UpperValue = s.UpperValue
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<ControlEffectivenessLevelDto>> GetControlEffectivenessLevelsAsync(int accountId)
    {
        return await _context.OrmControlDesignEffectives
            .Where(c => c.AccountId == accountId)
            .Select(c => new ControlEffectivenessLevelDto
            {
                Id = c.Id,
                Description = c.Description,
                UpperValue = c.UpperValue
            })
            .OrderBy(c => c.UpperValue)
            .ToListAsync();
    }
}
