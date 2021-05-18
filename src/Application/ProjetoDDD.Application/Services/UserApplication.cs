using AutoMapper;
using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Application.Interfaces;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces;
using ProjetoDDD.Service.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserApplication(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public async Task<UserDTO> Add(CreateUserDTO obj)
        {
            User user = _mapper.Map<User>(obj);
            User userCreated = await _userService.Add<UserValidator>(user);
            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task Delete(int id)
        {
            await _userService.Delete(id);
        }

        public async Task <IEnumerable<UserDTO>> Get()
        {
            var list = await _userService.Get();
            return _mapper.Map<List<UserDTO>>(list);
        }

        public async Task<UserDTO> GetById(int id)
        {
            var obj = await _userService.GetById(id);
            return _mapper.Map<UserDTO>(obj);
        }

        public async Task<UserDTO> Update(CreateUserDTO obj)
        {
            var user = await _userService.GetById(obj.Id);
            var userMap = _mapper.Map(obj, user);
            var userUpdated = await _userService.Update<UserValidator>(userMap);
            return _mapper.Map<UserDTO>(userUpdated);
        }
    }
}
