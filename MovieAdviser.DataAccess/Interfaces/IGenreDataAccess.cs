using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.DataAccess.Interfaces
{
    public interface IGenreDataAccess
    {
        Task<Genre> InsertAsync(GenreUpdateModel genreUpdateModel);
        
        Task<IEnumerable<Genre>> GetAsync();
        
        Task<Genre> GetAsync(IGenreIdentity iGenreIdentity);
        
        Task<Genre> UpdateAsync(GenreUpdateModel genreUpdateModel);
        
        Task<Genre> GetByAsync(IGenreContainer iGenreContainer);
    }
}