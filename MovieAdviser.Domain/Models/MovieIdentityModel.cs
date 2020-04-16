using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class MovieIdentityModel : IMovieIdentity
    {
        public MovieIdentityModel(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}