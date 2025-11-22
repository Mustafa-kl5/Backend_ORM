using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CorresType
{
    public int Id { get; set; }

    public int? AccountId { get; set; }

    public int Code { get; set; }

    public string Type { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount? Account { get; set; }

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();
}
