using Microsoft.AspNetCore.Mvc;
using Services.Basket.Services.DTO;
using Services.Basket.Services.Services.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{userName}", Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDTO>> GetBasket(string userName, CancellationToken token)
        {
            var basket = await _basketService.GetBasket(userName, token);

            return Ok(basket ?? new ShoppingCartDTO() { UserName = userName });
        }

        [HttpPost("CreateBasket")]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDTO>> CreateBasket([FromBody] ShoppingCartDTO basket, CancellationToken token)
            => Ok(await _basketService.CreateBasket(basket, token));

        [HttpPut("UpdateBasket")]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCartDTO>> UpdateBasket([FromBody] ShoppingCartDTO basket, CancellationToken token)
            => Ok(await _basketService.UpdateBasket(basket, token));

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCartDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _basketService.DeleteBasket(userName);

            return Ok();
        }
    }
}
