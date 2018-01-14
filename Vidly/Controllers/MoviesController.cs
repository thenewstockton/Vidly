using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> _movies = new List<Movie>{
            new Movie{ Name = "Shrek", Id = 1},
            new Movie{ Name = "Wall-e", Id = 2}
        };

        public ActionResult Index()
        {
            MoviesViewModel viewModel = new MoviesViewModel{
                Movies = _movies
            };
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

        public ActionResult Edit(int id)
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