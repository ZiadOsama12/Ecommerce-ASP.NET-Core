using Api.Domain.Entities;
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
    [ApiController]
    [Route("api/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IReviewService reviewService;

        public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService)
        {
            _logger = logger;
            this.reviewService = reviewService;
        }
        [HttpOptions]
        public IActionResult GetCompaniesOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST, PUT, DELETE");
            return Ok();
        }
        [HttpGet("products/{productId}")]
        [Authorize]
        public async Task<IActionResult> GetReviewsForProductAsync(int productId) // can
        {
            var reviews = await reviewService.GetReviewsForProductAsync(productId);
             

            return Ok(reviews);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddReviewAsync([FromBody]CreateReviewDto reviewDto)
        {
            string userId = GetCurrentUser();
            await reviewService.AddReviewAsync(reviewDto, userId);
            return Ok();
        }
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewDto reviewDto)
        {
            string userId = GetCurrentUser();
            await reviewService.UpdateReview(reviewDto, userId);
            return Ok();
        }
        [Authorize]
        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> RemoveReview(int reviewId)
        {
            await reviewService.RemoveReviewByReviewId(reviewId);
            return NoContent();
        }

        private string? GetCurrentUser()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
    }
}
