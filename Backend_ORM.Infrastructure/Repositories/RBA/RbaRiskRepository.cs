using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories.RBA;

public class RbaRiskRepository : IRbaRiskRepository
{
    private readonly ORMContext _context;

    public RbaRiskRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(int accountId)
    {
        return await _context.OrmCategories
            .Where(c => c.AccountId == accountId)
            .Select(c => new CategoryDto
            {
                Id = c.Id,
                Description = c.Description
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<RiskCategoryDto>> GetRiskCategoriesByCategoryAsync(int accountId, int categoryId)
    {
        return await _context.OrmRiskCategories
            .Where(rc => rc.AccountId == accountId && rc.CategoryId == categoryId)
            .Select(rc => new RiskCategoryDto
            {
                RiskId = rc.Id,
                CategoryId = rc.CategoryId,
                RiskDescription = rc.Description,
                Reference = rc.Code.ToString()
            })
            .ToListAsync();
    }

    public async Task<RiskAssessmentDto?> GetRiskAssessmentByElementAsync(int accountId, int riskElementId)
    {
        return await _context.OrmRbaRisks
            .Where(r => r.AccountId == accountId && r.RiskElementId == riskElementId)
            .Select(r => new RiskAssessmentDto
            {
                RiskId = r.RiskElementId,
                RiskCategoryId = r.RiskCategoryId,
                RiskDescription = r.RiskElement.Description,
                ImpactWeight = r.RiskImpact.Weight,
                OccWeight = r.RiskOccurence.Weight,
                InherentRiskValue = r.InherentRiskValue,
                InherentDesc = r.InherentRiskScoreNavigation.Description,
                CodeScore = r.InherentRiskScoreNavigation.Code,
                Comments = r.Comments
            })
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<RiskAssessmentDetailDto>> GetRiskAssessmentsByCategoryAsync(int accountId, int riskCategoryId)
    {
        return await _context.OrmRbaRisks
            .Where(r => r.AccountId == accountId && r.RiskCategoryId == riskCategoryId)
            .Select(r => new RiskAssessmentDetailDto
            {
                RiskId = r.RiskElementId,
                RiskCategoryId = r.RiskCategoryId,
                RiskDescription = r.RiskElement.Description,
                Reference = r.RiskElement.Code ?? "", 
                ImpactWeight = r.RiskImpact.Weight,
                OccWeight = r.RiskOccurence.Weight,
                InherentRiskValue = r.InherentRiskValue,
                InherentDesc = r.InherentRiskScoreNavigation.Description,
                CodeScore = r.InherentRiskScoreNavigation.Code,
                Comments = r.Comments,
                RiskDetails = r.RiskElement.RiskDetails
            })
            .ToListAsync();
    }

    public async Task<int> CreateRiskAssessmentAsync(RiskAssessmentCreateDto dto)
    {
        var entity = new OrmRbaRisk
        {
            AccountId = dto.AccountId,
            RiskCategoryId = dto.RiskCategoryId,
            RiskElementId = dto.RiskElementId,
            RiskImpactId = dto.RiskImpactId,
            RiskOccurenceId = dto.RiskOccurenceId,
            InherentRiskScore = dto.InherentRiskScore,
            InherentRiskValue = dto.InherentRiskValue,
            Comments = dto.Comments,
            CreatedBy = dto.CreatedBy,
            CreationDate = DateTime.Now
        };

        _context.OrmRbaRisks.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateRiskAssessmentAsync(int riskElementId, RiskAssessmentUpdateDto dto)
    {
        var entity = await _context.OrmRbaRisks
            .FirstOrDefaultAsync(r => r.RiskElementId == riskElementId);

        if (entity == null)
            return false;

        entity.RiskImpactId = dto.RiskImpactId;
        entity.RiskOccurenceId = dto.RiskOccurenceId;
        entity.InherentRiskScore = dto.InherentRiskScore;
        entity.InherentRiskValue = dto.InherentRiskValue;
        entity.Comments = dto.Comments;
        entity.LastUpdatedBy = dto.LastUpdatedBy;
        entity.LastUpdateDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteRiskAssessmentAsync(int accountId, int riskElementId)
    {
        var entity = await _context.OrmRbaRisks
            .FirstOrDefaultAsync(r => r.AccountId == accountId && r.RiskElementId == riskElementId);

        if (entity == null)
            return false;

        _context.OrmRbaRisks.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
