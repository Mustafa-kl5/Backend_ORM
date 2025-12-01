using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class MapCountry
{
    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
