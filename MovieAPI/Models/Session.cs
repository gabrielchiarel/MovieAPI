using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Session
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required]
        public int TheaterId { get; set; } 
        public virtual Theater Theater { get; set; }
        public DateTime Shutdown { get; set; }
    }
}
