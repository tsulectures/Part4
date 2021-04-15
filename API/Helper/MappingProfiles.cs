using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(d => d.ProductBrand, o=>o.MapFrom(src=>src.ProductBrand.Name))
                .ForMember(d => d.ProductType, o=>o.MapFrom(src=>src.ProductType.Name));

            CreateMap<CustomerBasketDTO, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDTO, BasketItem>().ReverseMap();
        }
    }
}