using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

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

            CreateMap<Core.Entities.Identity.Address,AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto,CustomerBasket>();
            CreateMap<BasketItemDto,BasketItem>();
            CreateMap<AddressDto,Core.Entities.OrderAggregate.Address>();
            CreateMap<Order,OrderToReturnDto>()
                .ForMember(des => des.DeliveryMethod , opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(des => des.ShippingPrice , opt => opt.MapFrom(src => src.DeliveryMethod.Price));

            CreateMap<OrderItem,OrderItemDto>()
                .ForMember(des => des.ProductId, opt => opt.MapFrom(src => src.ItemOrdered.ProductItemId))
                .ForMember(des => des.ProductName, opt => opt.MapFrom(src => src.ItemOrdered.ProductName))
                .ForMember(des => des.PictureUrl , opt => opt.MapFrom(src => src.ItemOrdered.PictureUrl))
                .ForMember(des => des.PictureUrl , opt => opt.MapFrom<OrderItemUrlResolver>());
        }
    }
}