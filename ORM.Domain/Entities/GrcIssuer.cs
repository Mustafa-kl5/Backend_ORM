using System;
using System.Collections.Generic;

namespace ORM.Domain.Entities;

public partial class GrcIssuer
{
    public int IssuerId { get; set; }

    public int CouCountryId { get; set; }

    public string IssuerName { get; set; } = null!;

    public int CreatedBy { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? LastUpdateBy { get; set; }

    public DateTime? LastUpdateDate { get; set; }

    public int AccountId { get; set; }

    public virtual GrcAccount Account { get; set; } = null!;

    public virtual GrcCountry CouCountry { get; set; } = null!;

    public virtual ICollection<GrcRegulation> GrcRegulations { get; set; } = new List<GrcRegulation>();

    public virtual ICollection<GrcRegulatoryReportingTrack> GrcRegulatoryReportingTracks { get; set; } = new List<GrcRegulatoryReportingTrack>();

    public virtual ICollection<GrcStagingRegulation> GrcStagingRegulations { get; set; } = new List<GrcStagingRegulation>();
}
