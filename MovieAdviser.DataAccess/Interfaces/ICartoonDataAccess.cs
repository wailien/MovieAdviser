using System.Collections.Generic;
using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Interfaces;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.DataAccess.Interfaces
{
    public interface ICartoonDataAccess
    {
        Task<Cartoon> InsertAsync(CartoonUpdateModel сartoonUpdateModel);
        
        Task<IEnumerable<Cartoon>> GetAsync();
        
        Task<Cartoon> GetAsync(ICartoonIdentity iCartoonIdentity);
        
        Task<Cartoon> UpdateAsync(CartoonUpdateModel сartoonUpdateModel);
        
        Task<Cartoon> GetByAsync(ICartoonContainer iCartoonContainer);
    }
}