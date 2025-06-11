using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId, bool trackChanges);
        Task<Order> GetOrderWithDetailsAsync(int orderId, bool trackChanges);
        Task<Order> GetOrderByOrderId(int orderId, bool trackChanges);

        Task<IEnumerable<Order>> GetOrdersInDateRangeAsync(DateTime start, DateTime end, bool trackChanges);
        void CreateOrder(Order order);

    }
}
