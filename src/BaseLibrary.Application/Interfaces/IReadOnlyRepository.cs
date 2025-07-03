using BaseLibrary.Core.Entities.Base;
using BaseLibrary.Application.DTOs.Base;

namespace BaseLibrary.Application.Interfaces
{
    /// <summary>
    /// Base interface for read-only repositories, which provides methods to retrieve entities without modifying them.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity handled by the repository</typeparam>
    public interface IReadOnlyRepository<TEntity, TDto> where TEntity : class, IEntity where TDto : class, IDto
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto?> GetByIdAsync(params object[] keyValues);
        Task<bool> ExistsAsync(params object[] keyValues);

        IQueryable<TDto> Query(); // Returns an IQueryable for LINQ queries
        IQueryable<TDto> QueryAsNoTracking(); // Returns an IQueryable for LINQ queries without tracking changes
    }
}