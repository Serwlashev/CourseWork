using Microsoft.Extensions.Caching.Distributed;
using Services.Basket.Core.Interfaces;
using Services.Basket.Core.Interfaces.Repositories;
using Services.Basket.Data.Repositories;

namespace Services.Basket.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDistributedCache _redisCache;
        private IBasketRepository _basketRepository;

        public UnitOfWork(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public IBasketRepository BasketRepository => _basketRepository ??= new BasketRepository(_redisCache);
    }
}
