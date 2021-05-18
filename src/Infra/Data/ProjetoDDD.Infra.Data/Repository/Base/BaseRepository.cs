using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Base;
using ProjetoDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoDDD.Infra.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerDbContext _sqlServerContext;

        public BaseRepository(SqlServerDbContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Insert(TEntity obj)
        {
            _sqlServerContext.Set<TEntity>().Add(obj);
            _sqlServerContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlServerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _sqlServerContext.Set<TEntity>().Remove(Select(id));
            _sqlServerContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _sqlServerContext.Set<TEntity>().ToList();

        public TEntity Select(int id) =>
            _sqlServerContext.Set<TEntity>().Find(id);

    }
}
