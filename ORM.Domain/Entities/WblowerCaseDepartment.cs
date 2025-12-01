using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class WblowerCaseDepartment
{
    public int Id { get; set; }

    public int WbloweCaseId { get; set; }

    public int DepartmentId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcDepartment Department { get; set; } = null!;

    public virtual WblowerCase WbloweCase { get; set; } = null!;
}
