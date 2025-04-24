using Api.Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IReviewService
    {
        Task<GetReviewsDto> GetReviewsForProductAsync(int productId);
        Task<double> GetAverageRatingAsync(int productId);
        Task<Review> GetReviewByReviewId(int reviewId);

        Task AddReviewAsync(CreateReviewDto reviewDto, string userId);
        Task RemoveReviewByReviewId(int reviewId);
        Task UpdateReview(UpdateReviewDto review, string userId);
    }
}
