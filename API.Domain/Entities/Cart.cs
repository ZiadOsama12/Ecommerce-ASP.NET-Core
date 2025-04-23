using System;
using System.Collections.Generic;

namespace Api.Domain.Entities;

public partial class Cart
{
    public int CartId { get; set; }

    public string? UserId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    public virtual ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();

}
