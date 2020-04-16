using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Interfaces
{
    public interface IGenreGetService
    {
        Task<IEnumerable<Genre>> GetAsync();
        
        Task<Genre> GetAsync(IGenreIdentity iGenreIdentity);
        
        Task ValidateAsync(IGenreContainer genreContainer);
    }
}