using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class Movie
    {
        [Key, Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director is required")]
        public string Director { get; set; }

        [Required(), StringLength(30, ErrorMessage = "MaxLength 30")]
        public string Gender { get; set; }

        [Range(1, 600, ErrorMessage = "Range 1 to 600")]
        public int Duration { get; set; }
        public int AgeRating { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }

    }
}
