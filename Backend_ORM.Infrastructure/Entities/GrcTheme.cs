using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcTheme
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int Code { get; set; }

    public string Description { get; set; } = null!;

    public bool? Active { get; set; }

    public string? DefualtLogo { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<GrcThemeDetail> GrcThemeDetails { get; set; } = new List<GrcThemeDetail>();
}
