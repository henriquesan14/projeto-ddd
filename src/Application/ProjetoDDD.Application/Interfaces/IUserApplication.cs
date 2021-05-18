using ProjetoDDD.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<UserDTO> Add(CreateUserDTO obj);

        Task Delete(int id);

        Task<IEnumerable<UserDTO>> Get();

        Task<UserDTO> GetById(int id);

        Task<UserDTO> Update(CreateUserDTO obj);
    }
}
