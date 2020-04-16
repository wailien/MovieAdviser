using MovieAdviser.Domain.Interfaces;

namespace MovieAdviser.Domain.Models
{
    public class CartoonUpdateModel : ICartoonIdentity, IGenreContainer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        public int? GenreId { get; set; }
    }
}