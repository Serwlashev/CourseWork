using AutoMapper;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Core.Domain.Entity;

namespace Services.Catalog.Core.Application.Mapping
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ReverseMap();

            CreateMap<Product, ProductDTO>()
                .ReverseMap();
        }
    }
}
