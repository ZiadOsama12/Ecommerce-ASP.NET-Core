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
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateOrder(Order order) // Create a record in Order table only.
        {
            Create(order);
        }

        public async Task<Order> GetOrderByOrderId(int orderId, bool trackChanges)
        {
            var order = await FindByCondition(o => o.OrderNo == orderId, trackChanges).FirstOrDefaultAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId, bool trackChanges)
        {
            var orders = await FindByCondition(o => o.UserId == userId, trackChanges).ToListAsync();
            return orders;
        }

        public async Task<IEnumerable<Order>> GetOrdersInDateRangeAsync(DateTime start, DateTime end, bool trackChanges)
        {
            var orders = await FindByCondition(o => o.OrderDate >= start && o.OrderDate <= end, trackChanges).ToListAsync(); // Check again.
            return orders;
        }

        public async Task<Order> GetOrderWithDetailsAsync(int orderId, bool trackChanges)
        {
            var ordersWithDetails = await 
                FindByCondition(o => o.OrderNo == orderId, false)
                .Include(o => o.OrderProducts).FirstOrDefaultAsync();

            return ordersWithDetails;
        }
    }
}
