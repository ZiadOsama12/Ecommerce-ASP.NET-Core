using Api.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Presistence;

public partial class Category
{
    public int CId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
