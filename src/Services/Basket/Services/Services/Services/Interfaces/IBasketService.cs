using Services.Basket.Services.DTO;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Basket.Services.Services.Interfaces
{
    public interface IBasketService
    {
        Task<ShoppingCartDTO> GetBasket(string userName, CancellationToken token = default);
        Task<ShoppingCartDTO> CreateBasket(ShoppingCartDTO basket, CancellationToken token = default);
        Task<ShoppingCartDTO> UpdateBasket(ShoppingCartDTO basket, CancellationToken token = default);
        Task DeleteBasket(string userName, CancellationToken token = default);
    }
}
