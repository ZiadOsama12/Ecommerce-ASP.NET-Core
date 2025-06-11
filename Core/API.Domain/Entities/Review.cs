using System;
using System.Collections.Generic;

namespace Api.Domain.Entities;

public partial class Review
{
    public int Id { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }

    public string? UserId { get; set; }

    public int? ProductId { get; set; }

    public virtual User User {get; set;}
    public virtual Product? Prodcut { get; set; }
}
