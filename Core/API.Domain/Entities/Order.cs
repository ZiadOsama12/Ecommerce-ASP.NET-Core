using System;
using System.Collections.Generic;

namespace Api.Domain.Entities;

public partial class Order
{
    public int OrderNo { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? OrderDate { get; set; }

    public string? UserId { get; set; }
    public string? Status { get; set; }

    //public virtual ICollection<TrackingDetail> TrackingDetails { get; set; } = new List<TrackingDetail>();

    public virtual User? User { get; set; } 
    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
