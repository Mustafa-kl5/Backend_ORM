using Backend_ORM.Core.DTOs.RBA;
using Backend_ORM.Core.Interfaces.Repositories.RBA;
using Backend_ORM.Core.Interfaces.Services.RBA;

namespace Backend_ORM.Services.Services.RBA;

public class RbaRiskService : IRbaRiskService
{
    private readonly IRbaRiskRepository _repository;

    public RbaRiskService(IRbaRiskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync(int accountId)
    {
        return await _repository.GetCategoriesAsync(accountId);
    }

    public async Task<IEnumerable<RiskCategoryDto>> GetRiskCategoriesByCategoryAsync(int accountId, int categoryId)
    {
        return await _repository.GetRiskCategoriesByCategoryAsync(accountId, categoryId);
    }

    public async Task<RiskAssessmentDto?> GetRiskAssessmentByElementAsync(int accountId, int riskElementId)
    {
        return await _repository.GetRiskAssessmentByElementAsync(accountId, riskElementId);
    }

    public async Task<IEnumerable<RiskAssessmentDetailDto>> GetRiskAssessmentsByCategoryAsync(int accountId, int riskCategoryId)
    {
        return await _repository.GetRiskAssessmentsByCategoryAsync(accountId, riskCategoryId);
    }

    public async Task<int> CreateRiskAssessmentAsync(RiskAssessmentCreateDto dto)
    {
        return await _repository.CreateRiskAssessmentAsync(dto);
    }

    public async Task<bool> UpdateRiskAssessmentAsync(int riskElementId, RiskAssessmentUpdateDto dto)
    {
        return await _repository.UpdateRiskAssessmentAsync(riskElementId, dto);
    }

    public async Task<bool> DeleteRiskAssessmentAsync(int accountId, int riskElementId)
    {
        return await _repository.DeleteRiskAssessmentAsync(accountId, riskElementId);
    }
}
