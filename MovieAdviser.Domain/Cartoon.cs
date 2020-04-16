using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain
{
    public class Cartoon : IGenreContainer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public Genre Genre { get; set; }

        public int? GenreId => Genre.Id;
    }
}