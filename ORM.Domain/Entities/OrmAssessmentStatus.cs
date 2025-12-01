using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmAssessmentStatus
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateOnly CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateOnly? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<OrmRcsaDueAsesmntDetail> OrmRcsaDueAsesmntDetails { get; set; } = new List<OrmRcsaDueAsesmntDetail>();
}
