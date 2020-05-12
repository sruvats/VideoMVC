using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using video.Models;

namespace video.Controllers.api
{
    public class MoviesController : ApiController
    {
        videocontext _context;
        public MoviesController()
        {
            _context = new videocontext();
        }

        //get--//api/Customers
        [HttpGet, HttpHead]
        public IEnumerable<Movie> GetCustomer(string query = null)
        {
            var movieQuery = _context.Movies.ToList();

            if(!string.IsNullOrWhiteSpace(query))
            {
                movieQuery = movieQuery.Where(m => m.Name.ToUpper().Contains(query.ToUpper())).ToList();
            }

            return movieQuery;

        }
    }
}
