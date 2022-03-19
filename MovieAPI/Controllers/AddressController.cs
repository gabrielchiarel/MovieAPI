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
    public class AddressController : ControllerBase
    {
        private AppDbContext _context;
        IMapper _mapper;

        public AddressController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddAddress([FromBody] CreateAddressDto AddressDto)
        {
            Address Address = _mapper.Map<Address>(AddressDto);

            _context.Addresses.Add(Address);

            _context.SaveChanges();

            //show which endpoint returns the Address that was newly created
            return CreatedAtAction(nameof(GetAddressById), new { Id = Address.Id }, Address);
        }

        [HttpGet]
        public IEnumerable<Address> GetAddresss()
        {
            return _context.Addresses;
        }

        [HttpGet("{id}")]
        public IActionResult GetAddressById(int id)
        {
            Address Address = GetContextAddressById(id);
            if (Address != null)
            {
                ReadAddressDto readAddressDto = _mapper.Map<ReadAddressDto>(Address);

                return Ok(readAddressDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAddress([FromBody] UpdateAddressDto AddressDto, int id)
        {
            Address Address = GetContextAddressById(id);
            if (Address != null)
            {
                _mapper.Map(AddressDto, Address);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAddress(int id)
        {
            Address Address = _context.Addresses.FirstOrDefault(x => x.Id == id);
            if (Address != null)
            {
                _context.Addresses.Remove(Address);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Address GetContextAddressById(int id)
        {
            return _context.Addresses.FirstOrDefault(x => x.Id == id);
        }
    }
}
