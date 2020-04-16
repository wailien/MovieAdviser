using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Interfaces
{
    public interface IMovieGetService
    {
        Task<IEnumerable<Movie>> GetAsync();
        
        Task<Movie> GetAsync(IMovieIdentity iMovieIdentity);
        
        Task ValidateAsync(IMovieContainer movieContainer);
    }
}