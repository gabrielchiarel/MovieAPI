using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            CreateMap<CreateTheaterDto, Theater>();
            CreateMap<UpdateTheaterDto, Theater>();
            CreateMap<Theater, ReadTheaterDto>();
        }
    }
}
