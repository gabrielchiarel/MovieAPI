using AutoMapper;
using MovieAPI.Controllers.Data.Dtos.Session;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class SessionProfile : Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<UpdateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.Start,
                    x => x.MapFrom(dto => dto.Shutdown.AddMinutes(dto.Movie.Duration * (-1))));
        }
    }
}
