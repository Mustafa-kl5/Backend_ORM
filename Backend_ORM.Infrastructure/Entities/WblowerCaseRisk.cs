using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class WblowerCaseRisk
{
    public int Id { get; set; }

    public int RiskId { get; set; }

    public int WblowerCaseId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcWhistleblowerRisk Risk { get; set; } = null!;

    public virtual WblowerCase WblowerCase { get; set; } = null!;
}
