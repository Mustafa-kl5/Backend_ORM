using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;

namespace Backend_ORM.Services.Services.RBA;

public class RbaProcessRiskService : IRbaProcessRiskService
{
    private readonly IRbaProcessRiskRepository _repository;

    public RbaProcessRiskService(IRbaProcessRiskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ProcessRiskSummaryDto>> GetProcessesWithRiskSummaryAsync(int accountId)
    {
        return await _repository.GetProcessesWithRiskSummaryAsync(accountId);
    }

    public async Task<IEnumerable<ProcessRiskAssessmentDto>> GetProcessRisksAsync(int accountId, int processId)
    {
        return await _repository.GetProcessRisksAsync(accountId, processId);
    }

    public async Task<ProcessRiskAssessmentDto?> GetProcessRiskByIdAsync(int accountId, int assessmentId)
    {
        return await _repository.GetProcessRiskByIdAsync(accountId, assessmentId);
    }

    public async Task<int> CreateProcessRiskAssessmentAsync(ProcessRiskAssessmentCreateDto dto)
    {
        return await _repository.CreateProcessRiskAssessmentAsync(dto);
    }

    public async Task<bool> UpdateProcessRiskAssessmentAsync(int assessmentId, ProcessRiskAssessmentUpdateDto dto)
    {
        return await _repository.UpdateProcessRiskAssessmentAsync(assessmentId, dto);
    }

    public async Task<bool> UpdateGrossLossExpectationAsync(int assessmentId, int occurrenceWeight, int userId)
    {
        return await _repository.UpdateGrossLossExpectationAsync(assessmentId, occurrenceWeight, userId);
    }

    public async Task<bool> DeleteProcessRiskAssessmentAsync(int accountId, int assessmentId)
    {
        return await _repository.DeleteProcessRiskAssessmentAsync(accountId, assessmentId);
    }
}
