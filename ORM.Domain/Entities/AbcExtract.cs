using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class AbcExtract
{
    public int Id { get; set; }

    public string? NameRef { get; set; }

    public string? IssuerRef { get; set; }

    public string? Structure { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public string? Website { get; set; }

    public string? Abc { get; set; }

    public string? EffectiveMonth { get; set; }

    public string? EffectiveYear { get; set; }

    public int? Regid { get; set; }

    public int? Sub { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
