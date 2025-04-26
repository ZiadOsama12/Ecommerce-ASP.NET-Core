using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Responses
{
    public sealed class ProductNotFoundResponse : ApiNotFoundResponse
    {
        public ProductNotFoundResponse(int id) 
            : base($"Product with id: {id} is not found.")
        {
        }
    }
}
