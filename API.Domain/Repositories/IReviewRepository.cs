using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsForProductAsync(int productId, bool trackChanges);
        Task<double> GetAverageRatingAsync(int productId, bool trackChanges);

        Task<Review> GetReviewByReviewId(int reviewId, bool trackChanges);
        void AddReview(Review review);
        void RemoveReview(Review review);
        void UpdateReview(Review review);
    }
}
