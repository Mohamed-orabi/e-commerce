using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product,ProductToReturnDto>()
                .ForMember(des => des.ProductBrand, opt => opt.MapFrom(src => src.ProductBrand.Name))
                .ForMember(des => des.ProductType, opt => opt.MapFrom(src => src.ProductType.Name))
                .ForMember(des => des.PictureUrl,opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<Address,AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto,CustomerBasket>();
            CreateMap<BasketItemDto,BasketItem>();
        }
    }
}