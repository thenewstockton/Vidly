using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data.Entity;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;
using AutoMapper;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        [HttpGet]
        //public IEnumerable<MovieDto> GetMovies()
        public IEnumerable<MovieDto> GetMovies()
        {
            //List<Movie> movies = _context.Movies.ToList();
            //List<MovieDto> movieDtos = new List<MovieDto>();
            //for (int i = 0; i < movies.Count; i++)
            //{
            //    MovieDto movieDto = new MovieDto();

            //    movieDto.GenreId = movies[i].GenreId;
            //    movieDto.Id = movies[i].Id;
            //    movieDto.Name = movies[i].Name;
            //    movieDto.NumberInStock = movies[i].NumberInStock;
            //    movieDto.ReleaseDate = movies[i].ReleaseDate;
                
            //    movieDtos.Add(movieDto);
            //}

            //return movieDtos;
            return _context.Movies.Include(m => m.Genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
        }

        //GET /api/movies/1
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

 /*       test Data: 
{
    "Id": 0,
    "Name": "Test1",
    "NumberInStock": 11,
    "GenreId": 2,
    "ReleaseDate": "1981-01-01"
}
        */
        //POST /api/customers
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public MovieDto CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Movie movie = new Movie();
            //movie.Id = movieDto.Id;
            //movie.Name = movieDto.Name;
            //movie.NumberInStock = movieDto.NumberInStock;
            //movie.GenreId = movieDto.GenreId;
            //movie.ReleaseDate = movieDto.ReleaseDate;
            movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return movieDto;
        }

        //PUT /api/Movies/13
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            //movieInDb.Name = movieDto.Name;
            //movieInDb.NumberInStock = movieDto.NumberInStock;
            //movieInDb.GenreId = movieDto.GenreId;
            //movieInDb.ReleaseDate = movieDto.ReleaseDate;
            Mapper.Map<MovieDto, Movie>(movieDto, movieInDb);
            movieInDb.DateAdded = DateTime.Now;

            _context.SaveChanges();
        }

        //DELETE /api/Movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
