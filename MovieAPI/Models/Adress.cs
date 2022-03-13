using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Adress
    {
        [Key, Required]
        public int Id { get; set; }
        public string PublicArea { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
        public Theater Theater { get; set; }
    }
}
