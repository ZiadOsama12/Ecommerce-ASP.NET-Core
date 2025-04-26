using Api.Domain.Entities.Exceptions;
using Api.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using System.Text.Json;
using Shared.DTOs;
using Shared.RequestFeatures;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;
using System.ComponentModel.Design;
using Api.Domain.Responses;

namespace Presentation.Controllers
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
            Console.WriteLine("HELLLOOO");
            var product = await productService.GetByIdAsync(id, trackChanges: false);
            return Ok(product);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var pagedResult = await productService.GetAllProductsAsync(productParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(pagedResult.metaData));

            return Ok(pagedResult.Item1);
        }
        [HttpGet("categories/{id}")]
        [Authorize]
        public async Task<IActionResult> GetProductsByCategoryId([FromRoute]int id,[FromQuery] ProductParameters productParameters)
        {
            var pagedResult = await productService.GetProductsByCategoryId(id, productParameters, trackChanges: false);

            Response.Headers.Add("X-Pagination",
                JsonConvert.SerializeObject(pagedResult.metaData));

            return Ok(pagedResult.Item1);
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


        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> PartiallyUpdateProduct([FromRoute]int id, [FromBody] JsonPatchDocument<ProductDto> patchDoc)
        {
            var result = await productService.GetProductByIdToPatchAsync(id, trackChanges: true);

            patchDoc.ApplyTo(result.productToPatch);

            await productService.SaveChangesForPatch(result.productToPatch, result.product);

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
