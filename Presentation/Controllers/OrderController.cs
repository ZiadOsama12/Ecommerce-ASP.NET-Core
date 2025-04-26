using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            this.orderService = orderService;
        }

        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetOrderByUserId()
        {
            var userId = GetCurrentUser();
            var order = await orderService.GetOrdersByUserAsync(userId);
            return Ok(order);
        }
        [Authorize]
        [HttpGet("{orderId:int}")] // Test it
        public async Task<IActionResult> GetOrderWithDetails(int orderId)
        {
           
            var order = await orderService.GetOrderWithDetailsAsync(orderId);
            return Ok(order);
        }
        [HttpPost("carts/{cartId:int}")]
        [Authorize]
        public async Task<IActionResult> CreateOrder(int cartId)
        {
            var userId = GetCurrentUser();
            await orderService.CreateOrderAsync(cartId, userId);
            return Ok("Created");
        }
        [Authorize]
        [HttpGet("date-range")]
        public async Task<IActionResult> GetOrdersInDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            Console.WriteLine(start);
            var orders = await orderService.GetOrdersInDateRangeAsync(start, end);
            return Ok(orders);
        }
        
        private string? GetCurrentUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
