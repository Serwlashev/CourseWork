using AutoMapper;
using Services.Basket.Core.Entities;
using Services.Basket.Core.Interfaces;
using Services.Basket.Services.DTO;
using Services.Basket.Services.Services.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Basket.Services.Services.Implementation
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public BasketService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<ShoppingCartDTO> CreateBasket(ShoppingCartDTO basket, CancellationToken token = default)
        {
            var newBasket = await _uow.BasketRepository.CreateBasket(_mapper.Map<ShoppingCart>(basket), token);

            return _mapper.Map<ShoppingCartDTO>(newBasket);
        }

        public async Task DeleteBasket(string userName, CancellationToken token = default)
            => await _uow.BasketRepository.DeleteBasket(userName, token);

        public async Task<ShoppingCartDTO> GetBasket(string userName, CancellationToken token = default)
        {
            var newBasket = await _uow.BasketRepository.GetBasket(userName, token);

            return _mapper.Map<ShoppingCartDTO>(newBasket);
        }

        public async Task<ShoppingCartDTO> UpdateBasket(ShoppingCartDTO basket, CancellationToken token = default)
        {
            var newBasket = await _uow.BasketRepository.UpdateBasket(_mapper.Map<ShoppingCart>(basket), token);

            return _mapper.Map<ShoppingCartDTO>(newBasket);
        }
    }
}
