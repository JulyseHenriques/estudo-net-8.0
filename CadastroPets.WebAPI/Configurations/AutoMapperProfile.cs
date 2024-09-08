using AutoMapper;
using CadastroPets.Application.DTOs;
using CadastroPets.Domain.Entities;

namespace CadastroPets.WebAPI.Configurations
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
