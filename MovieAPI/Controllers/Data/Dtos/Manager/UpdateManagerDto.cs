using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class UpdateManagerDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Name { get; set; }

    }
}
