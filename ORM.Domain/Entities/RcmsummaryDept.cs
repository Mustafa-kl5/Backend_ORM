using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class RcmsummaryDept
{
    public int Id { get; set; }

    public int DepartmentId { get; set; }

    public int? OutstandingselfasesmentBreachs { get; set; }

    public int? OutstandingExamAsesmntBreaches { get; set; }

    public int? OutstandingAuditBreaches { get; set; }

    public int? OutstandingReportBreaches { get; set; }

    public int? OutstandingKriBreaches { get; set; }

    public int? OutstandingWhistleBreaches { get; set; }

    public int? OutstandingcomplaintBreaches { get; set; }

    public int? TotalAuditBreaches { get; set; }

    public int? TotalselfAsesmntBreach { get; set; }

    public int? TotalExamAsesmntBreaches { get; set; }

    public int? TotalKriBreaches { get; set; }

    public int? TotalWhistleBreaches { get; set; }

    public int? TotalReportBreaches { get; set; }

    public int? TotalComplaintBreaches { get; set; }

    public int? Overdueselfasesmnt { get; set; }

    public int? PendingExam { get; set; }

    public int? InprogressExam { get; set; }

    public int? PendingComplaint { get; set; }

    public int? CompletedComplaint { get; set; }

    public int? TotalRegulations { get; set; }

    public int? TotalRegBreach { get; set; }

    public int? TotalRegWarning { get; set; }

    public int? AnnualTotalRegBreachs { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? CreatedBy { get; set; }
}
