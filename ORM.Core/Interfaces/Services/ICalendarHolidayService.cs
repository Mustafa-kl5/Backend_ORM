using ORM.Core.DTOs.CalendarHoliday;

namespace ORM.Core.Interfaces.Services;

public interface ICalendarHolidayService
{
    Task<List<CalendarHolidayDto>> GetAllAsync();
    Task<CalendarHolidayDto?> GetByIdAsync(int holidayId);
    Task<List<CalendarHolidayDto>> GetByCountryAsync(int? countryId);
    Task<List<CalendarHolidayDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    Task<CalendarHolidayDto> CreateAsync(CreateCalendarHolidayDto dto);
    Task<CalendarHolidayDto> UpdateAsync(int holidayId, UpdateCalendarHolidayDto dto);
    Task<bool> DeleteAsync(int holidayId);
}
