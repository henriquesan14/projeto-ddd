using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Insert(TEntity obj);

        Task Update(TEntity obj);

        Task Delete(int id);

        Task<IEnumerable<TEntity>> Select();

        Task<TEntity> Select(int id);
    }
}
