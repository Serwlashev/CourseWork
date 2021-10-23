using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Services.Basket.Core.Entities;
using Services.Basket.Core.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Basket.Data.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        public async Task<ShoppingCart> CreateBasket(ShoppingCart basket, CancellationToken token = default)
            => await UpdateBasket(basket, token);

        public async Task DeleteBasket(string userName, CancellationToken token = default)
        {
            await _redisCache.RemoveAsync(userName, token).ConfigureAwait(false);
        }

        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken token = default)
        {
            var basket = await _redisCache.GetStringAsync(userName, token).ConfigureAwait(false);

            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket, CancellationToken token = default)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket), token).ConfigureAwait(false);

            return await GetBasket(basket.UserName, token);
        }
    }
}
