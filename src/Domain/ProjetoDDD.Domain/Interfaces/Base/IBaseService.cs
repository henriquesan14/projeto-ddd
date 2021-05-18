using FluentValidation;
using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoDDD.Domain.Interfaces.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        void Delete(int id);

        IList<TEntity> Get();

        TEntity GetById(int id);

        TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
    }
}
