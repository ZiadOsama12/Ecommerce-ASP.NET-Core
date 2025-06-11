using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Entities
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }

}
