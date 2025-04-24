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
    public class ReviewService : IReviewService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task AddReviewAsync(CreateReviewDto reviewDto, string userId)
        {
            var review = mapper.Map<CreateReviewDto, Review>(reviewDto);
            review.UserId = userId;
            unitOfWork.Review.AddReview(review);
            await unitOfWork.CompleteAsync();
        }

        public async Task<double> GetAverageRatingAsync(int productId)
        {
            var avgRating = await unitOfWork.Review.GetAverageRatingAsync(productId, false);
            return avgRating;
        }

        public async Task<Review> GetReviewByReviewId(int reviewId)
        {
            return await unitOfWork.Review.GetReviewByReviewId(reviewId, false);
        }

        public async Task<GetReviewsDto> GetReviewsForProductAsync(int productId) // can be more optimized.
        {
            IEnumerable<Review> reviews = await unitOfWork.Review.GetReviewsForProductAsync(productId, false);
            double average = await GetAverageRatingAsync(productId);
            var reviewDto = mapper.Map<IEnumerable<Review>, ICollection<CreateReviewDto>>(reviews);
            GetReviewsDto getReviewsDto = new ()
            {
                Reviews = reviewDto,
                AvgRating = average
            };

            return getReviewsDto;
        }

        public async Task RemoveReviewByReviewId(int reviewId)
        {
            var review = await GetReviewByReviewId(reviewId);

            unitOfWork.Review.RemoveReview(review);
            await unitOfWork.CompleteAsync();
        }

        public async Task UpdateReview(UpdateReviewDto reviewDto, string userId)
        {
            var review = mapper.Map<UpdateReviewDto, Review>(reviewDto);
            review.UserId = userId;
            unitOfWork.Review.UpdateReview(review);
            await unitOfWork.CompleteAsync();
        }
    }
}
