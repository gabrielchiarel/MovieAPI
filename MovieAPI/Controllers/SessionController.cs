using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Controllers.Data;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Controllers.Data.Dtos.Session;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        AppDbContext _context;
        IMapper _mapper;
        public SessionController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto sessionDto)
        {
            Session session = _mapper.Map<Session>(sessionDto);
            
            _context.Sessions.Add(session);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSessionById), new { Id = session.Id }, session); ;
        }

        [HttpGet]
        public IEnumerable<Session> GetSessions()
        {
            return _context.Sessions;
        }

        [HttpGet("{id}")]
        public IActionResult GetSessionById(int id)
        {
            Session session = GetContextSessionById(id);
            if (session != null)
            {
                ReadSessionDto readSessionDto = _mapper.Map<ReadSessionDto>(session);

                return Ok(readSessionDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession([FromBody] UpdateSessionDto sessionDto, int id)
        {
            Session session = GetContextSessionById(id);
            if (session != null)
            {
                _mapper.Map(sessionDto, session);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(x => x.Id == id);
            if (session != null)
            {
                _context.Sessions.Remove(session);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Session GetContextSessionById(int id)
        {
            return _context.Sessions.FirstOrDefault(x => x.Id == id);
        }
    }
}
