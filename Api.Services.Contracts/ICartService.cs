using Api.Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface ICartService
    {
        Task AddOrUpdateItemToCartAsync(string userId, AddItemDto addItemDto);
        Task<GetCartDto>GetCartByUserId(string userId, bool trackChanges);

        //void UpdateCart(string userId, AddItemDto addItemDto);
        Task<int> ClearCart(string userId);
    }
}
