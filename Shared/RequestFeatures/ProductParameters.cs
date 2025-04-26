using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public ProductParameters() => OrderBy = "price";
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; } = 50000;

        public bool ValidAgeRange => MaxPrice > MinPrice;
        public string? SearchTerm { get; set; }
    }
}
