using Api.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Presistence;

public partial class Cart
{
    public int CartId { get; set; }

    public string? UId { get; set; }

    public virtual ICollection<Product> PIds { get; set; } = new List<Product>();
}
