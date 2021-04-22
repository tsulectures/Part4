using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IBasketRepository
    {
         Task<CustomerBasket> GetBacketAsync(string basketId);

         Task<CustomerBasket> UpdateBacketAsync(CustomerBasket basket);
         
         Task<bool> DeleteBasketAsync(string basket);
    }
}