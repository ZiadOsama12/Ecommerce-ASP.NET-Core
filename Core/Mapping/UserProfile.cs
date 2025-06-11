using Api.Domain.Entities;
using AutoMapper;
using Shared.DTOs;

namespace Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserForRegistrationDto, User>();
            CreateMap<GetUserDto, User>().ReverseMap();

        }
    }
}
