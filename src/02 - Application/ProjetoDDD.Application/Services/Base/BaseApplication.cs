using AutoMapper;
using FluentValidation;
using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Application.Interfaces.Base;
using ProjetoDDD.Domain.Entities;
using ProjetoDDD.Domain.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoDDD.Application.Services.Base
{
    public class BaseApplication<TEntity, TEntityDTO, TValidator> : IBaseApplication<TEntity, TEntityDTO, TValidator>
        where TEntity : BaseEntity
        where TEntityDTO : BaseDTO
        where TValidator : AbstractValidator<TEntity>
    {

        protected readonly IBaseService<TEntity> _service;
        protected readonly IMapper _mapper;

        public BaseApplication(IBaseService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<TEntityDTO> Add(TEntityDTO obj)
        {
            TEntity entity = _mapper.Map<TEntity>(obj);
            TEntity entityCreated = await _service.Add<TValidator>(entity);
            return _mapper.Map<TEntityDTO>(entityCreated);
        }

        public async Task Delete(int id)
        {
            await _service.Delete(id);
        }

        public async Task<IEnumerable<TEntityDTO>> Get()
        {
            var list = await _service.Get();
            return _mapper.Map<List<TEntityDTO>>(list);
        }

        public async Task<TEntityDTO> GetById(int id)
        {
            var obj = await _service.GetById(id);
            return _mapper.Map<TEntityDTO>(obj);
        }

        public async Task<TEntityDTO> Update(TEntityDTO obj)
        {
            var entity = await _service.GetById(obj.Id);
            var entityMapped = _mapper.Map(obj, entity);
            var entityUpdated = await _service.Update<TValidator>(entityMapped);
            return _mapper.Map<TEntityDTO>(entityUpdated);
        }
    }
}
