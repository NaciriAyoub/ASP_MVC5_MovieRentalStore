using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentalStore.Models;
using MovieRentalStore.ViewModels;
using System.Data.Entity;

namespace MovieRentalStore.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();
            //return View(movies);
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");
        }


        [Route("Movies/Details/{id}")]
        public ActionResult GetMovieDetails(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                return View(movie);
            }
            else
            {
                return HttpNotFound();
            }

        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var movieViewModel = new MovieViewModel()
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", movieViewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var movieViewModel = new MovieViewModel()
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie
                };
                return View("MovieForm", movieViewModel);
            }


            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                //TryUpdateModel(customerInDb);  //Bad to use
                //Maper.Map(customer,customerInDb);  //autoMapper
                movieInDb.Name = movie.Name;
                movieInDb.RealeaseDate = movie.RealeaseDate;
                //movieInDb.AddedDate = DateTime.Now;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }


        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                var viewModel = new MovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}