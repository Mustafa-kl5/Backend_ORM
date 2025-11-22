using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class OrmRcsaTask
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Reference { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public DateTime? EffectiveDate { get; set; }

    public int Occurrence { get; set; }

    public string? AttachedFile { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public bool? FutureAssessment { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmRcsaDueAsesmnt> OrmRcsaDueAsesmnts { get; set; } = new List<OrmRcsaDueAsesmnt>();

    public virtual ICollection<OrmRcsaTaskBusinessLine> OrmRcsaTaskBusinessLines { get; set; } = new List<OrmRcsaTaskBusinessLine>();

    public virtual ICollection<OrmRcsaTaskOfficer> OrmRcsaTaskOfficers { get; set; } = new List<OrmRcsaTaskOfficer>();

    public virtual ICollection<OrmRcsaTaskTemplate> OrmRcsaTaskTemplates { get; set; } = new List<OrmRcsaTaskTemplate>();

    public virtual ICollection<OrmRcsaquestioniareAnswer> OrmRcsaquestioniareAnswers { get; set; } = new List<OrmRcsaquestioniareAnswer>();

    public virtual ICollection<OrmTasksCalendar> OrmTasksCalendars { get; set; } = new List<OrmTasksCalendar>();
}
