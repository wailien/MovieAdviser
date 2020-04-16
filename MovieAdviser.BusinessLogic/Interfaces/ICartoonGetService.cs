using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.BusinessLogic.Interfaces
{
    public interface ICartoonGetService
    {
        Task<IEnumerable<Cartoon>> GetAsync();
        
        Task<Cartoon> GetAsync(ICartoonIdentity iCartoonIdentity);
        
        Task ValidateAsync(ICartoonContainer cartoonContainer);
    }
}