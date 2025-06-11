using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IProductRepository Product { get; }
        ICartRepository Cart { get; }
        IOrderRepository Order { get; }

        IReviewRepository Review { get; }
        Task<int> CompleteAsync();
    }
}
