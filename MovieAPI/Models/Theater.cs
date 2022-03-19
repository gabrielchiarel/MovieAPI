using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Theater
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}
