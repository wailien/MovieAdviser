using System.ComponentModel.DataAnnotations;

namespace MovieAdviser.Client.Requests
{
    public class MovieCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Year is required")]
        public int Year { get; set; }
        
        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }
        
        [Required(ErrorMessage = "Rating is required")]
        public int Rating { get; set; }
        
        public int? GenreId { get; set; }
    }
}