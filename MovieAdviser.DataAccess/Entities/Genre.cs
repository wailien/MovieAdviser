using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieAdviser.DataAccess.Entities
{
    public class Genre
    {
        public Genre()
        {
            this.Movie = new HashSet<Movie>();
            this.Cartoon = new HashSet<Cartoon>();
        }
        
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual ICollection<Movie> Movie { get; set; }
        
        public virtual ICollection<Cartoon> Cartoon { get; set; }
        
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
    }
}