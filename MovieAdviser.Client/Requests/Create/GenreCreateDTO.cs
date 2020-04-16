﻿using System.ComponentModel.DataAnnotations;

namespace MovieAdviser.Client.Requests
{
    public class GenreCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}