using System;
using System.Collections.Generic;

namespace Presistence;

public partial class TrackingDetail
{
    public int TId { get; set; }

    public string? Status { get; set; }

    public int? OrderNo { get; set; }

    public virtual Order? OrderNoNavigation { get; set; }
}
