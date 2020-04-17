using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class CartoonCreateService : ICartoonCreateService
    {
        public async Task<Cartoon> CreateAsync(CartoonUpdateModel cartoonUpdateModel)
        {
            await GenreGetService.ValidateAsync(cartoonUpdateModel);
            
            return await CartoonDataAccess.InsertAsync(cartoonUpdateModel);
        }
        
        private ICartoonDataAccess CartoonDataAccess { get; }
        
        private IGenreGetService GenreGetService { get; }

        public CartoonCreateService(ICartoonDataAccess iCartoonDataAccess, IGenreGetService iGenreGetService)
        {
            CartoonDataAccess = iCartoonDataAccess;
            GenreGetService = iGenreGetService;
        }
    }
}