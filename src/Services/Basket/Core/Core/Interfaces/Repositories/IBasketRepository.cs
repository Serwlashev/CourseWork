using Services.Basket.Core.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Basket.Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> GetBasket(string userName, CancellationToken token = default);
        Task<ShoppingCart> CreateBasket(ShoppingCart basket, CancellationToken token = default);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken token = default);
        Task DeleteBasket(string userName, CancellationToken token = default);
    }
}
