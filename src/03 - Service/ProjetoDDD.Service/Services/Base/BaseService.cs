using FluentValidation;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Service.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<TEntity> Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Insert(obj);
            return obj;
        }

        public async Task Delete(int id) => await _baseRepository.Delete(id);

        public async Task<IEnumerable<TEntity>> Get() => await _baseRepository.Select();

        public async Task<TEntity> GetById(int id) => await _baseRepository.Select(id);

        public async Task<TEntity> Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            await _baseRepository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
