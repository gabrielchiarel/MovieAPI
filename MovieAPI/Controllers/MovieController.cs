using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Controllers.Data;
using MovieAPI.Controllers.Data.Dtos;
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
        private AppDbContext _context;
        IMapper _mapper;

        public MovieController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody]CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);

            _context.SaveChanges();

            //show which endpoint returns the movie that was newly created
            return CreatedAtAction(nameof(GetMovieById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetMovies([FromQuery] int? ageRating = default)
        {
            var movies = _context.Movies.Where(x =>
                ageRating == null || x.AgeRating <= ageRating
            );

            if (movies?.Any() ?? false)
            {
                var readDto = _mapper.Map<IEnumerable<ReadMovieDto>>(movies);

                return Ok(readDto);
            }
            
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            Movie movie = GetContextMovieById(id);
            if (movie != null)
            {
                ReadMovieDto readMovieDto = _mapper.Map<ReadMovieDto>(movie);

                return Ok(readMovieDto);
            }

            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateMovie([FromBody] UpdateMovieDto movieDto, int id)
        {
            Movie movie = GetContextMovieById(id);
            if (movie != null)
            {
                _mapper.Map(movieDto, movie);

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
