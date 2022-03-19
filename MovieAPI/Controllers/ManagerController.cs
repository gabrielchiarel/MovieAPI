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
    public class ManagerController : ControllerBase
    {
        private AppDbContext _context;
        IMapper _mapper;

        public ManagerController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddManager([FromBody] CreateManagerDto ManagerDto)
        {
            Manager Manager = _mapper.Map<Manager>(ManagerDto);

            _context.Managers.Add(Manager);

            _context.SaveChanges();

            //show which endpoint returns the Manager that was newly created
            return CreatedAtAction(nameof(GetManagerById), new { Id = Manager.Id }, Manager);
        }

        [HttpGet]
        public IEnumerable<Manager> GetManagers()
        {
            return _context.Managers;
        }

        [HttpGet("{id}")]
        public IActionResult GetManagerById(int id)
        {
            Manager Manager = GetContextManagerById(id);
            if (Manager != null)
            {
                ReadManagerDto readManagerDto = _mapper.Map<ReadManagerDto>(Manager);

                return Ok(readManagerDto);
            }

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateManager([FromBody] UpdateManagerDto ManagerDto, int id)
        {
            Manager Manager = GetContextManagerById(id);
            if (Manager != null)
            {
                _mapper.Map(ManagerDto, Manager);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteManager(int id)
        {
            Manager Manager = _context.Managers.FirstOrDefault(x => x.Id == id);
            if (Manager != null)
            {
                _context.Managers.Remove(Manager);

                _context.SaveChanges();

                return NoContent();
            }

            return NotFound();
        }

        Manager GetContextManagerById(int id)
        {
            return _context.Managers.FirstOrDefault(x => x.Id == id);
        }
    }
}
