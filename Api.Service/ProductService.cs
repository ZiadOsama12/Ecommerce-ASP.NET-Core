using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await unitOfWork.Product.GetProductByIdAsync(id);
        }
    }
}
