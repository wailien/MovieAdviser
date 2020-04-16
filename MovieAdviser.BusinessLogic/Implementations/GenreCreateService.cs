using System.Threading.Tasks;
using MovieAdviser.BusinessLogic.Interfaces;
using MovieAdviser.DataAccess.Interfaces;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Implementations
{
    public class GenreCreateService : IGenreCreateService
    {
        public Task<Genre> CreateAsync(GenreUpdateModel genreUpdateModel)
        {
            return GenreDataAccess.InsertAsync(genreUpdateModel);
        }
        
        private IGenreDataAccess GenreDataAccess { get; }

        public GenreCreateService(IGenreDataAccess iGenreDataAccess)
        {
            GenreDataAccess = iGenreDataAccess;
        }
    }
}