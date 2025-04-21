using Api.Domain.Entities.Exceptions;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared.DTOs;

namespace Ecommerce.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductById(int id)
        {
            //_logger.LogInformation("HEllo");
            //throw new BadRequestException("Hellooo helloo");
            //return Ok(new { ProductId = 1 });
            var product = await productService.GetByIdAsync(id, trackChanges: false);
            return Ok(product);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var product = await productService.GetAllProductsAsync(trackChanges: false);
            return Ok(product);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            var product = await productService.CreateProduct(productDto);
            return Ok(product);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
        {
            await productService.UpdateProduct(productDto);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
