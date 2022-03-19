 using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;
using System.Linq;

namespace MovieAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<UpdateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(manager => manager.Theaters,
                    x => x.MapFrom(manager => manager.Theaters.Select(x =>
                        new { x.Id, x.Name, x.AddressId, x.Address })
                    ));
        }
    }
}
