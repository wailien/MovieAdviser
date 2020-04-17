using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class MovieCreateService : IMovieCreateService
    {
        public async Task<Movie> CreateAsync(MovieUpdateModel movieUpdateModel)
        {
            await GenreGetService.ValidateAsync(movieUpdateModel);
            
            return await MovieDataAccess.InsertAsync(movieUpdateModel);
        }
        
        private IMovieDataAccess MovieDataAccess { get; }
        
        private IGenreGetService GenreGetService { get; }

        public MovieCreateService(IMovieDataAccess iMovieDataAccess, IGenreGetService iGenreGetService)
        {
            MovieDataAccess = iMovieDataAccess;
            GenreGetService = iGenreGetService;
        }
    }
}