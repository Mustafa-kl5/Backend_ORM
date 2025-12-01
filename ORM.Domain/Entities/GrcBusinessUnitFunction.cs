using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcBusinessUnitFunction
{
    public int Id { get; set; }

    public int BussinessUnitId { get; set; }

    public string Description { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcControlBusinessUnit BussinessUnit { get; set; } = null!;

    public virtual ICollection<GrcBusinessFunctionJobTitle> GrcBusinessFunctionJobTitles { get; set; } = new List<GrcBusinessFunctionJobTitle>();

    public virtual ICollection<GrcFunctionDetail> GrcFunctionDetails { get; set; } = new List<GrcFunctionDetail>();

    public virtual ICollection<GrcSubRegulationFunction> GrcSubRegulationFunctions { get; set; } = new List<GrcSubRegulationFunction>();

    public virtual ICollection<RccmCmTaskDetail> RccmCmTaskDetails { get; set; } = new List<RccmCmTaskDetail>();
}
