using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using video.Models;
using video.ViewModels;

namespace video.Controllers
{
    public class MoviesController : Controller
    {
        videocontext _context = new videocontext();
        // GET: Movies   
        public ActionResult Random()
        {


            var ml = _context.Movies.Include("Genre").ToList();
            return View(ml);

        }
        public ActionResult Details(int? id)
        {


            var ml = _context.Movies.SingleOrDefault(m=>m.id==id);
            return View(ml);

        }
        public ActionResult Edit(Movie Movie)
        {
            videocontext _context = new videocontext();
            var MovieData = _context.Movies.Single(m=>m.id== Movie.id);
            if (MovieData == null)
            {
                return HttpNotFound();
            }
            else
            {
                MovieViewModel mvm = new MovieViewModel()
                {
                    Movie = MovieData,
                    GenreList = _context.Genre.ToList()

                };
                return View("movieinfo", mvm);

            }
        }
          [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Movie Movie)
          {
            videocontext _context = new videocontext();
            if (Movie.id == 0)
            {
                Movie.DateAdded = DateTime.Now;

                _context.Movies.Add(Movie);
            }
            else
            {
                var MovieinDb = _context.Movies.Single(m=>m.id==Movie.id);
                
              
                Movie.Name = MovieinDb.Name;
                Movie.NumberInStock = MovieinDb.NumberInStock;
                Movie.ReleaseDate = MovieinDb.ReleaseDate;
                Movie.GenreId = MovieinDb.GenreId;
                Movie.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Random","Movies");
        }
        public ActionResult movieInfo()
        {
            MovieViewModel mvm = new MovieViewModel()
            {
                Movie = new Movie(),
                GenreList = _context.Genre.ToList()

            };
            return View(mvm);
        }
        //public IEnumerable<Movie> GetMovies()
        //{
        // return  new List<Movie>
        //    {
        //        new Movie { Name = "Shrek!", id = 1 },
        //        new Movie { Name = "Cars!", id = 2 }
        //    };

        //}
        }





    }


