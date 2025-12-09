using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ORM.Core.DTOs.CalendarHoliday;
using ORM.Core.Interfaces.Services;

namespace ORM_API.Controllers;

[Authorize]
public class CalendarHolidayController : BaseController
{
    private readonly ICalendarHolidayService _calendarHolidayService;

    public CalendarHolidayController(ICalendarHolidayService calendarHolidayService)
    {
        _calendarHolidayService = calendarHolidayService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var holidays = await _calendarHolidayService.GetAllAsync();
        return Success(holidays);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var holiday = await _calendarHolidayService.GetByIdAsync(id);
        if (holiday == null)
            return NotFoundResponse($"Calendar holiday with ID {id} not found");

        return Success(holiday);
    }

    [HttpGet("country/{countryId}")]
    public async Task<IActionResult> GetByCountry(int? countryId)
    {
        var holidays = await _calendarHolidayService.GetByCountryAsync(countryId);
        return Success(holidays);
    }

    [HttpGet("range")]
    public async Task<IActionResult> GetByDateRange(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate)
    {
        if (startDate > endDate)
            return Fail("Start date must be before or equal to end date");

        var holidays = await _calendarHolidayService.GetByDateRangeAsync(startDate, endDate);
        return Success(holidays);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCalendarHolidayDto dto)
    {
        if (!ModelState.IsValid)
            return Fail("Invalid request data", 400, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

        if (dto.HolidayStart > dto.HolidayEnd)
            return Fail("Holiday start date must be before or equal to end date");

        var created = await _calendarHolidayService.CreateAsync(dto);
        return Created(created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCalendarHolidayDto dto)
    {
        if (!ModelState.IsValid)
            return Fail("Invalid request data", 400, ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList());

        if (dto.HolidayStart > dto.HolidayEnd)
            return Fail("Holiday start date must be before or equal to end date");

        var updated = await _calendarHolidayService.UpdateAsync(id, dto);
        return Success(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _calendarHolidayService.DeleteAsync(id);
        return Success(result);
    }
}
