using Backend_ORM.Core.DTOs.RBA;

namespace Backend_ORM.Core.Interfaces.Services.RBA;

public interface IRbaProcessRiskService
{
    Task<IEnumerable<ProcessRiskSummaryDto>> GetProcessesWithRiskSummaryAsync(int accountId);
    Task<IEnumerable<ProcessRiskAssessmentDto>> GetProcessRisksAsync(int accountId, int processId);
    Task<ProcessRiskAssessmentDto?> GetProcessRiskByIdAsync(int accountId, int assessmentId);
    Task<int> CreateProcessRiskAssessmentAsync(ProcessRiskAssessmentCreateDto dto);
    Task<bool> UpdateProcessRiskAssessmentAsync(int assessmentId, ProcessRiskAssessmentUpdateDto dto);
    Task<bool> UpdateGrossLossExpectationAsync(int assessmentId, int occurrenceWeight, int userId);
    Task<bool> DeleteProcessRiskAssessmentAsync(int accountId, int assessmentId);
}
