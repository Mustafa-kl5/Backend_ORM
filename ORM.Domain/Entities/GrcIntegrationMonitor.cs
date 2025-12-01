using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcIntegrationMonitor
{
    public int Id { get; set; }

    public int? CompCustomerCallId { get; set; }

    public int IntegrationEntitiesId { get; set; }

    public int IntegrationStatusId { get; set; }

    public int? IntegratioApiCodesId { get; set; }

    public string IntegrationMessage { get; set; } = null!;

    public string? Comments { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual CompCustomerCall? CompCustomerCall { get; set; }

    public virtual GrcIntegrationApiCode? IntegratioApiCodes { get; set; }

    public virtual GrcIntegrationEntity IntegrationEntities { get; set; } = null!;

    public virtual GrcIntegrationStatus IntegrationStatus { get; set; } = null!;
}
