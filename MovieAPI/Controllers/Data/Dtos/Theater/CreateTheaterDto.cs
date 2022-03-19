using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class CreateTheaterDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
