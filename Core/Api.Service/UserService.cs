using Api.Domain.Entities;
using Api.Domain.Repositories;
using Api.Services.Contracts;
using AutoMapper;
using Shared.DTOs;
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
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<List<GetUserDto>> GetAllUsersAsync(bool trackChanges)
        {
            var users = await unitOfWork.User.GetAllUsersAsync(trackChanges);
            List<GetUserDto> usersDto = mapper.Map<List<GetUserDto>>(users);
            return usersDto;
        }

        public async Task<GetUserDto> GetUserByIdAsync(string id, bool trackChanges)
        {
            var user = await unitOfWork.User.GetUserByIdAsync(id, trackChanges);
            GetUserDto userDto = mapper.Map<GetUserDto>(user);
            return userDto;
        }
        
    }
}
