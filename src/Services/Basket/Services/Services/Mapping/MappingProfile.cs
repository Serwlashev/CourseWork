using AutoMapper;
using Services.Basket.Core.Entities;
using Services.Basket.Services.DTO;

namespace Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ShoppingCart, ShoppingCartDTO>()
                .ReverseMap();

            CreateMap<ShoppingCartItem, ShoppingCartItemDTO>()
                .ReverseMap();
        }
    }
}
