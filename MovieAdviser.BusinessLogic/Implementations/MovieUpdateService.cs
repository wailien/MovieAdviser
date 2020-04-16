using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class MovieUpdateService : IMovieUpdateService
    {
        public Task<Movie> UpdateAsync(MovieUpdateModel movieUpdateModel)
        {
            return MovieDataAccess.UpdateAsync(movieUpdateModel);
        }
        
        private IMovieDataAccess MovieDataAccess { get; }

        public MovieUpdateService(IMovieDataAccess movieDataAccess)
        {
            MovieDataAccess = movieDataAccess;
        }
    }
}