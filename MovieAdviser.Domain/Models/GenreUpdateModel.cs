using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class GenreUpdateModel : IGenreIdentity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { set; get; }
    }
}