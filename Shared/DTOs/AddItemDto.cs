using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record AddItemDto
    {
        public int ProductId { get; init; }
        public int Quantity { get; init; }

    }
}
