using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmKri
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int TypeId { get; set; }

    public int PeriodId { get; set; }

    public int? CurrencyId { get; set; }

    public int DirectionId { get; set; }

    public string Reference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int ThresholdLevel { get; set; }

    public int ThresholdLimit { get; set; }

    public DateTime? PeriodDate { get; set; }

    public string? PeriodWeekDay { get; set; }

    public int? PeriodFrequency { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Requirements { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual Currency? Currency { get; set; }

    public virtual OrmKriDirection Direction { get; set; } = null!;

    public virtual ICollection<OrmKriEntry> OrmKriEntries { get; set; } = new List<OrmKriEntry>();

    public virtual ICollection<OrmKriProccessBl> OrmKriProccessBls { get; set; } = new List<OrmKriProccessBl>();

    public virtual ICollection<OrmKriProcess> OrmKriProcesses { get; set; } = new List<OrmKriProcess>();

    public virtual ICollection<OrmLossEventKri> OrmLossEventKris { get; set; } = new List<OrmLossEventKri>();

    public virtual ICollection<OrmTasksCalendar> OrmTasksCalendars { get; set; } = new List<OrmTasksCalendar>();

    public virtual OrmKriPeriod Period { get; set; } = null!;

    public virtual OrmKriType Type { get; set; } = null!;
}
