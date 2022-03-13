using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<CreateAdressDto, Theater>();
            CreateMap<UpdateAdressDto, Theater>();
            CreateMap<Theater, ReadTheaterDto>();
        }
    }
}
