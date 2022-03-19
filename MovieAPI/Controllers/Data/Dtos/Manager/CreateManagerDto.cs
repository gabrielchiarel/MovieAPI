using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class CreateManagerDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}
