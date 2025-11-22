using Backend_ORM.Core.DTOs.RBA;

namespace Backend_ORM.Core.Interfaces.Services.RBA;

public interface IRbaRiskService
{
    Task<IEnumerable<CategoryDto>> GetCategoriesAsync(int accountId);
    Task<IEnumerable<RiskCategoryDto>> GetRiskCategoriesByCategoryAsync(int accountId, int categoryId);
    Task<RiskAssessmentDto?> GetRiskAssessmentByElementAsync(int accountId, int riskElementId);
    Task<IEnumerable<RiskAssessmentDetailDto>> GetRiskAssessmentsByCategoryAsync(int accountId, int riskCategoryId);
    Task<int> CreateRiskAssessmentAsync(RiskAssessmentCreateDto dto);
    Task<bool> UpdateRiskAssessmentAsync(int riskElementId, RiskAssessmentUpdateDto dto);
    Task<bool> DeleteRiskAssessmentAsync(int accountId, int riskElementId);
}
