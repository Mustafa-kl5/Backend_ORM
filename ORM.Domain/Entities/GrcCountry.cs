using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcCountry
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public int? RegionId { get; set; }

    public string? BankName { get; set; }

    public string? BankAddressLine1 { get; set; }

    public string? BankAddressLine2 { get; set; }

    public string? CountryCode { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual ICollection<GrcAuditReport> GrcAuditReports { get; set; } = new List<GrcAuditReport>();

    public virtual ICollection<GrcAuditSource> GrcAuditSources { get; set; } = new List<GrcAuditSource>();

    public virtual ICollection<GrcBranch> GrcBranches { get; set; } = new List<GrcBranch>();

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcCalendarHoliday> GrcCalendarHolidays { get; set; } = new List<GrcCalendarHoliday>();

    public virtual ICollection<GrcDepartment> GrcDepartments { get; set; } = new List<GrcDepartment>();

    public virtual ICollection<GrcFinancialCollectionLevel2> GrcFinancialCollectionLevel2s { get; set; } = new List<GrcFinancialCollectionLevel2>();

    public virtual ICollection<GrcFinancialCollection> GrcFinancialCollections { get; set; } = new List<GrcFinancialCollection>();

    public virtual ICollection<GrcIssuer> GrcIssuers { get; set; } = new List<GrcIssuer>();

    public virtual ICollection<GrcMatrix> GrcMatrices { get; set; } = new List<GrcMatrix>();

    public virtual ICollection<GrcRegulation> GrcRegulations { get; set; } = new List<GrcRegulation>();

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();

    public virtual ICollection<GrcTestHeader> GrcTestHeaders { get; set; } = new List<GrcTestHeader>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<GrcVariable> GrcVariables { get; set; } = new List<GrcVariable>();

    public virtual Region? Region { get; set; }
}
