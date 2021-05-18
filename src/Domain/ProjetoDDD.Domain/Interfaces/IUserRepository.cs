using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDD.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
