using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcVariable
{
    public int VariableId { get; set; }

    public string ControlProbabilityFlag { get; set; } = null!;

    public string SumFormulaFlag { get; set; } = null!;

    public int Weight { get; set; }

    public int GracePeriod { get; set; }

    public int CalendarNotficiation { get; set; }

    public string WeekendStart { get; set; } = null!;

    public int WeekendDays { get; set; }

    public int CountryId { get; set; }

    public string ComplaintsEmail1 { get; set; } = null!;

    public string? ComplaintsEmail2 { get; set; }

    public bool SelfAssesmentDaily { get; set; }

    public bool? AuditFlag { get; set; }

    public string? AuditEmail1 { get; set; }

    public string? AuditEmail2 { get; set; }

    public int? Threshold { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int? ExamDuePeriod { get; set; }

    public string? Taken { get; set; }

    public bool? ExFlag { get; set; }

    public int? LastCompSeq { get; set; }

    public string? Rcmm { get; set; }

    public int? BreachFreqWeight { get; set; }

    public string? WblowerNotes { get; set; }

    public bool? WblowerDepartment { get; set; }

    public string MailAddress { get; set; } = null!;

    public string MailSupport { get; set; } = null!;

    public string MailAddressPass { get; set; } = null!;

    public string MailAddressSmtpserver { get; set; } = null!;

    public int MailAddressPort { get; set; }

    public bool MailAddressEnableSsl { get; set; }

    public bool? WhistleblowProcess { get; set; }

    public bool UserAccessFlag { get; set; }

    public int AccountId { get; set; }

    public string? WBlowerPolicy { get; set; }

    public int? AdvisoryPeriod { get; set; }

    public int? KriGracePeriod { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry Country { get; set; } = null!;
}
