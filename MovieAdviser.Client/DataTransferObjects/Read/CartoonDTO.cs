﻿namespace MovieAdviser.Client.DataTransferObjects.Read
{
    public class CartoonDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
 
        public int Year { get; set; }
        
        public GenreDTO GenreDto { get; set; }
    }
}