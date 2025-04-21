using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsForProductAsync(Guid productId);
        Task<IEnumerable<Review>> GetPendingReviewsAsync(); // if there's moderation

    }
}
