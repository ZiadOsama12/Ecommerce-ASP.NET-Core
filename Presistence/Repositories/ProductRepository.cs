using Api.Domain.Entities;
using Api.Domain.Repositories;
using Azure;
using Microsoft.EntityFrameworkCore;
using Presistence.Repositories.Extensions;
using Shared.RequestFeatures;
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

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters productParameters, bool trackChanges)
        {
            var products = FindAll(trackChanges)
                .FilterProductss(productParameters.MinPrice, productParameters.MaxPrice)
            //.Search(employeeParameters.SearchTerm) // Note the position of the Search is important
            .OrderBy(e => e.Name)
            //.Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            //.Take(productParameters.PageSize)
            .Search(productParameters.SearchTerm) // Note the position of the Search is important
            .Sort(productParameters.OrderBy);
            
            
            var pagedProducts = await PagedList<Product>.ToPagedListAsync(products, productParameters.PageNumber ,productParameters.PageSize);
                //.ToListAsync();
            return pagedProducts;
        }
        public void DeleteProduct(Product product) => Delete(product);


        public Task<IEnumerable<Product>> GetFeaturedProductsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetProductByIdAsync(int id, bool trackChanges)
        {
            var product = await FindByCondition(p => p.PId == id, trackChanges).SingleOrDefaultAsync();
            return product;
        }

        public async Task<PagedList<Product>> GetProductsByCategoryAsync(ProductParameters productParameters, int categoryId)
        {
            var products = FindByCondition(p => p.CId == categoryId, false);

            var pagedProducts = await PagedList<Product>.ToPagedListAsync(products, productParameters.PageNumber, productParameters.PageSize);
            //.ToListAsync();
            return pagedProducts;

        }

        public Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            throw new NotImplementedException();
        }
    }
}
