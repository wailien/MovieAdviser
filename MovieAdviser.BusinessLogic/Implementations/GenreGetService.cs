using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class GenreGetService : IGenreGetService
    {
        public Task<IEnumerable<Genre>> GetAsync()
        {
            return this.GenreDataAccess.GetAsync();
        }

        public Task<Genre> GetAsync(IGenreIdentity iGenreIdentity)
        {
            return this.GenreDataAccess.GetAsync(iGenreIdentity);
        }

        public async Task ValidateAsync(IGenreContainer genreContainer)
        {
            if (genreContainer == null)
            {
                throw new ArgumentNullException(nameof(genreContainer));
            }
            
            var genre = await this.GetBy(genreContainer);

            if (genreContainer.GenreId.HasValue && genre == null)
            {
                throw new InvalidOperationException($"Genre not found by id {genreContainer.GenreId}");
            }
        }
        
        private IGenreDataAccess GenreDataAccess { get; }
        
        public GenreGetService(IGenreDataAccess genreDataAccess)
        {
            this.GenreDataAccess = genreDataAccess;
        }
        
        private Task<Genre> GetBy(IGenreContainer genreContainer)
        {
            return this.GenreDataAccess.GetByAsync(genreContainer);
        }
    }
}