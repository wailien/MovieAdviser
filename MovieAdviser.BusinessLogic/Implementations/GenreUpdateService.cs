using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class GenreUpdateService : IGenreUpdateService
    {
        public Task<Genre> UpdateAsync(GenreUpdateModel genreUpdateModel)
        {
            return GenreDataAccess.UpdateAsync(genreUpdateModel);
        }
        
        private IGenreDataAccess GenreDataAccess { get; }

        public GenreUpdateService(IGenreDataAccess genreDataAccess)
        {
            GenreDataAccess = genreDataAccess;
        }
    }
}