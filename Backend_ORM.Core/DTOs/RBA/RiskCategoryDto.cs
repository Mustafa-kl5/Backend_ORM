npmnamespace Backend_ORM.Core.DTOs.RBA;

public class RiskCategoryDto
{
    public int RiskId { get; set; }
    public int CategoryId { get; set; }
    public string RiskDescription { get; set; } = string.Empty;
    public string Reference { get; set; } = string.Empty;
}
