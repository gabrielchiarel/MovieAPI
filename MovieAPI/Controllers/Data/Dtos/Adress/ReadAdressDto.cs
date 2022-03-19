using MovieAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class ReadAddressDto
    {
        [Key, Required]
        public int Id { get; set; }
        public string PublicArea { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        [JsonIgnore]
        public virtual Theater Theater { get; set; }
    }
}
