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
    public class TheaterController : ControllerBase
    {
        private AppDbContext _context;
        IMapper _mapper;

        public TheaterController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddTheater([FromBody]CreateTheaterDto theaterDto)
        {
            var theater = _mapper.Map<Theater>(theaterDto);

            _context.Theaters.Add(theater);

            _context.SaveChanges();

            //show which endpoint returns the theater that was newly created
            return CreatedAtAction(nameof(GetTheaterById), new { Id = theater.Id }, theater);
        }

        [HttpGet]
        public IActionResult GetTheaters([FromQuery] string movieName = default)
        {
            if (!(_context.Theaters?.Any() ?? false))
                return NotFound();

            List<Theater> theaters = _context.Theaters.Where(x =>
                string.IsNullOrWhiteSpace(movieName)
                ||
                (
                    x.Sessions != null
                    && x.Sessions.Any(y => y.Movie != null && y.Movie.Title.ToLower().Contains(movieName.ToLower()))
                )).ToList();
            
            var dtos = _mapper.Map<IEnumerable<ReadTheaterDto>>(theaters);

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTheaterById(int id)
        {
            Theater theater = GetContextTheaterById(id);
            if (theater != null)
            {
                ReadTheaterDto readTheaterDto = _mapper.Map<ReadTheaterDto>(theater);

                return Ok(readTheaterDto);
            }

            return NotFound();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateTheater([FromBody] UpdateTheaterDto theaterDto, int id)
        {
            Theater theater = GetContextTheaterById(id);
            if (theater != null)
            {
                _mapper.Map(theaterDto, theater);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTheater(int id)
        {
            Theater theater = _context.Theaters.FirstOrDefault(x => x.Id == id);
            if (theater != null)
            {
                _context.Theaters.Remove(theater);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Theater GetContextTheaterById(int id)
        {
            return _context.Theaters.FirstOrDefault(x => x.Id == id);
        }
    }
}
