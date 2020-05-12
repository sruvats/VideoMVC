using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace video.Models
{
    public class Movie
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        [Required]
        public byte GenreId { get; set; }
        [Display(Name="Release Date")]      
        public DateTime? ReleaseDate { get; set; }
        public DateTime? DateAdded { get; set; }
        [Display(Name="Number in Stock")]
           [Required]
           [Range(1,20,ErrorMessage ="Enter a number between 1 and 20")]
        public int NumberInStock { get; set; }

    }
    public class MoviesList
    {
        public List<Movie> movieList = new List<Movie>();

    }

}