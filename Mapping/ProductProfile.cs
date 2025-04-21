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
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
