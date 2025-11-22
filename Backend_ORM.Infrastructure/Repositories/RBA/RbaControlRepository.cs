using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories.RBA;

public class RbaControlRepository : IRbaControlRepository
{
    private readonly ORMContext _context;

    public RbaControlRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ControlAssessmentDto>> GetProcessRiskControlsAsync(int accountId, int processId, int riskId)
    {
        return await _context.OrmProcessControlLinks
            .Where(pcl => pcl.AccountId == accountId 
                && pcl.ProcessRiskLink.ProcessDetailId == processId
                && pcl.ProcessRiskLink.RiskCategoryId == riskId)
            .Select(pcl => new ControlAssessmentDto
            {
                Id = pcl.Id,
                ControlCode = pcl.ControlElement.Code ?? "",
                ControlDescription = pcl.ControlElement.Description,
                RiskId = riskId,
                ControlAsse = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => (int?)a.Id)
                    .FirstOrDefault(),
                ControlDesignEffectId = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => (int?)a.ControlDesignEffectId)
                    .FirstOrDefault(),
                ResidualRiskExposure = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => (double?)a.ResidualRiskExposure)
                    .FirstOrDefault(),
                ResidualRiskExposureText = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => a.ResidualRiskExposureNavigation.Description)
                    .FirstOrDefault(),
                ResidualRiskExposureCode = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => (int?)a.ResidualRiskExposureNavigation.Code)
                    .FirstOrDefault(),
                ResidualRiskQuadrantText = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => a.ResidualRiskQuadrant.Description)
                    .FirstOrDefault(),
                ResidualRiskQuadrantCode = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => (int?)a.ResidualRiskQuadrant.Code)
                    .FirstOrDefault(),
                Comments = pcl.OrmRbaControlAsesmnts
                    .Where(a => a.ControlProccessRiskId == pcl.Id)
                    .Select(a => a.Comments)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }

    public async Task<ControlAssessmentDto?> GetControlAssessmentByIdAsync(int accountId, int assessmentId)
    {
        return await _context.OrmRbaControlAsesmnts
            .Where(a => a.AccountId == accountId && a.Id == assessmentId)
            .Select(a => new ControlAssessmentDto
            {
                Id = a.Id,
                ControlCode = a.ControlProccessRisk.ControlElement.Code ?? "",
                ControlDescription = a.ControlProccessRisk.ControlElement.Description,
                RiskId = a.ControlProccessRisk.ProcessRiskLink.RiskCategoryId,
                ControlDesignEffectId = a.ControlDesignEffectId,
                ResidualRiskExposure = (double?)a.ResidualRiskExposure,
                ResidualRiskExposureText = a.ResidualRiskQuadrant.Description,
                ResidualRiskExposureCode = a.ResidualRiskQuadrantId,
                Comments = a.Comments
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateControlAssessmentAsync(ControlAssessmentCreateDto dto)
    {
        var entity = new OrmRbaControlAsesmnt
        {
            AccountId = dto.AccountId,
            ControlProccessRiskId = dto.ControlProccessRiskId,
            ControlDesignEffectId = dto.ControlDesignEffectId,
            ResidualRiskExposure = dto.ResidualRiskExposure,
            ResidualRiskQuadrantId = dto.ResidualRiskQuadrantId,
            Comments = dto.Comments,
            CreatedBy = dto.CreatedBy,
            CreationDate = DateTime.Now
        };

        _context.OrmRbaControlAsesmnts.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateControlAssessmentAsync(int assessmentId, ControlAssessmentUpdateDto dto)
    {
        var entity = await _context.OrmRbaControlAsesmnts
            .FirstOrDefaultAsync(a => a.Id == assessmentId);

        if (entity == null)
            return false;

        entity.ControlDesignEffectId = dto.ControlDesignEffectId;
        entity.ResidualRiskExposure = dto.ResidualRiskExposure;
        entity.ResidualRiskQuadrantId = dto.ResidualRiskQuadrantId;
        entity.Comments = dto.Comments;
        entity.LastUpdatedBy = dto.LastUpdatedBy;
        entity.LastUpdateDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteControlAssessmentAsync(int accountId, int assessmentId)
    {
        var entity = await _context.OrmRbaControlAsesmnts
            .FirstOrDefaultAsync(a => a.AccountId == accountId && a.Id == assessmentId);

        if (entity == null)
            return false;

        _context.OrmRbaControlAsesmnts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
