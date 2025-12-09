using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.Department;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

/// <summary>
/// Controller for Department management
/// </summary>
[Authorize]
public class DepartmentController : BaseController
{
    private readonly IDepartmentService _departmentService;
    private readonly ILocalizationService _localization;

    public DepartmentController(
        IDepartmentService departmentService,
        ILocalizationService localization)
    {
        _departmentService = departmentService;
        _localization = localization;
    }

    /// <summary>
    /// Get all departments
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var departments = await _departmentService.GetAllAsync();
        return Success(departments, _localization.Get(MessageKeys.OperationSuccess));
    }

    /// <summary>
    /// Get department by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        if (department == null)
            return NotFoundResponse(_localization.Get(MessageKeys.DepartmentNotFound));

        return Success(department);
    }

    /// <summary>
    /// Get departments by country
    /// </summary>
    [HttpGet("country/{countryId}")]
    public async Task<IActionResult> GetByCountry(int countryId)
    {
        var departments = await _departmentService.GetByCountryAsync(countryId);
        return Success(departments);
    }

    /// <summary>
    /// Create new department
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return Fail(
                _localization.Get(MessageKeys.ValidationError), 
                400, 
                ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

        var created = await _departmentService.CreateAsync(dto);
        return Created(created, _localization.Get(MessageKeys.DepartmentCreated));
    }

    /// <summary>
    /// Update existing department
    /// </summary>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentDto dto)
    {
        if (!ModelState.IsValid)
            return Fail(
                _localization.Get(MessageKeys.ValidationError), 
                400, 
                ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

        var updated = await _departmentService.UpdateAsync(id, dto);
        return Success(updated, _localization.Get(MessageKeys.DepartmentUpdated));
    }

    /// <summary>
    /// Delete department
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _departmentService.DeleteAsync(id);
        return Success(result, _localization.Get(MessageKeys.DepartmentDeleted));
    }
}
