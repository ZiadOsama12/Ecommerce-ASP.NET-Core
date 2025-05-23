﻿using Api.Domain.Entities;
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
        public ICartRepository Cart { get; private set; }
        public IOrderRepository Order { get; private set; }
        public IOrderProductRepository OrderProducts { get; private set; }
        public IReviewRepository Review { get; private set; }
        public UnitOfWork(RepositoryDbContext repositoryDbContext)
        {
            this.repositoryDbContext = repositoryDbContext;
            User = new UserRepository(repositoryDbContext);
            Product = new ProductRepository(repositoryDbContext);
            Cart = new CartRepository(repositoryDbContext);
            Order = new OrderRepository(repositoryDbContext);
            OrderProducts = new OrderProductRepository(repositoryDbContext);
            Review = new ReviewRepository(repositoryDbContext);
        }


      
        public async Task<int> CompleteAsync()
        {
            return await repositoryDbContext.SaveChangesAsync();
        }

        public void Dispose() // Check again
        {
            repositoryDbContext.Dispose();
        }
    }
}
