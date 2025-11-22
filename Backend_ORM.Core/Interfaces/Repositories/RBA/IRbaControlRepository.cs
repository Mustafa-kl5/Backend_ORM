using Backend_ORM.Core.DTOs.RBA;

namespace Backend_ORM.Core.Interfaces.Repositories.RBA;

public interface IRbaControlRepository
{
    Task<IEnumerable<ControlAssessmentDto>> GetProcessRiskControlsAsync(int accountId, int processId, int riskId);
    Task<ControlAssessmentDto?> GetControlAssessmentByIdAsync(int accountId, int assessmentId);
    Task<int> CreateControlAssessmentAsync(ControlAssessmentCreateDto dto);
    Task<bool> UpdateControlAssessmentAsync(int assessmentId, ControlAssessmentUpdateDto dto);
    Task<bool> DeleteControlAssessmentAsync(int accountId, int assessmentId);
}
