using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record GetCartDto
    {
        public int? CartId { get; init; }
        public string? UserId { get; init; }
        public ICollection<CartProductDto>? Products { get; init; }
        
    }
    public record CartProductDto{
        public int? ProductId { get; init; }
        public int? Quantity { get; init; }
    }
}
