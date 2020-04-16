using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain
{
    public class Movie : IGenreContainer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public string Director { get; set; }
        
        public int Rating { get; set; }
        
        public Genre Genre { get; set; }

        public int? GenreId => Genre.Id;
    }
}