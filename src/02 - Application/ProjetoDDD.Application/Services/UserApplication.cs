using AutoMapper;
using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Application.Services.Base;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces;
using ProjetoDDD.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Application.Services
{
    public class UserApplication : BaseApplication<User, UserDTO, UserValidator>, IUserApplication
    {
        public UserApplication(IUserService userService, IMapper mapper) : base (userService, mapper)
        {
        }

    }
}
