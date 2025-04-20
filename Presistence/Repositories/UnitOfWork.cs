using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositoryDbContext repositoryDbContext;
        public IUserRepository User{ get; private set; }

        public IProductRepository Product { get; private set; }

        public UnitOfWork(RepositoryDbContext repositoryDbContext)
        {
            this.repositoryDbContext = repositoryDbContext;
            User = new UserRepository(repositoryDbContext);
            Product = new ProductRepository(repositoryDbContext);

        }


      
        public async Task<int> Complete()
        {
            return await repositoryDbContext.SaveChangesAsync();
        }

        public void Dispose() // Check again
        {
            repositoryDbContext.Dispose();
        }
    }
}
