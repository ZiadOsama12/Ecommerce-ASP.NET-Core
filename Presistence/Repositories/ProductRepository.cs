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

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await FindByCondition(p => p.PId == id, false).SingleOrDefaultAsync();
            return product;
        }
    }
}
