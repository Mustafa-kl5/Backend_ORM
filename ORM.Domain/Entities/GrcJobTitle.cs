using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcJobTitle
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcBusinessFunctionJobTitle> GrcBusinessFunctionJobTitles { get; set; } = new List<GrcBusinessFunctionJobTitle>();

    public virtual ICollection<GrcUser> GrcUsers { get; set; } = new List<GrcUser>();

    public virtual ICollection<WblowerCaseEscPosition> WblowerCaseEscPositions { get; set; } = new List<WblowerCaseEscPosition>();

    public virtual ICollection<WblowerClassPosition> WblowerClassPositions { get; set; } = new List<WblowerClassPosition>();
}
