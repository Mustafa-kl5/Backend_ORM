namespace ORM.Core.DTOs.Department;

public class DepartmentDto
{
    public int DepartmentId { get; set; }
    public int? CountryId { get; set; }
    public string? CountryName { get; set; }
    public string DepartmentName { get; set; } = null!;
    public string DepartmentEmail1 { get; set; } = null!;
    public string? DepartmentEmail2 { get; set; }
    public string? DepartmentCode { get; set; }
    public int? SectorId { get; set; }
    public string? SectorName { get; set; }
    public int AccountId { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreationDate { get; set; }
    public int? LastUpdatedBy { get; set; }
    public DateTime? LastUpdateDate { get; set; }
}
