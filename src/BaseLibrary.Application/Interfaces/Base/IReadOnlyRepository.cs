namespace BaseLibrary.Application.Interfaces.Base
{
    /// <summary>
    /// Base interface for read-only repositories, which provides methods to retrieve entities without modifying them.
    /// </summary>
    /// <typeparam name="TEntity">Type of the entity handled by the repository</typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(params object[] keyValues);
        Task<bool> ExistsAsync(params object[] keyValues);

        IQueryable<TEntity> Query(); // Returns an IQueryable for LINQ queries
        IQueryable<TEntity> QueryAsNoTracking(); // Returns an IQueryable for LINQ queries without tracking changes
    }
}