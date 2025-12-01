using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class CorresLetterToPerson
{
    public int Id { get; set; }

    public int LetterId { get; set; }

    public int? PersonId { get; set; }

    public int? DepartmentId { get; set; }

    public string? DepartmentuserName { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcDepartment? Department { get; set; }

    public virtual CorresLetter Letter { get; set; } = null!;

    public virtual CorresOrgPerson? Person { get; set; }
}
