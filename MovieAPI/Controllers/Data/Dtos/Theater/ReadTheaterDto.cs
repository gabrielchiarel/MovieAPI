using MovieAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class ReadTheaterDto
    {
        [Key, Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
        public Address Address { get; set; }
    }
}
