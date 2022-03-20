using MovieAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos.Session
{
    public class ReadSessionDto
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        [Required]
        public int TheaterId { get; set; }
        public Theater Theater { get; set; }
        public DateTime Shutdown { get; set; }
        public DateTime Start { get; set; }
    }
}
