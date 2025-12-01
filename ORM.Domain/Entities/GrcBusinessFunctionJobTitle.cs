using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcBusinessFunctionJobTitle
{
    public int Id { get; set; }

    public int FunctionId { get; set; }

    public int JobTitleId { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcBusinessUnitFunction Function { get; set; } = null!;

    public virtual GrcJobTitle JobTitle { get; set; } = null!;
}
