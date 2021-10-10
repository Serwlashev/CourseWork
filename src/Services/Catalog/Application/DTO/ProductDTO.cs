namespace Services.Catalog.Core.Application.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public long CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int Number { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Image { get; set; }
    }
}
