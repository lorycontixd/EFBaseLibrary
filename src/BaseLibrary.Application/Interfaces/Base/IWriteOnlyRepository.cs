namespace BaseLibrary.Application.Interfaces.Base
{
    /// <summary>
    /// Base interface for write-only repositories, which provides methods to add, update, and delete entities.
    /// </summary>
    /// <typeparam name="TEntity">Type of entity handled by the repository</typeparam>
    public interface IWriteOnlyRepository<TEntity> where TEntity : class
    {
        public Task AddAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task DeleteAsync(params object[] keyValues);
    }
}
