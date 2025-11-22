using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcFinancialRegulationsUser
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int RegulationId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcRegulation Regulation { get; set; } = null!;

    public virtual GrcUser User { get; set; } = null!;
}
