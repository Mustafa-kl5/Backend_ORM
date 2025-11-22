using Backend_ORM.Core.DTOs.RBA;

namespace Backend_ORM.Core.Interfaces.Services.RBA;

public interface IRbaReferenceDataService
{
    Task<IEnumerable<ImpactLevelDto>> GetImpactLevelsAsync(int accountId, bool includeFinancial = false);
    Task<ImpactLevelDto?> GetImpactByAmountAsync(int accountId, decimal amount);
    Task<IEnumerable<OccurrenceLevelDto>> GetOccurrenceLevelsAsync(int accountId, bool includeMultipliers = false);
    Task<InherentRiskScoreDto?> CalculateInherentScoreAsync(int accountId, int score);
    Task<IEnumerable<ControlEffectivenessLevelDto>> GetControlEffectivenessLevelsAsync(int accountId);
}
