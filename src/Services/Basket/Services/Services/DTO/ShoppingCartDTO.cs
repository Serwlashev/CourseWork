using System.Collections.Generic;

namespace Services.Basket.Services.DTO
{
    public class ShoppingCartDTO
    {
        public string UserName { get; set; }
        public List<ShoppingCartItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
