using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class CartoonUpdateService : ICartoonUpdateService
    {
        public async Task<Cartoon> UpdateAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            await GenreGetService.ValidateAsync(cartoonUpdateModel);
            
            return await CartoonDataAccess.UpdateAsync(cartoonUpdateModel);
        }
        
        private ICartoonDataAccess CartoonDataAccess { get; }

        private IGenreGetService GenreGetService { get; }
        public CartoonUpdateService(ICartoonDataAccess cartoonDataAccess, IGenreGetService iGenreGetService)
        {
            CartoonDataAccess = cartoonDataAccess;
            GenreGetService = iGenreGetService;
        }
    }
}