using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class MovieUpdateService : IMovieUpdateService
    {
        public async Task<Movie> UpdateAsync(MovieUpdateModel movieUpdateModel)
        {
            await GenreGetService.ValidateAsync(movieUpdateModel);
            
            return await MovieDataAccess.UpdateAsync(movieUpdateModel);
        }
        
        private IMovieDataAccess MovieDataAccess { get; }
        
        private IGenreGetService GenreGetService { get; }

        public MovieUpdateService(IMovieDataAccess movieDataAccess, IGenreGetService iGenreGetService)
        {
            MovieDataAccess = movieDataAccess;
            GenreGetService = iGenreGetService;
        }
    }
}