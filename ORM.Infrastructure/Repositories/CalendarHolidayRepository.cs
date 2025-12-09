using Microsoft.EntityFrameworkCore;
using ORM.Core.Interfaces.Repositories;
using ORM.Domain.Entities;
using ORM.Infrastructure.Data;

namespace ORM.Infrastructure.Repositories;

public class CalendarHolidayRepository : ICalendarHolidayRepository
{
    private readonly ORMContext _context;

    public CalendarHolidayRepository(ORMContext context)
    {
        _context = context;
    }

    public async Task<List<GrcCalendarHoliday>> GetAllAsync(int accountId)
    {
        return await _context.GrcCalendarHolidays
            .Include(h => h.Country)
            .Where(h => h.AccountId == accountId)
            .AsNoTracking()
            .OrderByDescending(h => h.HolidayStart)
            .ToListAsync();
    }

    public async Task<GrcCalendarHoliday?> GetByIdAsync(int holidayId, int accountId)
    {
        return await _context.GrcCalendarHolidays
            .Include(h => h.Country)
            .Where(h => h.HolidayId == holidayId && h.AccountId == accountId)
            .AsNoTracking()
            .FirstOrDefaultAsync();
    }

    public async Task<List<GrcCalendarHoliday>> GetByCountryAsync(int? countryId, int accountId)
    {
        return await _context.GrcCalendarHolidays
            .Include(h => h.Country)
            .Where(h => h.CountryId == countryId && h.AccountId == accountId)
            .AsNoTracking()
            .OrderByDescending(h => h.HolidayStart)
            .ToListAsync();
    }

    public async Task<List<GrcCalendarHoliday>> GetByDateRangeAsync(DateTime startDate, DateTime endDate, int accountId)
    {
        return await _context.GrcCalendarHolidays
            .Include(h => h.Country)
            .Where(h => h.AccountId == accountId && 
                       h.HolidayStart >= startDate && 
                       h.HolidayEnd <= endDate)
            .AsNoTracking()
            .OrderBy(h => h.HolidayStart)
            .ToListAsync();
    }

    public async Task<GrcCalendarHoliday> CreateAsync(GrcCalendarHoliday holiday)
    {
        _context.GrcCalendarHolidays.Add(holiday);
        await _context.SaveChangesAsync();
        
        // Reload with navigation properties
        return await GetByIdAsync(holiday.HolidayId, holiday.AccountId) ?? holiday;
    }

    public async Task<GrcCalendarHoliday> UpdateAsync(GrcCalendarHoliday holiday)
    {
        _context.GrcCalendarHolidays.Update(holiday);
        await _context.SaveChangesAsync();
        
        // Reload with navigation properties
        return await GetByIdAsync(holiday.HolidayId, holiday.AccountId) ?? holiday;
    }

    public async Task<bool> DeleteAsync(int holidayId, int accountId)
    {
        var holiday = await _context.GrcCalendarHolidays
            .Where(h => h.HolidayId == holidayId && h.AccountId == accountId)
            .FirstOrDefaultAsync();

        if (holiday == null)
            return false;

        _context.GrcCalendarHolidays.Remove(holiday);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ExistsAsync(string description, DateTime startDate, DateTime endDate, int accountId, int? excludeHolidayId = null)
    {
        var query = _context.GrcCalendarHolidays
            .Where(h => h.AccountId == accountId &&
                       h.Description.ToLower().Trim() == description.ToLower().Trim() &&
                       ((h.HolidayStart >= startDate && h.HolidayStart <= endDate) ||
                        (h.HolidayEnd >= startDate && h.HolidayEnd <= endDate) ||
                        (h.HolidayStart <= startDate && h.HolidayEnd >= endDate)));

        if (excludeHolidayId.HasValue)
        {
            query = query.Where(h => h.HolidayId != excludeHolidayId.Value);
        }

        return await query.AnyAsync();
    }
}
