using FluentValidation;
using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Domain.Interfaces.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        Task Delete(int id);

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> GetById(int id);

        Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
