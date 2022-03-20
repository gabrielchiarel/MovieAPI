using MovieAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos.Session
{
    public class CreateSessionDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public int TheaterId { get; set; }
        public DateTime Shutdown { get; set; }
    }
}
