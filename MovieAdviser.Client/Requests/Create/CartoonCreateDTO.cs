using System.ComponentModel.DataAnnotations;

namespace MovieAdviser.Client.Requests
{
    public class CartoonCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
 
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        
        public int? GenreId { get; set; }
    }
}