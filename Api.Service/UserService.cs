using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<User> GetByIdAsync(string id)
        {
            return await unitOfWork.User.GetUserAsync(id, false);
        }
    }
}
