using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class CustomerDetail
{
    public int Id { get; set; }

    public int CustomerTypeId { get; set; }

    public int ContactChannelId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EmailAddress { get; set; }

    public string? FaxNumber { get; set; }

    public string? PhoneNumber { get; set; }

    public string? MobileNumber { get; set; }

    public string? Address { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public DateTime? DateofBirth { get; set; }

    public string? SocialSecurityNumber { get; set; }

    public bool ExternalCustomer { get; set; }

    public int? CustomerDisabilityId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CompCustomerCall> CompCustomerCalls { get; set; } = new List<CompCustomerCall>();

    public virtual ContactChannel ContactChannel { get; set; } = null!;

    public virtual CustomerDisabilityNeed? CustomerDisability { get; set; }

    public virtual CustomerType CustomerType { get; set; } = null!;
}
