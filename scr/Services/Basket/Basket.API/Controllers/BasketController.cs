using Basket.API.Entities;
using Basket.API.Repostories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepostoriey basketRepostoriey;

        public BasketController(IBasketRepostoriey basketRepostoriey)
        {
            this.basketRepostoriey = basketRepostoriey;
        }
        [HttpGet("{username}",Name = "GetBasket")]
        [ProducesResponseType(typeof(ShoppingCart),(int)HttpStatusCode.OK)]

        public async  Task<ActionResult<ShoppingCart>> GetBasket(string username)
        {
            var basket=await basketRepostoriey.GetBasket(username);
        return Ok(basket ?? new ShoppingCart(username));

    }
        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]

        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        { 
          return Ok(  await basketRepostoriey.updateBasket(basket));

        }
        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]

        public async Task<IActionResult> DeleteBasket(string username)
        { await basketRepostoriey.DeleteBasket(username);
            return Ok();

        }
    }
}
