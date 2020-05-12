using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace video.Models
{
    public class Rental
    {

        public int id { get; set; }
        [Required]
        public Customer customer { get; set; }
       
        [Required]

        public Movie movie { get; set; }
 
        public DateTime dateRented { get; set; }

        public DateTime? dateReturned { get; set; }


    }
}