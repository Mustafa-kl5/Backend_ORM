using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CompCustomerCall
{
    public int Id { get; set; }

    public int CustomerDetailId { get; set; }

    public int SubProductId { get; set; }

    public int? DepartmentId { get; set; }

    public int StatusId { get; set; }

    public int? UserId { get; set; }

    public int CbjclassId { get; set; }

    public string? CompReference { get; set; }

    public DateTime Date { get; set; }

    public string? NatureofComplaint { get; set; }

    public bool? CustomerAcknFlag { get; set; }

    public string? ActionRequired { get; set; }

    public DateTime? RespondBy { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? AttachedFile { get; set; }

    public DateTime? UserComplaintDate { get; set; }

    public bool? BreachExist { get; set; }

    public int? BranchId { get; set; }

    public int CompTypesId { get; set; }

    public int? CompReceivedId { get; set; }

    public string? ComplaintUser { get; set; }

    public string? Emails { get; set; }

    public bool? SlaextendFlag { get; set; }

    public int PriorityId { get; set; }

    public int AccountId { get; set; }

    public bool? IsReal { get; set; }

    public string? Notes { get; set; }

    public int? GovernorateId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBranch? Branch { get; set; }

    public virtual Cbjclassification Cbjclass { get; set; } = null!;

    public virtual ICollection<CompActionDetail> CompActionDetails { get; set; } = new List<CompActionDetail>();

    public virtual ICollection<CompBreachDepartment> CompBreachDepartments { get; set; } = new List<CompBreachDepartment>();

    public virtual CompReceivedType? CompReceived { get; set; }

    public virtual ICollection<CompRootCause> CompRootCauses { get; set; } = new List<CompRootCause>();

    public virtual CompType CompTypes { get; set; } = null!;

    public virtual CustomerDetail CustomerDetail { get; set; } = null!;

    public virtual GrcDepartment? Department { get; set; }

    public virtual GrcGovernorate? Governorate { get; set; }

    public virtual ICollection<GrcBreach> GrcBreaches { get; set; } = new List<GrcBreach>();

    public virtual ICollection<GrcIntegrationMonitor> GrcIntegrationMonitors { get; set; } = new List<GrcIntegrationMonitor>();

    public virtual GrcPriority Priority { get; set; } = null!;

    public virtual CompStatus Status { get; set; } = null!;

    public virtual SubProduct SubProduct { get; set; } = null!;

    public virtual GrcUser? User { get; set; }
}
