using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAdviser.DataAccess.Entities
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public string Director { get; set; }
        
        public int Rating { get; set; }
        
        public virtual Genre Genre { get; set; }

        public int? GenreId { get; set; }
    }
}