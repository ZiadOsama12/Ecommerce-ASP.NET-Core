using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using AutoMapper;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public class OrderService : IOrderService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrderAsync(int cartId, string userId)
        {

            var cartWithProducts = await unitOfWork.Cart.GetCartProductWithProductByCartId(cartId, false); // track? ? 

            var order = new Order
            {
                UserId = userId,
                //OrderDate = DateTime.UtcNow,
                TotalPrice = cartWithProducts.Sum(cp => cp.Quantity * (cp.Product?.Price ?? 0)),
                Status = "Pending",
                OrderProducts = cartWithProducts.Select(cp => new OrderProduct
                {
                    ProductId = cp.ProductId,
                    Amount = cp.Quantity,
                    
                    UnitPrice = cp.Product?.Price ?? 0 // changable
                }).ToList()
            };
            unitOfWork.Order.CreateOrder(order);
            unitOfWork.Cart.ClearCartAsync(cartId);
            
            await unitOfWork.CompleteAsync();

            return order;
        }

        public async Task<IEnumerable<GetOrderDto>> GetOrdersByUserAsync(string userId)
        {
            var orders = await unitOfWork.Order.GetOrdersByUserAsync(userId, false);

            Console.WriteLine(orders.First().OrderNo);
            var ordersDto = mapper.Map<List<GetOrderDto>>(orders);
            
            return ordersDto;
        }

        public async Task<IEnumerable<Order>> GetOrdersInDateRangeAsync(DateTime start, DateTime end)
        {
            var orders = await unitOfWork.Order.GetOrdersInDateRangeAsync(start, end, false);
            return orders;
        }

        public async Task<GetOrderWithDetailsDto> GetOrderWithDetailsAsync(int orderId)
        {
            var orders = await unitOfWork.Order.GetOrderWithDetailsAsync(orderId, false);

            var orderWithDetailsDto = mapper.Map<Order,GetOrderWithDetailsDto>(orders);

            return orderWithDetailsDto;
        }
    }
}
