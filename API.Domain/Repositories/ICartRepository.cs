using Api.Domain.Entities;
using Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(Guid userId);
        Task AddItemToCartAsync(Guid cartId, Product product, int quantity);
        Task ClearCartAsync(Guid cartId);
    }
}
