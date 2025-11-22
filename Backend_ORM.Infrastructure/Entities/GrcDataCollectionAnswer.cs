using System;
using System.Collections.Generic;

namespace Backend_ORM.Infrastructure.Entities;

public partial class GrcDataCollectionAnswer
{
    public int Id { get; set; }

    public int? CollectionId { get; set; }

    public int? AnsweredBy { get; set; }

    public int? DepMakerAnswer { get; set; }

    public int? DepCheckerAnswer { get; set; }

    public int? CompMakerAnswer { get; set; }

    public int? CompCheckerAnswer { get; set; }

    public string? DepMakerComment { get; set; }

    public string? DepCheckerComment { get; set; }

    public string? CompMakerComment { get; set; }

    public string? CompCheckerComment { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? UpdatedBy { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public bool? IsMarked { get; set; }

    public virtual GrcUser? AnsweredByNavigation { get; set; }

    public virtual GrcDataCollectionNonfinancial? Collection { get; set; }

    public virtual GrcApproveStatus? CompMakerAnswerNavigation { get; set; }

    public virtual GrcApproveStatus? DepCheckerAnswerNavigation { get; set; }

    public virtual GrcComply? DepMakerAnswerNavigation { get; set; }
}
