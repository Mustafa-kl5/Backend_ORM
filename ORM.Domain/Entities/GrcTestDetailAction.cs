using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcTestDetailAction
{
    public int Id { get; set; }

    public int TestDetailId { get; set; }

    public int ActionedBy { get; set; }

    public DateTime ActionDate { get; set; }

    public string? Status { get; set; }

    public string? Reason { get; set; }

    public string? Recommendation { get; set; }

    public string? Finding { get; set; }

    public DateTime? TestDueDate { get; set; }

    public string? Comments { get; set; }

    public DateTime? ActionDueDate { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcUser ActionedByNavigation { get; set; } = null!;

    public virtual GrcTestDetail TestDetail { get; set; } = null!;
}
