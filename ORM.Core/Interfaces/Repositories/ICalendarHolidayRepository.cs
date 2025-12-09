using ORM.Core.DTOs.CalendarHoliday;
using ORM.Domain.Entities;

namespace ORM.Core.Interfaces.Repositories;

public interface ICalendarHolidayRepository
{
    Task<List<GrcCalendarHoliday>> GetAllAsync(int accountId);
    Task<GrcCalendarHoliday?> GetByIdAsync(int holidayId, int accountId);
    Task<List<GrcCalendarHoliday>> GetByCountryAsync(int? countryId, int accountId);
    Task<List<GrcCalendarHoliday>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, int accountId);
    Task<GrcCalendarHoliday> CreateAsync(GrcCalendarHoliday holiday);
    Task<GrcCalendarHoliday> UpdateAsync(GrcCalendarHoliday holiday);
    Task<bool> DeleteAsync(int holidayId, int accountId);
    Task<bool> ExistsAsync(string description, DateTime startDate, DateTime endDate, int accountId, int? excludeHolidayId = null);
}
