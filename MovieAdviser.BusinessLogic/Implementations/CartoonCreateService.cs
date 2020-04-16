using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class CartoonCreateService : ICartoonCreateService
    {
        public Task<Cartoon> CreateAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            return CartoonDataAccess.InsertAsync(cartoonUpdateModel);
        }
        
        private ICartoonDataAccess CartoonDataAccess { get; }

        public CartoonCreateService(ICartoonDataAccess iCartoonDataAccess)
        {
            CartoonDataAccess = iCartoonDataAccess;
        }
    }
}