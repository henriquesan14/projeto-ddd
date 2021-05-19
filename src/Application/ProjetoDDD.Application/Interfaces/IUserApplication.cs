using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Application.Interfaces.Base;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Service.Validators;

namespace ProjetoDDD.Application.Interfaces
{
    public interface IUserApplication : IBaseApplication<User, UserDTO, UserValidator>
    {
    }
}
