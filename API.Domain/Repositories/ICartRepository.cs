using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface ICartRepository
    {
        Task<Cart> GetCartByUserIdAsync(string userId, bool trackChanges);
        Task<CartProduct> GetCartProductByCartIdAndProductId(int cartId, int productId, bool trackChanges);

        void CreateCartProduct(CartProduct cartProduct);
        //Task AddItemToCartAsync(int cartId, Product product, int quantity, bool trackChanges);
        Task<int> ClearCartAsync(int cartId);

        void Delete(CartProduct cartProduct); // Will execute the implementation of the RepoBase
    }
}
