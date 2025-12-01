using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class IntegrationApiMonitor
{
    public int Id { get; set; }

    public int StatusId { get; set; }

    public string Apiname { get; set; } = null!;

    public DateTime RequestDate { get; set; }

    public string? ErrorCode { get; set; }

    public string Json { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual IntegrationApiStatus Status { get; set; } = null!;
}
