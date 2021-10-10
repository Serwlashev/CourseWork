using AutoMapper;
using Services.Catalog.Core.Application.DTO;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllCategories;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetAllProducts;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory;
using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdProduct;

namespace Services.Catalog.Presentation.Catalog.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDTO, GetAllProductsQueryResponse>();

            CreateMap<ProductDTO, GetByIdProductQueryResponse>();

            CreateMap<ProductDTO, FindProductsQueryResponse>();

            CreateMap<CategoryDTO, GetAllCategoriesQueryResponse>();

            CreateMap<CategoryDTO, GetByIdCategoryQueryResponse>();
        }
    }
}
