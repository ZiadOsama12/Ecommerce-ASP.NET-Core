using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/carts")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;
        private readonly ICartService cartService;

        public CartController(ILogger<CartController> logger, ICartService cartService)
        {
            _logger = logger;
            this.cartService = cartService;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCartByUserId()
        {
            var userId = GetCurrentUser();
            Console.WriteLine($"User id: {userId}");
            var cart = await cartService.GetCartByUserId(userId, false);
            return Ok(cart);
        }

        [HttpPost, HttpPut]
        [Authorize]
        public async Task<IActionResult> AddItemToTheCart([FromBody]AddItemDto addItemDto)
        {
            var userId = GetCurrentUser();
            Console.WriteLine($"User id: {userId}");
            await cartService.AddOrUpdateItemToCartAsync(userId, addItemDto);
            return Ok();
        }

        //[HttpPut]
        //[Authorize]
        //public async Task<IActionResult> UpdateItem([FromBody] AddItemDto addItemDto)
        //{
        //    var userId = GetCurrentUser();
        //    Console.WriteLine($"User id: {userId}");
        //    await cartService.AddOrUpdateItemToCartAsync(userId, addItemDto);
        //    return Ok();
        //}


        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> ClearCart()
        {
            var userId = GetCurrentUser();
            Console.WriteLine($"User id: {userId}");
            var deletedRows = await cartService.ClearCart(userId);
            return NoContent();
        }

        private string? GetCurrentUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
