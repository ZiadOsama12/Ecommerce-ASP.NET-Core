using Api.Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IOrderService
    {
        Task<IEnumerable<GetOrderDto>> GetOrdersByUserAsync(string userId);

        Task<GetOrderWithDetailsDto> GetOrderWithDetailsAsync(int orderId);
        Task<IEnumerable<Order>> GetOrdersInDateRangeAsync(DateTime start, DateTime end);

        Task<Order> CreateOrderAsync(int cartId, string userId);


    }
}
