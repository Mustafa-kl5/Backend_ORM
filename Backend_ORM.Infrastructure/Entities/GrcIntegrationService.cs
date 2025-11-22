using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcIntegrationService
{
    public int Id { get; set; }

    public string ServiceCode { get; set; } = null!;

    public string? Description { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string? Url { get; set; }

    public string? ChanelId { get; set; }

    public string? CustId { get; set; }

    public string? CorpId { get; set; }

    public string? AlertName { get; set; }

    public string? Lang { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcIntegrationEntity> GrcIntegrationEntities { get; set; } = new List<GrcIntegrationEntity>();
}
