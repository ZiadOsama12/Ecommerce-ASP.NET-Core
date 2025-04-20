using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
