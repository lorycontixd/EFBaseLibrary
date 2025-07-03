using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Application.Interfaces;
using BaseLibrary.Core.Entities.Base;

namespace BaseLibrary.Application.Services
{
    public abstract class BaseService<TEntity, TDto>(IBaseRepository<TEntity, TDto> repo) : IBaseService<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        public readonly IBaseRepository<TEntity, TDto> _repo = repo;

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public virtual async Task<TDto?> GetByIdAsync(params object[] keyValues)
        {
            return await _repo.GetByIdAsync(keyValues);
        }
        public virtual async Task AddAsync(TDto entity)
        {
            await _repo.CreateAsync(entity);
        }
        public virtual async Task UpdateAsync(TDto entity)
        {
            await _repo.UpdateAsync(entity);
        }
        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            await _repo.DeleteAsync(keyValues);
        }
    }
}
