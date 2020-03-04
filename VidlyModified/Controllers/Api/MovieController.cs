using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VidlyModified.Models;
using AutoMapper;
using VidlyModified.Dtos;


namespace VidlyModified.Controllers.Api
{
    public class MovieController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovie()
        {
            var movies = _context.Movie.Include(c => c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
            return Ok(movies);
        }

        public IHttpActionResult GetMovie(int id)
        {

            var movie = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                //  throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok( Mapper.Map<Customer, CustomerDto>(movie));

        }


        [HttpDelete]
        public IHttpActionResult DeleteMovies(int id)
        {
            var movieInDb = _context.Movie.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                return NotFound();
            _context.Movie.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();

        }
    }
}
