using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public record GetOrderWithDetailsDto
    {
        public GetOrderDto Order { get; init; }

        public ICollection<GetOrderProdcutDto> OrderDetails { get; init; }

    }
    public record GetOrderProdcutDto
    {
        public int? ProductId { get; init; }
        public int? Amount { get; init; }
        public decimal? UnitPrice { get; init; }
    }
    public record GetOrderDto
    {
        public int OrderId {  get; init; }
        public DateTime? OrderDate { get; init; }
        public string? Status { get; init; }
        public decimal? TotalPrice { get; init; }
        
    }
}
