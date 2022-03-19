using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Models
{
    public class Manager
    {
        [Key, Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [JsonIgnore]
        public virtual List<Theater> Theaters { get; set; }
    }
}
