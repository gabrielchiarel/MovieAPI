using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();
            CreateMap<UpdateMovieDto, Movie>();
            CreateMap<Movie, ReadMovieDto>();
        }
    }
}
