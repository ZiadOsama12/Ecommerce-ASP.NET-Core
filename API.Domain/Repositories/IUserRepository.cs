using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync(bool trackChanges);
        Task<User> GetUserByIdAsync(string id, bool trackChanges);
        void CreateUser(User user);
        void DeleteUser(User user);
    }
}
