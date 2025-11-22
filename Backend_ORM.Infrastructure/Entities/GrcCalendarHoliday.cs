using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcCalendarHoliday
{
    public int HolidayId { get; set; }

    public DateTime HolidayStart { get; set; }

    public DateTime HolidayEnd { get; set; }

    public int HolidayDays { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? CountryId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry? Country { get; set; }
}
