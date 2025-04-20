using Presistence;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities;

public partial class Product
{
    public int PId { get; set; }

    public string? Name { get; set; }

    public decimal? Price { get; set; }

    public int? CId { get; set; }

    public virtual Category? CIdNavigation { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> OrderNos { get; set; } = new List<Order>();
}
