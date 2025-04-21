using Api.Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IProductService
    {
        public Task<ProductDto> CreateProduct(ProductDto productDto);
        public Task UpdateProduct(ProductDto productDto);
        public Task<ProductDto> GetByIdAsync(int id, bool trackChanges);
        public Task<IEnumerable<ProductDto>> GetAllProductsAsync(bool trackChanges);
        public Task DeleteProduct(int id);

    }
}
