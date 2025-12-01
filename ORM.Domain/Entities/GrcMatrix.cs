using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcMatrix
{
    public int CouCountryId { get; set; }

    public int DepDepartmentId { get; set; }

    public string RclRisClassificationId { get; set; } = null!;

    public int? RiskLevelCount { get; set; }

    public DateTime? CreationDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual GrcDepartment DepDepartment { get; set; } = null!;
}
