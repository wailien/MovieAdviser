using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class CartoonUpdateService : ICartoonUpdateService
    {
        public Task<Cartoon> UpdateAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            return CartoonDataAccess.UpdateAsync(cartoonUpdateModel);
        }
        
        private ICartoonDataAccess CartoonDataAccess { get; }

        public CartoonUpdateService(ICartoonDataAccess cartoonDataAccess)
        {
            CartoonDataAccess = cartoonDataAccess;
        }
    }
}