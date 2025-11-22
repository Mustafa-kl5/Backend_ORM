using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcThemeDetail
{
    public int Id { get; set; }

    public int ThemeId { get; set; }

    public string Class { get; set; } = null!;

    public string? Attribute { get; set; }

    public string? AttributeValue { get; set; }

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual GrcTheme Theme { get; set; } = null!;
}
