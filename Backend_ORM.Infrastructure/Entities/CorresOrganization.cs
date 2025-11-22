using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class CorresOrganization
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public string Organization { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreationDate { get; set; }

    public int? LastUpdatedBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual ICollection<CorresLetter> CorresLetters { get; set; } = new List<CorresLetter>();

    public virtual ICollection<CorresOrgPerson> CorresOrgPeople { get; set; } = new List<CorresOrgPerson>();
}
