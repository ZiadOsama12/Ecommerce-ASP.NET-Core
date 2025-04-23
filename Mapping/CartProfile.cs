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
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            // Map Cart to GetCartDto
            CreateMap<Cart, GetCartDto>() // map property Products "CartProductDto" from property CartProducts "CartProduct".....Look for any mapping like the next one
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.CartProducts))
                .ReverseMap() // This will handle mapping from GetCartDto to Cart
                .ForMember(dest => dest.CartProducts, opt => opt.MapFrom(src => src.Products)); ;

            // Map CartProduct to CartProductDto
            CreateMap<CartProduct, CartProductDto>() // == "whenever you find CartProduct => CartProductDto....do that..So it will be use for the previous mappping
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ReverseMap(); // will do same operations because of the equal names

            CreateMap<CartProduct, AddItemDto>()
                .ReverseMap();
        }
    }
}
