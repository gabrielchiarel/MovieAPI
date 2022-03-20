using MovieAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos.Session
{
    public class UpdateSessionDto
    {
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public int TheaterId { get; set; }
        public virtual Theater Theater { get; set; }
        public DateTime Shutdown { get; set; }
    }
}
