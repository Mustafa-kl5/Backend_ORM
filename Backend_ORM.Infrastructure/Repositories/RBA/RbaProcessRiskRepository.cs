using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Infrastructure.Context;
using Backend_ORM.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_ORM.Infrastructure.Repositories.RBA;

public class RbaProcessRiskRepository : IRbaProcessRiskRepository
{
    private readonly ORMContext _context;

    public RbaProcessRiskRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProcessRiskSummaryDto>> GetProcessesWithRiskSummaryAsync(int accountId)
    {
        return await _context.OrmProcessDetails
            .Where(pd => pd.AccountId == accountId)
            .Select(pd => new ProcessRiskSummaryDto
            {
                ProcessDetailsId = pd.Id,
                ProcessType = pd.Subject.Process.ProcessType.Description,
                ProcessCategory = pd.Subject.Process.Description,
                ProcessSubject = pd.Subject.Description,
                ProcessDetails = pd.Description,
                MaxRiskInherentRiskScore = pd.OrmRbaProcessRiskAsesmnts
                    .OrderByDescending(r => r.InherentRiskScore)
                    .Select(r => r.InherentRiskScoreNavigation.Description)
                    .FirstOrDefault(),
                MaxRiskInherentCode = pd.OrmRbaProcessRiskAsesmnts
                    .OrderByDescending(r => r.InherentRiskScore)
                    .Select(r => (int?)r.InherentRiskScoreNavigation.Code)
                    .FirstOrDefault(),
                AvgInherentRiskValue = pd.OrmRbaProcessRiskAsesmnts.Any()
                    ? pd.OrmRbaProcessRiskAsesmnts.Average(r => (double?)r.InherentRiskValue)
                    : null
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<ProcessRiskAssessmentDto>> GetProcessRisksAsync(int accountId, int processId)
    {
        return await _context.OrmProcessRiskLinks
            .Where(prl => prl.AccountId == accountId && prl.ProcessDetailId == processId)
            .Select(prl => new ProcessRiskAssessmentDto
            {
                RiskId = prl.RiskCategoryId,
                RiskDesc = prl.RiskCategory.Description,
                ProcessDetailsId = prl.ProcessDetailId,
                RiskProcessLinkId = prl.Id,
                ProcessRbaId = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => (int?)a.Id)
                    .FirstOrDefault(),
                RiskWeight = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => (int?)a.RiskImpact.Weight)
                    .FirstOrDefault(),
                OccWeight = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => (int?)a.RiskOccurence.Weight)
                    .FirstOrDefault(),
                InherentRiskValue = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => (int?)a.InherentRiskValue)
                    .FirstOrDefault(),
                InherentScore = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => a.InherentRiskScoreNavigation.Description)
                    .FirstOrDefault(),
                InherentScoreCode = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => (int?)a.InherentRiskScoreNavigation.Code)
                    .FirstOrDefault(),
                FinancialImpact = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => a.FinancialImpact)
                    .FirstOrDefault(),
                GrossLossExpectation = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => a.GrossLossExpectation)
                    .FirstOrDefault(),
                Comments = prl.OrmRbaProcessRiskAsesmnts
                    .Where(a => a.RiskProcessLinkId == prl.Id)
                    .Select(a => a.Comments)
                    .FirstOrDefault()
            })
            .ToListAsync();
    }

    public async Task<ProcessRiskAssessmentDto?> GetProcessRiskByIdAsync(int accountId, int assessmentId)
    {
        return await _context.OrmRbaProcessRiskAsesmnts
            .Where(a => a.AccountId == accountId && a.Id == assessmentId)
            .Select(a => new ProcessRiskAssessmentDto
            {
                RiskId = a.RiskElementId.HasValue ? a.RiskElementId.Value : 0,
                RiskDesc = a.RiskElement != null ? a.RiskElement.Description : "",
                ProcessDetailsId = a.RiskProcessLink != null ? a.RiskProcessLink.ProcessDetailId : 0,
                RiskProcessLinkId = a.RiskProcessLinkId ?? 0,
                ProcessRbaId = a.Id,
                RiskWeight = (int?)a.RiskImpact.Weight,
                OccWeight = (int?)a.RiskOccurence.Weight,
                InherentRiskValue = (int?)a.InherentRiskValue,
                InherentScore = a.InherentRiskScoreNavigation.Description,
                InherentScoreCode = (int?)a.InherentRiskScoreNavigation.Code,
                FinancialImpact = a.FinancialImpact,
                GrossLossExpectation = a.GrossLossExpectation,
                Comments = a.Comments
            })
            .FirstOrDefaultAsync();
    }

    public async Task<int> CreateProcessRiskAssessmentAsync(ProcessRiskAssessmentCreateDto dto)
    {
        // Get RiskCategoryId from RiskElement first
        var riskElement = await _context.OrmRiskElements
            .FirstOrDefaultAsync(re => re.Id == dto.RiskElementId);

        var entity = new OrmRbaProcessRiskAsesmnt
        {
            AccountId = dto.AccountId,
            ProcessDetailId = dto.ProcessDetailId ?? 0,
            RiskProcessLinkId = dto.RiskProcessLinkId,
            RiskElementId = dto.RiskElementId,
            RiskCategoryId = riskElement?.RiskCategoryId ?? 0,
            RiskImpactId = dto.RiskImpactId,
            RiskOccurenceId = dto.RiskOccurenceId,
            InherentRiskScore = dto.InherentRiskScore,
            InherentRiskValue = dto.InherentRiskValue,
            Comments = dto.Comments,
            FinancialImpact = dto.FinancialImpact,
            GrossLossExpectation = dto.GrossLossExpectation,
            CreatedBy = dto.CreatedBy,
            CreationDate = DateTime.Now
        };

        _context.OrmRbaProcessRiskAsesmnts.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> UpdateProcessRiskAssessmentAsync(int assessmentId, ProcessRiskAssessmentUpdateDto dto)
    {
        var entity = await _context.OrmRbaProcessRiskAsesmnts
            .FirstOrDefaultAsync(a => a.Id == assessmentId);

        if (entity == null)
            return false;

        entity.RiskImpactId = dto.RiskImpactId;
        entity.RiskOccurenceId = dto.RiskOccurenceId;
        entity.InherentRiskScore = dto.InherentRiskScore;
        entity.InherentRiskValue = dto.InherentRiskValue;
        entity.Comments = dto.Comments;
        entity.FinancialImpact = dto.FinancialImpact;
        entity.GrossLossExpectation = dto.GrossLossExpectation;
        
        if (dto.RiskProcessLinkId.HasValue)
            entity.RiskProcessLinkId = dto.RiskProcessLinkId;

        entity.LastUpdatedBy = dto.LastUpdatedBy;
        entity.LastUpdateDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateGrossLossExpectationAsync(int assessmentId, int occurrenceWeight, int userId)
    {
        var entity = await _context.OrmRbaProcessRiskAsesmnts
            .FirstOrDefaultAsync(a => a.Id == assessmentId);

        if (entity == null || !entity.FinancialImpact.HasValue)
            return false;

        entity.GrossLossExpectation = entity.FinancialImpact.Value * occurrenceWeight;
        entity.LastUpdatedBy = userId;
        entity.LastUpdateDate = DateTime.Now;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteProcessRiskAssessmentAsync(int accountId, int assessmentId)
    {
        var entity = await _context.OrmRbaProcessRiskAsesmnts
            .FirstOrDefaultAsync(a => a.AccountId == accountId && a.Id == assessmentId);

        if (entity == null)
            return false;

        _context.OrmRbaProcessRiskAsesmnts.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
