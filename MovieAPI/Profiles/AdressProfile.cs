using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class AdressProfile : Profile
    {
        public AdressProfile()
        {
            CreateMap<CreateAdressDto, Adress>();
            CreateMap<UpdateAdressDto, Adress>();
            CreateMap<Adress, ReadAdressDto>();
        }
    }
}
