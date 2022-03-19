using AutoMapper;
using MovieAPI.Controllers.Data.Dtos;
using MovieAPI.Models;

namespace MovieAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<UpdateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto>();
        }
    }
}
