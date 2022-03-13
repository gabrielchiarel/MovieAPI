using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class ReadAdressDto
    {
        [Key, Required]
        public int Id { get; set; }
        public string PublicArea { get; set; }
        public string District { get; set; }
        public int Number { get; set; }

        public DateTime ReadTime { get; set; } 
    }
}
