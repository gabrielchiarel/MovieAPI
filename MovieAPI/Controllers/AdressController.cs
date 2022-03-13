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
    public class AdressController : ControllerBase
    {
        private AppDbContext _context;
        IMapper _mapper;

        public AdressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAdress([FromBody] CreateAdressDto AdressDto)
        {
            Adress Adress = _mapper.Map<Adress>(AdressDto);

            _context.Adresses.Add(Adress);

            _context.SaveChanges();

            //show which endpoint returns the Adress that was newly created
            return CreatedAtAction(nameof(GetAdressById), new { Id = Adress.Id }, Adress);
        }

        [HttpGet]
        public IEnumerable<Adress> GetAdresss()
        {
            return _context.Adresses;
        }

        [HttpGet("{id}")]
        public IActionResult GetAdressById(int id)
        {
            Adress Adress = GetContextAdressById(id);
            if (Adress != null)
            {
                ReadAdressDto readAdressDto = _mapper.Map<ReadAdressDto>(Adress);

                return Ok(readAdressDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdress([FromBody] UpdateAdressDto AdressDto, int id)
        {
            Adress Adress = GetContextAdressById(id);
            if (Adress != null)
            {
                _mapper.Map(AdressDto, Adress);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAdress(int id)
        {
            Adress Adress = _context.Adresses.FirstOrDefault(x => x.Id == id);
            if (Adress != null)
            {
                _context.Adresses.Remove(Adress);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Adress GetContextAdressById(int id)
        {
            return _context.Adresses.FirstOrDefault(x => x.Id == id);
        }
    }
}
