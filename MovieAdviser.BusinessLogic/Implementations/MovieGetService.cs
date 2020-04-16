using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class MovieGetService : IMovieGetService
    {
        public Task<IEnumerable<Movie>> GetAsync()
        {
            return this.MovieDataAccess.GetAsync();
        }

        public Task<Movie> GetAsync(IMovieIdentity iMovieIdentity)
        {
            return this.MovieDataAccess.GetAsync(iMovieIdentity);
        }

        public async Task ValidateAsync(IMovieContainer movieContainer)
        {
            if (movieContainer == null)
            {
                throw new ArgumentNullException(nameof(movieContainer));
            }
            
            var movie = await this.GetBy(movieContainer);

            if (movieContainer.MovieId.HasValue && movie == null)
            {
                throw new InvalidOperationException($"Movie not found by id {movieContainer.MovieId}");
            }
        }
        
        private IMovieDataAccess MovieDataAccess { get; }
        
        public MovieGetService(IMovieDataAccess movieDataAccess)
        {
            this.MovieDataAccess = movieDataAccess;
        }
        
        private Task<Movie> GetBy(IMovieContainer movieContainer)
        {
            return this.MovieDataAccess.GetByAsync(movieContainer);
        }
    }
}