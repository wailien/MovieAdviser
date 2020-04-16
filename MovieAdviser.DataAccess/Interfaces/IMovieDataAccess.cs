using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.DataAccess.Interfaces
{
    public interface IMovieDataAccess
    {
        Task<Movie> InsertAsync(MovieUpdateModel movieUpdateModel);
        
        Task<IEnumerable<Movie>> GetAsync();
        
        Task<Movie> GetAsync(IMovieIdentity iMovieIdentity);
        
        Task<Movie> UpdateAsync(MovieUpdateModel movieUpdateModel);
        
        Task<Movie> GetByAsync(IMovieContainer iMovieContainer);
    }
}