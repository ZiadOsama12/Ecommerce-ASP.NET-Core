using Api.Domain.Entities;
using Api.Domain.Responses;
using Shared.DTOs;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IProductService
    {
        // ApiBaseResponse was replaced with (ProductDto or IEnumberable<ProductDto>
        public Task<ProductDto> CreateProduct(ProductDto productDto);
        public Task UpdateProduct(ProductDto productDto);
        public Task<ApiBaseResponse> GetByIdAsync(int id, bool trackChanges);
        public Task<(ApiBaseResponse response, MetaData metaData)> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges); // to return metadata => Task<PagedList<..>> Or Task<(IEnumberable<..>, MetaData ...)>

        public Task<(ApiBaseResponse response, MetaData metaData)> GetProductsByCategoryId(int id, ProductParameters productParameters, bool trackChanges);

        public Task DeleteProduct(int id);


        public Task<(ProductDto productToPatch, Product product)> GetProductByIdToPatchAsync(int id, bool trackChanges);


        public Task SaveChangesForPatch(ProductDto productToPatch, Product productEntity);
        
    }
}
