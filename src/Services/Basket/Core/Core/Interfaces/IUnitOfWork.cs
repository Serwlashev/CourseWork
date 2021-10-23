using Services.Basket.Core.Interfaces.Repositories;

namespace Services.Basket.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IBasketRepository BasketRepository { get; }
    }
}
