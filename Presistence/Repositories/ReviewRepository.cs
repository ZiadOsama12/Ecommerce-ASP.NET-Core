using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    internal class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(RepositoryDbContext repositoryContext) : base(repositoryContext)
        {
        }

        public void AddReview(Review review)
        {
            Create(review);
        }

        public async Task<IEnumerable<Review>> GetReviewsForProductAsync(int productId, bool trackChanges)
        {
            var reviews = await FindByCondition(r => r.ProductId == productId, trackChanges).ToListAsync();
            return reviews;
        }

        public void RemoveReview(Review review)
        {
            Delete(review);
        }

        public void UpdateReview(Review review)
        {
            Update(review);
        }
        public async Task<double> GetAverageRatingAsync(int productId, bool trackChanges)
        {
            return await FindByCondition(r => r.ProductId == productId, trackChanges)
                .AverageAsync(r => (double?)r.Rating) ?? 0.0;
        }

        public async Task<Review> GetReviewByReviewId(int reviewId, bool trackChanges)
        {
            return await FindByCondition(r => r.Id == reviewId, trackChanges).FirstOrDefaultAsync();
        }
    }
}
