using ORM.Application.Common.Exceptions;
using ORM.Application.Common.Localization;
using ORM.Core.DTOs.ActivityLog;
using ORM.Core.DTOs.CalendarHoliday;
using ORM.Core.Interfaces.Repositories;
using ORM.Core.Interfaces.Services;
using ORM.Domain.Entities;

namespace ORM.Application.Services;

public class CalendarHolidayService : ICalendarHolidayService
{
    private readonly ICalendarHolidayRepository _repository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IActivityLogService _activityLogService;
    private readonly ILocalizationService _localization;

    public CalendarHolidayService(
        ICalendarHolidayRepository repository,
        ICurrentUserService currentUserService,
        IActivityLogService activityLogService,
        ILocalizationService localization)
    {
        _repository = repository;
        _currentUserService = currentUserService;
        _activityLogService = activityLogService;
        _localization = localization;
    }

    public async Task<List<CalendarHolidayDto>> GetAllAsync()
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var holidays = await _repository.GetAllAsync(accountId);

        return holidays.Select(MapToDto).ToList();
    }

    public async Task<CalendarHolidayDto?> GetByIdAsync(int holidayId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var holiday = await _repository.GetByIdAsync(holidayId, accountId);

        return holiday != null ? MapToDto(holiday) : null;
    }

    public async Task<List<CalendarHolidayDto>> GetByCountryAsync(int? countryId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var holidays = await _repository.GetByCountryAsync(countryId, accountId);

        return holidays.Select(MapToDto).ToList();
    }

    public async Task<List<CalendarHolidayDto>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var holidays = await _repository.GetByDateRangeAsync(startDate, endDate, accountId);

        return holidays.Select(MapToDto).ToList();
    }

    public async Task<CalendarHolidayDto> CreateAsync(CreateCalendarHolidayDto dto)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var userId = _currentUserService.UserId ?? throw new UnauthorizedException("User ID not found");
        
        // Check for duplicate
        var exists = await _repository.ExistsAsync(dto.Description, dto.HolidayStart, dto.HolidayEnd, accountId);
        if (exists)
        {
            var errorMessage = _localization.Get(MessageKeys.CalendarHolidayDuplicate);
            
            // Log the validation failure with correct entity name
            await _activityLogService.LogActivityAsync(
                EventType.DataCreated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcCalendarHoliday),
                null,
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }
        
        // Get user context to retrieve CountryId
        var userContext = await _currentUserService.GetUserContextAsync();
        var countryId = userContext?.CountryId;

        // Calculate holiday days
        var holidayDays = (dto.HolidayEnd - dto.HolidayStart).Days + 1;

        var holiday = new GrcCalendarHoliday
        {
            HolidayStart = dto.HolidayStart,
            HolidayEnd = dto.HolidayEnd,
            HolidayDays = holidayDays,
            Description = dto.Description,
            CountryId = countryId,
            AccountId = accountId,
            CreatedBy = userId,
            CreationDate = DateTime.UtcNow
        };

        var created = await _repository.CreateAsync(holiday);

        // Log activity
        await _activityLogService.LogEntityCreatedAsync(
            created,
            EventType.DataCreated,
            sourceSystemId: 1,
            sourceModuleId: 7);

        return MapToDto(created);
    }

    public async Task<CalendarHolidayDto> UpdateAsync(int holidayId, UpdateCalendarHolidayDto dto)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");
        var userId = _currentUserService.UserId ?? throw new UnauthorizedException("User ID not found");
        
        var existing = await _repository.GetByIdAsync(holidayId, accountId);
        if (existing == null)
            throw new NotFoundException(_localization.Get(MessageKeys.CalendarHolidayNotFound));
        
        // Check for duplicate (excluding current holiday)
        var exists = await _repository.ExistsAsync(dto.Description, dto.HolidayStart, dto.HolidayEnd, accountId, holidayId);
        if (exists)
        {
            var errorMessage = _localization.Get(MessageKeys.CalendarHolidayDuplicate);
            
            // Log the validation failure with correct entity name
            await _activityLogService.LogActivityAsync(
                EventType.DataUpdated,
                ActionType.Write,
                false,
                errorMessage,
                nameof(GrcCalendarHoliday),
                holidayId.ToString(),
                null,
                null,
                null,
                sourceSystemId: 1,
                sourceModuleId: 7);
            
            throw new BadRequestException(errorMessage);
        }
        
        // Get user context to retrieve CountryId
        var userContext = await _currentUserService.GetUserContextAsync();
        var countryId = userContext?.CountryId;

        // Store old values for logging
        var oldHoliday = new GrcCalendarHoliday
        {
            HolidayId = existing.HolidayId,
            HolidayStart = existing.HolidayStart,
            HolidayEnd = existing.HolidayEnd,
            HolidayDays = existing.HolidayDays,
            Description = existing.Description,
            CountryId = existing.CountryId
        };

        // Calculate new holiday days
        var holidayDays = (dto.HolidayEnd - dto.HolidayStart).Days + 1;

        // Update properties
        existing.HolidayStart = dto.HolidayStart;
        existing.HolidayEnd = dto.HolidayEnd;
        existing.HolidayDays = holidayDays;
        existing.Description = dto.Description;
        existing.CountryId = countryId;
        existing.LastUpdatedBy = userId;
        existing.LastUpdateDate = DateTime.UtcNow;

        var updated = await _repository.UpdateAsync(existing);

        // Log activity
        await _activityLogService.LogEntityUpdatedAsync(
            oldHoliday,
            updated,
            EventType.DataUpdated,
            sourceSystemId: 1,
            sourceModuleId: 7);

        return MapToDto(updated);
    }

    public async Task<bool> DeleteAsync(int holidayId)
    {
        var accountId = _currentUserService.AccountId ?? throw new UnauthorizedException("Account ID not found");

        var existing = await _repository.GetByIdAsync(holidayId, accountId);
        if (existing == null)
            throw new NotFoundException(_localization.Get(MessageKeys.CalendarHolidayNotFound));

        var result = await _repository.DeleteAsync(holidayId, accountId);

        if (result)
        {
            // Log activity
            await _activityLogService.LogEntityDeletedAsync(
                existing,
                EventType.DataDeleted,
                sourceSystemId: 1,
                sourceModuleId: 7);
        }

        return result;
    }

    private CalendarHolidayDto MapToDto(GrcCalendarHoliday holiday)
    {
        return new CalendarHolidayDto
        {
            HolidayId = holiday.HolidayId,
            HolidayStart = holiday.HolidayStart,
            HolidayEnd = holiday.HolidayEnd,
            HolidayDays = holiday.HolidayDays,
            Description = holiday.Description,
            CreatedBy = holiday.CreatedBy,
            CreationDate = holiday.CreationDate,
            LastUpdatedBy = holiday.LastUpdatedBy,
            LastUpdateDate = holiday.LastUpdateDate,
            CountryId = holiday.CountryId,
            CountryName = holiday.Country?.CountryName,
            AccountId = holiday.AccountId
        };
    }
}
