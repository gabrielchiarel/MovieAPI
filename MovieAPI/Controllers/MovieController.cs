using Microsoft.AspNetCore.Mvc;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private static List<Movie> Movies = new();
        private static int Id = 1;

        [HttpPost]
        public void AddMovie([FromBody]Movie movie)
        {
            movie.Id = Id++;
            
            Movies.Add(movie);

            Console.WriteLine(movie.Title);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        [HttpGet]
        public Movie GetMovieById(int id)
        {
            if (Movies.Any(x => x.Id == id))
                return Movies.FirstOrDefault(x => x.Id == id);
            else
                return null;
        }
    }
}
