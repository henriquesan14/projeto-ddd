using FluentValidation;
using ProjetoDDD.Application.DTOs;
using ProjetoDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDDD.Application.Interfaces.Base
{
    public interface IBaseApplication<TEntity, TEntityDTO, TValidator> 
        where TEntity: BaseEntity 
        where TEntityDTO : BaseDTO
        where TValidator : AbstractValidator<TEntity>
    {
        Task<TEntityDTO> Add(TEntityDTO obj);

        Task Delete(int id);

        Task<IEnumerable<TEntityDTO>> Get();

        Task<TEntityDTO> GetById(int id);

        Task<TEntityDTO> Update(TEntityDTO obj);
    }
}
