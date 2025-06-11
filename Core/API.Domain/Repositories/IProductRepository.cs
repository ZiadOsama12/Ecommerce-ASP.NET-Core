using Api.Domain.Entities;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameteres, bool trackChanges);
        Task<Product> GetProductByIdAsync(int id, bool trackChanges);
        Task<PagedList<Product>> GetProductsByCategoryAsync(ProductParameters productParameters, int categoryId);
        Task<IEnumerable<Product>> SearchProductsAsync(string keyword);
        Task<IEnumerable<Product>> GetFeaturedProductsAsync();
        void Create(Product entity);
        void Update(Product entity);
        void DeleteProduct(Product entity);
    }
}
