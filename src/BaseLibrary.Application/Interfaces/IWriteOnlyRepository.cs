using BaseLibrary.Application.DTOs.Base;
using BaseLibrary.Core.Entities.Base;

namespace BaseLibrary.Application.Interfaces
{
    /// <summary>
    /// Base interface for write-only repositories, which provides methods to add, update, and delete entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity handled by the repository</typeparam>
    public interface IWriteOnlyRepository<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        public Task<TDto> CreateAsync(TDto entity);
        public Task<TDto> UpdateAsync(TDto entity);
        public Task DeleteAsync(params object[] keyValues);
    }
}
