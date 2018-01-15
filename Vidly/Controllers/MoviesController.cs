using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        private List<Movie> _movies = new List<Movie>{
            new Movie{ Name = "Hangover", Id = 1, 
                Genre = new Genre(){Name="Comedy"}, ReleaseDate = new DateTime(2009,11, 6), DateAdded = new DateTime(2016,5,4), NumberInStock = 5
            },
            new Movie{ Name = "Die Hard", Id = 2, 
                Genre = new Genre(){Name="Action"}, ReleaseDate = new DateTime(1988,7, 12), DateAdded = new DateTime(2015,11,22), NumberInStock = 11
            },
            new Movie{ Name = "The Terminator", Id = 3, 
                Genre = new Genre(){Name="Action"}, ReleaseDate = new DateTime(1985,3, 29), DateAdded = new DateTime(2014,4,8), NumberInStock = 0
            },
            new Movie{ Name = "Toy Story", Id = 4, 
                Genre = new Genre(){Name="Family"}, ReleaseDate = new DateTime(1995,11, 19), DateAdded = new DateTime(2013,1,5), NumberInStock = 55
            },
            new Movie{ Name = "Titanic", Id = 5, 
                Genre = new Genre(){Name="Romance"}, ReleaseDate = new DateTime(1997,12, 20), DateAdded = new DateTime(2012,12,12), NumberInStock = 100
            }
        };

        public ActionResult Index()
        {
            MoviesViewModel viewModel = new MoviesViewModel{
                Movies = GetMovies()
            };
            return View(viewModel);
        }

        private List<Movie> GetMovies()
        {
            //return _movies;
            return _context.Movies.Include(x => x.Genre).ToList();
        }

        public ActionResult New()
        {
            return View("MovieForm", new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            });
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var viewModel = GetMovies().Where(x => x.Id == id).FirstOrDefault();
            if (viewModel == null) return HttpNotFound();
            return View(viewModel);
        }

        // GET: Movies
        public ActionResult Random1()
        {
            var movie = new Movie() { Name = "Shrek!" };
            //return View(movie);
            //return Content("Hello");
            //return HttpNotFound();
            //return new EmptyResult();
            return RedirectToAction("Index", "Home", new { page = 1, sorBy = "name" });
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>{
                new Customer {Name = "Customer1"},
                new Customer {Name = "Customer2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

        public ActionResult Edit1(int id)
        {
            return Content("id=" + id);
        }

        //http://localhost:50029/movies?pageIndex=2&sortBy=ReleaseDate
        public ActionResult Index1(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }

            if (string.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }

            return Content(string.Format("pageIndex={0} sortBy={1}", pageIndex, sortBy));
        }

        //For this: go to routeConfig and set routes.MapMvcAttributeRoutes
        [Route("movies/releasedAtt/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDateAtt(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult ViewDataExample()
        {
            var movie = new Movie() { Name = "ViewDataExample!" };
            ViewData["Movie"] = movie;

            return View();
        }

        public ActionResult ViewBagExample()
        {
            var movie = new Movie() { Name = "ViewBagExample!" };
            ViewBag.RandomMovie = movie;

            return View();
        }
    }
}