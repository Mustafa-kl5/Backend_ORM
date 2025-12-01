using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmTasksCalendar
{
    public int Id { get; set; }

    public int? TaskId { get; set; }

    public int? KriId { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual OrmKri? Kri { get; set; }

    public virtual OrmRcsaTask? Task { get; set; }
}
