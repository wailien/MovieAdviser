namespace MovieAdviser.Client.DataTransferObjects.Read
{
    public class MovieDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public string Director { get; set; }
        
        public int Rating { get; set; }
        
        public GenreDTO GenreDto { get; set; }
    }
}