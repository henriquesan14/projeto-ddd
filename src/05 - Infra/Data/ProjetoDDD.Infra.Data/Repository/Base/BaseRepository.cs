using Microsoft.EntityFrameworkCore;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Base;
using ProjetoDDD.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoDDD.Infra.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerDbContext _sqlServerContext;

        public BaseRepository(SqlServerDbContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public async Task<TEntity> Insert(TEntity obj)
        {
            _sqlServerContext.Set<TEntity>().Add(obj);
            await _sqlServerContext.SaveChangesAsync();
            return obj;
        }

        public async Task Update(TEntity obj)
        {
            _sqlServerContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _sqlServerContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await Select(id);
            _sqlServerContext.Set<TEntity>().Remove(entity);
            await _sqlServerContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Select() =>
            await _sqlServerContext.Set<TEntity>().ToListAsync();

        public async Task<TEntity> Select(int id) =>
            await _sqlServerContext.Set<TEntity>().FindAsync(id);

    }
}
