using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class OrmmapTable
{
    public int Id { get; set; }

    public string TableName { get; set; } = null!;

    public string BusinessTableName { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;
}
