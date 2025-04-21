using Presistence;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities;

public partial class Order
{
    public int OrderNo { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? OrderDate { get; set; }

    public string? UId { get; set; }

    public virtual ICollection<TrackingDetail> TrackingDetails { get; set; } = new List<TrackingDetail>();

    public virtual ICollection<Product> PIds { get; set; } = new List<Product>();
}
