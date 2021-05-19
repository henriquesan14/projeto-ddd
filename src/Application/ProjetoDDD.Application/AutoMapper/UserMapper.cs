using AutoMapper;
using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Application.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
