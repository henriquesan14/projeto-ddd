using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces;
using ProjetoDDD.Infra.Data.Context;
using ProjetoDDD.Infra.Data.Repository.Base;

namespace ProjetoDDD.Infra.Data.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(SqlServerDbContext context) : base(context)
        {

        }
        
    }
}
