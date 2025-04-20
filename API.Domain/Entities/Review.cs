using Api.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Presistence;

public partial class Review
{
    public int RId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateOnly? ReviewDate { get; set; }

    public string? UId { get; set; }

    public int? PId { get; set; }

    public virtual Product? PIdNavigation { get; set; }
}
