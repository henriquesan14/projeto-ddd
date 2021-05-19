using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces;
using ProjetoDDD.Service.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDD.Service.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository repository): base(repository)
        {

        }
    }
}
