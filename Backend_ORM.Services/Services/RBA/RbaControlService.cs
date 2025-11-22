using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;

namespace Backend_ORM.Services.Services.RBA;

public class RbaControlService : IRbaControlService
{
    private readonly IRbaControlRepository _repository;

    public RbaControlService(IRbaControlRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ControlAssessmentDto>> GetProcessRiskControlsAsync(int accountId, int processId, int riskId)
    {
        return await _repository.GetProcessRiskControlsAsync(accountId, processId, riskId);
    }

    public async Task<ControlAssessmentDto?> GetControlAssessmentByIdAsync(int accountId, int assessmentId)
    {
        return await _repository.GetControlAssessmentByIdAsync(accountId, assessmentId);
    }

    public async Task<int> CreateControlAssessmentAsync(ControlAssessmentCreateDto dto)
    {
        return await _repository.CreateControlAssessmentAsync(dto);
    }

    public async Task<bool> UpdateControlAssessmentAsync(int assessmentId, ControlAssessmentUpdateDto dto)
    {
        return await _repository.UpdateControlAssessmentAsync(assessmentId, dto);
    }

    public async Task<bool> DeleteControlAssessmentAsync(int accountId, int assessmentId)
    {
        return await _repository.DeleteControlAssessmentAsync(accountId, assessmentId);
    }
}
