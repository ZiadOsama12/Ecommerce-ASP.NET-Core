using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class OrderProduct
    {
        public int OrderId {  get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; } // The current Price...

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
