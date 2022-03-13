using Microsoft.AspNetCore.Mvc;
using MovieAPI.Controllers.Data;
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
        private MovieContext _context;

        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]Movie movie)
        {
            _context.Movies.Add(movie);

            _context.SaveChanges();

            //show which endpoint returns the movie that was newly created
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = GetContextMovieById(id);
            if (movie != null)
                return Ok(movie);

            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] Movie newMovie, int id)
        {
            Movie movie = GetContextMovieById(id);
            if (movie != null)
            {
                movie.Title = newMovie.Title;
                movie.Director = newMovie.Director;
                movie.Duration = newMovie.Duration;
                movie.Gender = newMovie.Gender;

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Movie GetContextMovieById(int id)
        {
            return _context.Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
