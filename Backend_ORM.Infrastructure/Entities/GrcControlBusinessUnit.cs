using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcControlBusinessUnit
{
    public int Id { get; set; }

    public int ControlId { get; set; }

    public int? ControlTypeId { get; set; }

    public int? RelatedPolicyId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public string DescriptionIndex { get; set; } = null!;

    public string? AttachedFile { get; set; }

    public int? RiskId { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcControl Control { get; set; } = null!;

    public virtual GrcControlType? ControlType { get; set; }

    public virtual ICollection<GrcBusinessUnitDepartment> GrcBusinessUnitDepartments { get; set; } = new List<GrcBusinessUnitDepartment>();

    public virtual ICollection<GrcBusinessUnitFunction> GrcBusinessUnitFunctions { get; set; } = new List<GrcBusinessUnitFunction>();

    public virtual ICollection<GrcControlBusinessUnit> InverseRelatedPolicy { get; set; } = new List<GrcControlBusinessUnit>();

    public virtual ICollection<RccmChangeManagement> RccmChangeManagements { get; set; } = new List<RccmChangeManagement>();

    public virtual GrcControlBusinessUnit? RelatedPolicy { get; set; }
}
