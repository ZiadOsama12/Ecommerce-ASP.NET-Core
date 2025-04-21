using Api.Domain.Entities;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services.Contracts
{
    public interface IUserService
    {
        public Task<GetUserDto> GetUserByIdAsync(string id, bool trackChanges);
        public Task<List<GetUserDto>> GetAllUsersAsync(bool trackChanges);
    }
}
