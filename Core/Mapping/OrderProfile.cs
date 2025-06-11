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
    internal class OrderProfile : Profile
    {
        public OrderProfile() {

            CreateMap<Order, GetOrderDto>()
             .ForMember(o => o.OrderId, opt => opt.MapFrom(src => src.OrderNo))
             .ReverseMap();



            CreateMap<Order, GetOrderWithDetailsDto>()
               .ForMember(od => od.OrderDetails, opt => opt.MapFrom(src => src.OrderProducts)) // will search for the next mapping.
            .ForMember(dest => dest.Order, opt => opt.MapFrom(src => src));  // maps to GetOrderDto


            CreateMap<OrderProduct, GetOrderProdcutDto>(); 

        }
    }
}
