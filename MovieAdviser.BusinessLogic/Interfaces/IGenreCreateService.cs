using System.Threading.Tasks;
using MovieAdviser.Domain;
using MovieAdviser.Domain.Models;

namespace MovieAdviser.BusinessLogic.Interfaces
{
    public interface IGenreCreateService
    {
        Task<Genre> CreateAsync(GenreUpdateModel genreUpdateModel);
    }
}

