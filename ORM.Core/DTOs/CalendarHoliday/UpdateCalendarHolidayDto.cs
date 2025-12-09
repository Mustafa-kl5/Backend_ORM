namespace ORM.Core.DTOs.CalendarHoliday;

public class UpdateCalendarHolidayDto
{
    public DateTime HolidayStart { get; set; }
    public DateTime HolidayEnd { get; set; }
    public string Description { get; set; } = null!;
}
