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
        Task<IEnumerable<Order>> GetOrdersByUserAsync(string userId);
        Task<Order> GetOrderWithTrackingDetailsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersInDateRangeAsync(DateTime start, DateTime end);

    }
}
