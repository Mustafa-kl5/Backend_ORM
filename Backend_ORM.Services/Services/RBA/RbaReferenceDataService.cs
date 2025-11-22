using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;

namespace Backend_ORM.Services.Services.RBA;

public class RbaReferenceDataService : IRbaReferenceDataService
{
    private readonly IRbaReferenceDataRepository _repository;

    public RbaReferenceDataService(IRbaReferenceDataRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ImpactLevelDto>> GetImpactLevelsAsync(int accountId, bool includeFinancial = false)
    {
        return await _repository.GetImpactLevelsAsync(accountId, includeFinancial);
    }

    public async Task<ImpactLevelDto?> GetImpactByAmountAsync(int accountId, decimal amount)
    {
        return await _repository.GetImpactByAmountAsync(accountId, amount);
    }

    public async Task<IEnumerable<OccurrenceLevelDto>> GetOccurrenceLevelsAsync(int accountId, bool includeMultipliers = false)
    {
        return await _repository.GetOccurrenceLevelsAsync(accountId, includeMultipliers);
    }

    public async Task<InherentRiskScoreDto?> CalculateInherentScoreAsync(int accountId, int score)
    {
        return await _repository.GetInherentScoreByValueAsync(accountId, score);
    }

    public async Task<IEnumerable<ControlEffectivenessLevelDto>> GetControlEffectivenessLevelsAsync(int accountId)
    {
        return await _repository.GetControlEffectivenessLevelsAsync(accountId);
    }
}
