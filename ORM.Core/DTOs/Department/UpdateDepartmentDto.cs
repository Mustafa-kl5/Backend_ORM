using System.ComponentModel.DataAnnotations;

namespace ORM.Core.DTOs.Department;

public class UpdateDepartmentDto
{
    [Required(ErrorMessage = "Department name is required")]
    [StringLength(200, ErrorMessage = "Department name cannot exceed 200 characters")]
    public string DepartmentName { get; set; } = null!;

    [Required(ErrorMessage = "Primary email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string DepartmentEmail1 { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string? DepartmentEmail2 { get; set; }

    [Required(ErrorMessage = "Department code is required")]
    [StringLength(50, ErrorMessage = "Department code cannot exceed 50 characters")]
    public string DepartmentCode { get; set; } = null!;
}
