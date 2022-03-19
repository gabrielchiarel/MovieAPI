using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Controllers.Data.Dtos
{
    public class CreateAddressDto
    {
        public string PublicArea { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
    }
}
