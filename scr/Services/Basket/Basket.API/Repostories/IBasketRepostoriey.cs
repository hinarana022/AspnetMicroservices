using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repostories
{
    public interface IBasketRepostoriey
    {
        Task<ShoppingCart> GetBasket(string username);   
        Task<ShoppingCart> updateBasket(ShoppingCart basket);
        Task DeleteBasket(string username);

    }
}
