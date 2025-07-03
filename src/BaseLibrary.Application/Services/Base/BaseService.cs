using BaseLibrary.Application.Interfaces.Base;

namespace BaseLibrary.Services.Base
{
    public abstract class BaseService<TEntity>(IBaseRepository<TEntity> repo) : IBaseService<TEntity> where TEntity : class
    {
        public readonly IBaseRepository<TEntity> _repo = repo;

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }
        public virtual async Task<TEntity?> GetByIdAsync(params object[] keyValues)
        {
            return await _repo.GetByIdAsync(keyValues);
        }
        public virtual async Task AddAsync(TEntity entity)
        {
            await _repo.AddAsync(entity);
        }
        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repo.UpdateAsync(entity);
        }
        public virtual async Task DeleteAsync(params object[] keyValues)
        {
            await _repo.DeleteAsync(keyValues);
        }
    }
}
