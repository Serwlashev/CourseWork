using Microsoft.EntityFrameworkCore;
using Services.Catalog.Core.Domain.Entity;
using System;

namespace Services.Catalog.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.CategoryId);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Bakery", CreatedAt = DateTime.Now },
                new Category { Id = 2, Name = "Dairy", CreatedAt = DateTime.Now },
                new Category { Id = 3, Name = "Cereals", CreatedAt = DateTime.Now },
                new Category { Id = 4, Name = "Alcohol", CreatedAt = DateTime.Now }
                );

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Bread",
                    Number = 10,
                    Price = 15,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Fresh, baked bread",
                    FullDescription = "Bread, baked food product made of flour or meal that is moistened, kneaded, and sometimes fermented. A major food since prehistoric times, it has been made in various forms using a variety of ingredients and methods throughout the world.",
                    Image = "https://www.cookingclassy.com/wp-content/uploads/2020/04/bread-recipe-1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Bun",
                    Number = 8,
                    Price = 25,
                    CategoryId = 1,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Burger bun",
                    FullDescription = "A bun is a small, sometimes sweet, bread-based item or roll. Though they come in many shapes and sizes, they are most commonly hand-sized or smaller, with a round top and flat bottom. ... A bun is normally made from dough that has been enriched with sugar and butter and occasionally egg.",
                    Image = "https://upload.wikimedia.org/wikipedia/commons/1/10/Sesame_seed_hamburger_buns.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Eggs",
                    Number = 100,
                    Price = 2,
                    CategoryId = 2,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Fresh chicken eggs",
                    FullDescription = "Eggs have a hard shell of calcium carbonate enclosing a liquid white, a single yolk (or an occasional double yolk)and an air cell. The white or albumen is a clear liquid that turns to an opaque white when cooked or beaten. The yolk is orange to yellow in color, and becomes pale yellow when cooked to a solid form.",
                    Image = "https://image.made-in-china.com/2f0j00QtmYvhRHOOoU/Large-Size-4-30-Cells-Plastic-Packing-Eggs-Tray-for-Egg-Box.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Milk",
                    Number = 20,
                    Price = 35,
                    CategoryId = 2,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Cow's milk",
                    FullDescription = "A whitish liquid containing proteins, fats, lactose, and various vitamins and minerals that is produced by the mammary glands of all mature female mammals after they have given birth and serves as nourishment for their young.",
                    Image = "https://www.aldi.com.au/fileadmin/fm-dam/Products/Groceries/Fresh_Produce/Dairy_Eggs/Products/ALN2364_AWARDS_DAIRY_PD_388x314_23.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Oatmeal",
                    Number = 14,
                    Price = 40,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Ready breakfest",
                    FullDescription = "Oatmeal is a breakfast food made from oats and liquid like water or milk. This whole-grain powerhouse has been packing serious nutrition and hearty flavor into breakfast for generations. It's one of the few comfort foods that's as good for you as it is just plain good.",
                    Image = "https://m.media-amazon.com/images/I/71guVflNsVL._AC_SL1200_.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Buckwheat",
                    Number = 12,
                    Price = 35,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Buckwheat",
                    FullDescription = "Buckwheat is a fast-growing annual. The simple leaves are heart-shaped and borne along reddish hollow stems. The white flowers are produced in terminal clusters and are pollinated by bees and other insects. The kernels of the triangular-shaped seeds are enclosed by a tough dark brown or gray rind.",
                    Image = "https://digitalcontent.api.tesco.com/v2/media/ghs/feac0a4d-3b14-4c56-86fe-0158297a50dc/snapshotimagehandler_1067193654.jpeg?h=540&w=540"
                },
                new Product
                {
                    Id = 7,
                    Name = "Poridge",
                    Number = 6,
                    Price = 39,
                    CategoryId = 3,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "The best choice for healthy breakfest",
                    FullDescription = "Porridge is a food commonly eaten as a breakfast cereal dish, made by heating or boiling ground, crushed or chopped starchy plants, typically grain, in milk. It is often cooked or served with added flavourings such as sugar, honey, (dried) fruit or syrup to make a sweet cereal, or it can be mixed with spices, meat or vegetables to make a savoury dish. It is usually served hot in a bowl, depending on its consistency.",
                    Image = "https://digitalcontent.api.tesco.com/v2/media/ghs/8d4337b0-802a-4c27-ac92-cb867c94efab/6c356bcb-ee32-444e-a2ed-5c4d91de13f2_995068533.jpeg?h=540&w=540"
                },
                new Product
                {
                    Id = 8,
                    Name = "Brandy",
                    Number = 15,
                    Price = 200,
                    CategoryId = 4,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Scottich brandy",
                    FullDescription = "Brandy, alcoholic beverage distilled from wine or a fermented fruit mash. Beverage brandy contains about 50 percent alcohol by volume; brandy used to fortify sherry, Madeira, and the other dessert wines contains about 80–95 percent alcohol by volume. Like other distilled liquor, brandy does not improve after bottling.",
                    Image = "data:image/jpeg;base64,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"
                },
                new Product
                {
                    Id = 9,
                    Name = "Vodka",
                    Number = 11,
                    Price = 100,
                    CategoryId = 4,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Vodka \"Gorbatschow\"",
                    FullDescription = "Vodka, distilled liquor, clear and colourless and without definite aroma or taste, ranging in alcoholic content from about 40 to 55 percent. Because it is highly neutral, flavouring substances having been mainly eliminated during processing, it can be made from a mash of the cheapest and most readily available raw materials suitable for fermentation.",
                    Image = "data:image/jpeg;base64,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"
                },
                new Product
                {
                    Id = 10,
                    Name = "Wine",
                    Number = 17,
                    Price = 150,
                    CategoryId = 4,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Semy-sweet wine",
                    FullDescription = "A wine is usually described as light, medium or full body. It is not necessarily a negative attribute for wine. Chocolaty: The flavors and mouthfeel associated with chocolate, typically among rich red wines such as Cabernet Sauvignon and Pinot noir.",
                    Image = "https://www.tycaton.com/wp-content/uploads/2015/11/TyCatonPetiteSirahMoonMtnNV-1-700x905.jpg"
                },
                new Product
                {
                    Id = 11,
                    Name = "Beer",
                    Number = 40,
                    Price = 50,
                    CategoryId = 4,
                    CreatedAt = DateTime.Now,
                    ShortDescription = "Beer \"Amstel\"",
                    FullDescription = "Beer is an alcoholic beverage produced by extracting raw materials with water, boiling (usually with hops), and fermenting. In some countries, beer is defined by law—as in Germany, where the standard ingredients, besides water, are malt (kiln-dried germinated barley), hops, and yeast.",
                    Image = "http://bristol.ru/upload/iblock/898/b6e6cbbe_6be9_11e9_810c_60a44c3cd7b8_39504a81_8606_11e9_810d_60a44c3cd7b8.resize2.jpg"
                }
            );
        }
    }
}
