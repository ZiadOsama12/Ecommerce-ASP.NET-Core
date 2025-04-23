using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly RepositoryDbContext _repositoryContext;

        public ProductRepository(RepositoryDbContext repositoryContext) : base(repositoryContext) 
            { }

        public async Task<IEnumerable<Product>> GetAllProductsAsync(bool trackChanges)
        {
            var products = await FindAll(trackChanges).ToListAsync();
            return products;
        }
        public void DeleteProduct(Product product) => Delete(product);


        public Task<IEnumerable<Product>> GetFeaturedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await FindByCondition(p => p.PId == id, false).SingleOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var products = await FindByCondition(p => p.CId == categoryId, false).ToListAsync();

            return products;
        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
