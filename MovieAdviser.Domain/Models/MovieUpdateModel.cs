using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class MovieUpdateModel : IMovieIdentity, IGenreContainer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public string Director { get; set; }
        
        public int Rating { get; set; }
        
        public int? GenreId { get; set; }
    }
}