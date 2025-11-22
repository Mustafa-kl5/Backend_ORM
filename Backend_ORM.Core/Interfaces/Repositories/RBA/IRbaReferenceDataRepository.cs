using Backend_ORM.Core.DTOs.RBA;

namespace Backend_ORM.Core.Interfaces.Repositories.RBA;

public interface IRbaReferenceDataRepository
{
    Task<IEnumerable<ImpactLevelDto>> GetImpactLevelsAsync(int accountId, bool includeFinancial = false);
    Task<ImpactLevelDto?> GetImpactByAmountAsync(int accountId, decimal amount);
    Task<IEnumerable<OccurrenceLevelDto>> GetOccurrenceLevelsAsync(int accountId, bool includeMultipliers = false);
    Task<InherentRiskScoreDto?> GetInherentScoreByValueAsync(int accountId, int score);
    Task<IEnumerable<ControlEffectivenessLevelDto>> GetControlEffectivenessLevelsAsync(int accountId);
}
