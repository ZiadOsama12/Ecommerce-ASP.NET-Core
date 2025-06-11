using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public class CartService : ICartService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddOrUpdateItemToCartAsync(string userId, AddItemDto addItemDto)
        {

            var cart = await CheckIfCartExists(userId,false);
            if (cart == null)
            {
                throw new Exception("Not Found");
            }
            // Create it.


            var cartProduct = await unitOfWork.Cart.GetCartProductByCartIdAndProductId(cart.CartId, addItemDto.ProductId, true);
            if (cartProduct == null)
            {
                cartProduct = mapper.Map<CartProduct>(addItemDto);
                cartProduct.CartId = cart.CartId;
                if(cartProduct.Quantity <= 0)
                {
                    throw new Exception();
                }
                unitOfWork.Cart.CreateCartProduct(cartProduct);
            }
            else
            {
                Console.WriteLine(cartProduct.CartId);
                cartProduct.Quantity += addItemDto.Quantity;
                if (cartProduct.Quantity <= 0)
                {
                    unitOfWork.Cart.Delete(cartProduct);
                }
            }
            await unitOfWork.CompleteAsync();
        }

       
        public async Task<GetCartDto> GetCartByUserId(string userId, bool trackChanges)
        {

            var cart = await unitOfWork.Cart.GetCartByUserIdAsync(userId,false);

            Console.WriteLine(string.Join(", ", cart.CartProducts.Select(cp => cp.Quantity)));

            var cartDto = mapper.Map<Cart, GetCartDto>(cart);

            return cartDto;
        }
        public async Task<int> ClearCart(string userId)
        {
            var cart = await CheckIfCartExists(userId, false);
            if (cart == null)
            {
                throw new Exception("Not Found");
            }
            var NumberOfDeletedRows = await unitOfWork.Cart.ClearCartAsync(cart.CartId);

            return NumberOfDeletedRows;
        }


        private async Task<Cart> CheckIfCartExists(string userId, bool trackChanges)  // Repeated ???
        {
            var cart = await unitOfWork.Cart.GetCartByUserIdAsync(userId, trackChanges);

            //if (cart is null)
            //    throw new CompanyNotFoundException(companyId);
            return cart;
        }


    }
}
