using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using VidlyModified.Models;
using VidlyModified.ViewModel;

namespace VidlyModified.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {

            // var movie = GetMovie();
            //when we use client side no need to pass the object throw the function
            // var movie = _context.Movie.Include(c => c.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            return View("List");

            return View("ReadOnly");
        }

        public ActionResult detail(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }
        [Authorize (Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genre = genre
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {

                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {


                    Genre = _context.Genre.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
                _context.Movie.Add(movie);

            else
            {
                var MovieInDb = _context.Movie.Single(c => c.Id == movie.Id);

                MovieInDb.Name = movie.Name;
                MovieInDb.NumberInStock = movie.NumberInStock;
                MovieInDb.ReleaseDate = movie.ReleaseDate;
                MovieInDb.GenreId = movie.GenreId;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
        //private IEnumerable<Movie> GetMovie()
        //{

        //    return new List<Movie>
        //    {
        //new Movie { Id=1,Name="Shark" },
        //new Movie {Id=2,Name="Final" }

        //    };
        //}
    }
}