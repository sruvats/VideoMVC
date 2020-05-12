using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using video.Models;

namespace video.ViewModels
{
    public class MovieViewModel
    {
    
            public IEnumerable<Genre> GenreList { get; set; }
            public Movie Movie { get; set; }
        
    }
}