using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class GenreIdentityModel : IGenreIdentity
    {
        public GenreIdentityModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}