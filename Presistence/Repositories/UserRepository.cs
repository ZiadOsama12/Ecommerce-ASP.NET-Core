using Api.Domain.Entities;
using Api.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        //private readonly UserManager<User> userManager;
        private readonly RepositoryDbContext repositoryContext;
        public UserRepository(RepositoryDbContext repositoryContext) : base(repositoryContext)
        {
            //this.userManager = userManager;
        }

        public void CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsersAsync(bool trackChanges)
        {
            return await FindAll(trackChanges).ToListAsync();
        }

        public async Task<User> GetUserAsync(string id, bool trackChanges)
        {
            Console.WriteLine(id);
            return await FindByCondition(u => u.Id == id, trackChanges).SingleOrDefaultAsync();
        }
    }
}
