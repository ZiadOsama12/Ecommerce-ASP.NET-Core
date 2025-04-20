using Api.Domain.Entities.Exceptions;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
        public async Task<IActionResult> Index(int id)
        {
            //_logger.LogInformation("HEllo");
            //throw new BadRequestException("Hellooo helloo");
            //return Ok(new { ProductId = 1 });
            var product = await productService.GetByIdAsync(id);
            return Ok(product);
        }
    }
}
