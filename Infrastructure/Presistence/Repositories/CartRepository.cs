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
    public class CartRepository : BaseRepository<CartProduct>, ICartRepository
    {
        public CartRepository(RepositoryDbContext repositoryContext) : base(repositoryContext)
        {
        }


        public async Task<int> ClearCartAsync(int cartId)
        {
            return await DeleteByCondition(o => o.CartId == cartId);
        }

        public async Task<CartProduct> GetCartProductByCartIdAndProductId(int cartId, int productId, bool trackChanges)
        {
            var cart = await FindByCondition(cp => cp.CartId == cartId && cp.ProductId == productId, trackChanges).FirstOrDefaultAsync();

            return cart;
        }

        public async Task<Cart> GetCartByUserIdAsync(string userId, bool trackChanges)
        {
            var cart = await RepositoryDbContext.Carts.Where(c => c.UserId == userId)
                .Include(c => c.CartProducts)
                .FirstOrDefaultAsync();

            return cart;
        }

        public void CreateCartProduct(CartProduct cartProduct)
        {
            Create(cartProduct);
        }

        public async Task<List<CartProduct>> GetCartProductWithProductByCartId(int cartId, bool trackChanges)
        {
            var cart = await FindByCondition(c => c.CartId == cartId, trackChanges)
                .Include(c => c.Product)
                .ToListAsync();
            return cart;
        }
    }
}
