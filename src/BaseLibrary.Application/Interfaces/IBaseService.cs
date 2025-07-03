using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Core.Entities.Base;

namespace BaseLibrary.Application.Interfaces
{
    public interface IBaseService<TEntity, TDto> where TEntity : class, IEntity where TDto: class, IDto
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(params object[] keyValues);
        Task AddAsync(TDto entity);
        Task UpdateAsync(TDto entity);
        Task DeleteAsync(params object[] keyValues);
    }
}
