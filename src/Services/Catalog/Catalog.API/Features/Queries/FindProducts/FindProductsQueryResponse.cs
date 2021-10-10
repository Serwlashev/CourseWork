using Services.Catalog.Presentation.Catalog.API.Features.Queries.GetByIdCategory;

namespace Services.Catalog.Presentation.Catalog.API.Features.Queries.FindProducts
{
    public class FindProductsQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }
        public GetByIdCategoryQueryResponse Category { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string PathToImage { get; set; }
    }
}
