using Api.Domain.Entities;
using AutoMapper;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    internal class ReviewProfile : Profile
    {
        public ReviewProfile() { 
        
            CreateMap<Review, CreateReviewDto>().ReverseMap();
            CreateMap<Review, UpdateReviewDto>()
                .ForMember(ur => ur.Id, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();

        }
    }
}
