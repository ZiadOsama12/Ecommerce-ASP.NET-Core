using System;
using System.Collections.Generic;

namespace Presistence;

public partial class Payment
{
    public int PId { get; set; }

    public string? Method { get; set; }

    public decimal? Amount { get; set; }

    public string? UId { get; set; }
}
