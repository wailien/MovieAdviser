using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class MovieCreateService : IMovieCreateService
    {
        public Task<Movie> CreateAsync(MovieUpdateModel movieUpdateModel)
        {
            return MovieDataAccess.InsertAsync(movieUpdateModel);
        }
        
        private IMovieDataAccess MovieDataAccess { get; }

        public MovieCreateService(IMovieDataAccess iMovieDataAccess)
        {
            MovieDataAccess = iMovieDataAccess;
        }
    }
}